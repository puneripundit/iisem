using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using IISExpressManager.AppEvents;
using IISExpressManager.Helpers;
using IISExpressManager.Properties;
using IISExpressManager.Services;
using IISExpressManager.ViewModels;
using WinForms.Framework.Commands;
using WinForms.Framework.Messaging;
using FontAwesome.Net;

namespace IISExpressManager {
    public partial class MainForm : Form {
        private readonly MainViewModel _vm;
        private readonly IEventAggregator _eventAggregator;
        private bool _isNotificationShown;
        private CommandManager _commandManager = new CommandManager();

        internal MainForm(MainViewModel vm, IEventAggregator eventAggregator) {
            _vm = vm;
            _eventAggregator = eventAggregator;
            InitializeComponent();
            SetStatusLabels();

            BindData();
            notificationTextBox.Text = Resources.MainForm_Double_click_Help_Message;
            _eventAggregator.Subscribe<BalloonNotificationEvent>(OnBalloonNotification);
        }

        private void OnBalloonNotification(BalloonNotificationEvent notificationEvent) {
            systemTrayNotifyIcon.BalloonTipTitle = notificationEvent.Title;
            systemTrayNotifyIcon.BalloonTipText = notificationEvent.Message;
            systemTrayNotifyIcon.BalloonTipIcon = notificationEvent.IconType.MapTipIcon();
            systemTrayNotifyIcon.ShowBalloonTip(800);
        }

        internal bool ExitFromNotification { get; set; }

        private void BindData() {
            siteListView.DataSource = _vm;
            siteListView.DataMember = "Sites";
            foreach (DataGridViewRow row in siteListView.Rows) {
                row.ContextMenuStrip = gridViewRowContextMenuStrip;
                (row.Cells["ViewInBrowserColumn"] as DataGridViewImageCell).Value = Resources.start;
                (row.Cells["ToggleStatus"] as DataGridViewButtonCell).Value = Resources.stop;

            }
            _vm.Sites.ListChanged +=
                (source, eventArgs) => {
                    if (eventArgs.ListChangedType == ListChangedType.Reset)
                        siteListView.Invalidate();
                };
            _commandManager.Bind(_vm.RefreshSiteListCommand, refreshToolStripMenuItem);
        }

        private IISExpressSite ListViewFindSelectedItem() {
            var selectedRows = from DataGridViewRow row in siteListView.SelectedRows select row;
            return selectedRows.Count() > 0 ? _vm.Sites[selectedRows.First().Index] : null;
        }

        private void ListViewDoubleClickItem(object sender, EventArgs e) {
            var selected = ListViewFindSelectedItem();
            if (selected != null) {
                if (selected.Status.Equals(SiteStatus.Running)) {
                    CheckAttemptToStopSelectedApp(selected);
                }
                else if (selected.Status.Equals(SiteStatus.Stopped)) {
                    CheckAttemptToStartSelectedApp(selected);
                }
            }
        }

        private void SiteDataGridViewMouseClick(object sender, MouseEventArgs e) {
            if (e.Button == MouseButtons.Right) {
                var currentMouseOverRow = siteListView.HitTest(e.X, e.Y).RowIndex;
                if (currentMouseOverRow >= 0) {
                    siteListView.ClearSelection();
                    siteListView.Rows[currentMouseOverRow].Selected = true;
                    gridViewRowContextMenuStrip.Show(siteListView, e.Location);
                }
            }
        }

        private void SetStatusLabels() {
            SetStatusForIISExpressConfigFileExistence();
            SetStatusForIISExpressExistence();
        }

        private void SetStatusForIISExpressExistence() {
            if (_vm.ServerFound) {
                iisExpressStatusLabel.Text = @"Found!";
                iisExpressStatusLabel.ForeColor = Color.Teal;
            }
            else {
                //DisableAllButtonsWhenIISError();
                iisExpressStatusLabel.ForeColor = Color.Red;
                notificationTextBox.Text = @"Please Install IIS Express";
            }
        }

        private void SetStatusForIISExpressConfigFileExistence() {
            if (_vm.ServerConfigFound) {
                iisExpressConfigStatusLabel.Text = @"Found!";
                iisExpressConfigStatusLabel.ForeColor = Color.Teal;
            }
            else {
                //DisableAllButtonsWhenIISError();
                iisExpressConfigStatusLabel.ForeColor = Color.Red;
                notificationTextBox.Text = @"Please Install IIS Express";
            }
        }

        private void UpdateBoxStatus(IISExpressSite selected) {
            notificationTextBox.Text = @"Site Name: " + selected.SiteName;
            notificationTextBox.Text += @"\r\nStatus: " + selected.Status;
        }

        private bool IsAnswerYes(DialogResult dialogResult) {
            if (dialogResult == DialogResult.Yes)
                return true;
            return false;
        }

        private void FormClosingEvent(object sender, FormClosingEventArgs e) {
            if (ExitFromNotification) {
                e.Cancel = false;
                Application.Exit();
                return;
            }
            WindowState = FormWindowState.Minimized;
            Hide();
            e.Cancel = true;
            if (!_isNotificationShown) {
                _eventAggregator.Publish<BalloonNotificationEvent>(new BalloonNotificationEvent() {
                    Title = @"IISEM One time Notice",
                    Message = @"Your IIS Express Manager is now minimized here."
                });
                _isNotificationShown = true;
            }
        }

        private void NotifyIconMouseDoubleClick(object sender, MouseEventArgs e) {
            ExitFromNotification = false;
            Show();
            WindowState = FormWindowState.Normal;
        }

        private void NotificationIconContextItem1Click(object sender, EventArgs e) {
            ExitFromNotification = true;
            Application.Exit();
        }

        private void StopAllIISHostedApplications() {
            IISProcessManager.KillAllhostedApplications();
            _vm.RefreshSiteList();
        }

        private void CheckAttemptToStopSelectedApp(IISExpressSite selected) {
            if (selected?.Status == SiteStatus.Stopped) {
                MessageBox.Show(
                    @"You can not stop an already stopped application.",
                    @"Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            selected.ToggleStatus();
        }

        private void CheckAttemptToStartSelectedApp(IISExpressSite selected) {
            if (selected?.Status == SiteStatus.Running) {
                MessageBox.Show(
                    @"You can not start an already started application",
                    @"Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            selected.ToggleStatus();
        }

        private void ViewInBrowserContextMenuClick(object sender, EventArgs e) {
            var selected = ListViewFindSelectedItem();
            if (selected != null) {
                if (selected.Status == SiteStatus.Running) {
                    var uri = @"http://localhost:";
                    uri += selected.Port;
                    Process.Start(uri);
                }
            }
        }

        private void ToggleStatusContextMenuClick(object sender, EventArgs e) {
            var selected = ListViewFindSelectedItem();
            if (selected != null) {
                if (selected.Status.Equals(SiteStatus.Running)) {
                    CheckAttemptToStopSelectedApp(selected);
                }
                else if (selected.Status.Equals(SiteStatus.Stopped) ||
                         selected.Status.Equals(SiteStatus.Error)) {
                    CheckAttemptToStartSelectedApp(selected);
                }
                else {
                    MessageBox.Show(this, @"Please wait while current operation completes!", @"Wait!");
                }
            }
        }

        private void helpToolStripMenuItem1_Click(object sender, EventArgs e) {
            MessageBox.Show("" +
                            @"1. Double Click to Start/Stop any Application in the list!"
                            + @"\n2. Press F5 to sync it with IIS Express",
                @"IISEM Help", MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e) {
            if (
                IsAnswerYes(
                    MessageBox.Show(
                        @"Hi there!\nIISEM is a open source freeware initiated by Amit from Bangladesh." +
                        @"\nIt is available in CodePlex.\nWant to check out the codeplex homepage?",
                        @"About", MessageBoxButtons.YesNo, MessageBoxIcon.Information))) {
                const string target = "http://iisem.codeplex.com/";
                Process.Start(target);
            }
        }

        private void resetToolStripMenuItem_Click(object sender, EventArgs e) {
            if (
                IsAnswerYes(
                    MessageBox.Show(
                        @"Clicking this will:\n" +
                        @"\n1. Stop all applications in IISExpress" +
                        @"\n2. Refresh The list." +
                        @"\n\nAre you sure you want to do this?",
                        @"Reset IIS Express Manager", MessageBoxButtons.YesNo, MessageBoxIcon.Information))) {
                StopAllIISHostedApplications();
                _vm.RefreshSiteList();
            }
        }

        private void stopAllToolStripMenuItem_Click(object sender, EventArgs e) {
            StopAllIISHostedApplications();
            _vm.RefreshSiteList();
            notificationTextBox.Text = @"Stopped all applications.";
        }

        private void runSiteToolStripMenuItem_Click(object sender, EventArgs e) {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK) {
                var folderPath = @"/path:";
                folderPath += folderBrowserDialog1.SelectedPath;
                IISProcessManager.ExecuteProcess(
                    _vm.IISExpressAddress,
                    folderPath
                );
            }
        }

        private void editSiteToolStripMenuItem_Click(object sender, EventArgs e) {
            SayOops();
        }

        private static void SayOops() {
            MessageBox.Show(@"Looks like it is not implemented yet.",
                @"Oops", MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }
    }
}