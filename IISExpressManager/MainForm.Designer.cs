namespace IISExpressManager
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.siteListView = new System.Windows.Forms.DataGridView();
            this.gridViewRowContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.viewInBrowserContextMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.toggleStatusContextMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.id = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.siteName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.status = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.processId = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.portNumber = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.notificationTextBox = new System.Windows.Forms.TextBox();
            this.systemTrayNotifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.notificationContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.appExitContextMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.runSiteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editSiteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.resetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stopAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.refreshToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.statusBarStrip = new System.Windows.Forms.StatusStrip();
            this.iisConfigFileLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.iisExpressConfigStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripSplitButton1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.iisExpressStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel4 = new System.Windows.Forms.ToolStripStatusLabel();
            this.ViewInBrowserColumn = new System.Windows.Forms.DataGridViewImageColumn();
            this.siteGrid_Id_Column = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SiteGrid_Name_Column = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SiteGrid_Port_Column = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SiteGrid_Status_Column = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ToggleStatus = new System.Windows.Forms.DataGridViewButtonColumn();
            this.SiteGrid_ProcessId_Column = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.siteListView)).BeginInit();
            this.gridViewRowContextMenuStrip.SuspendLayout();
            this.notificationContextMenuStrip.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.statusBarStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // siteListView
            // 
            this.siteListView.AllowUserToAddRows = false;
            this.siteListView.AllowUserToDeleteRows = false;
            this.siteListView.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.siteListView.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.siteListView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ViewInBrowserColumn,
            this.siteGrid_Id_Column,
            this.SiteGrid_Name_Column,
            this.SiteGrid_Port_Column,
            this.SiteGrid_Status_Column,
            this.ToggleStatus,
            this.SiteGrid_ProcessId_Column});
            this.siteListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.siteListView.Location = new System.Drawing.Point(0, 24);
            this.siteListView.Name = "siteListView";
            this.siteListView.ReadOnly = true;
            this.siteListView.Size = new System.Drawing.Size(751, 442);
            this.siteListView.TabIndex = 11;
            this.siteListView.DoubleClick += new System.EventHandler(this.ListViewDoubleClickItem);
            this.siteListView.MouseClick += new System.Windows.Forms.MouseEventHandler(this.SiteDataGridViewMouseClick);
            // 
            // gridViewRowContextMenuStrip
            // 
            this.gridViewRowContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.viewInBrowserContextMenu,
            this.toggleStatusContextMenu});
            this.gridViewRowContextMenuStrip.Name = "contextMenuStrip2";
            this.gridViewRowContextMenuStrip.Size = new System.Drawing.Size(158, 48);
            // 
            // viewInBrowserContextMenu
            // 
            this.viewInBrowserContextMenu.Name = "viewInBrowserContextMenu";
            this.viewInBrowserContextMenu.Size = new System.Drawing.Size(157, 22);
            this.viewInBrowserContextMenu.Text = "View in Browser";
            this.viewInBrowserContextMenu.Click += new System.EventHandler(this.ViewInBrowserContextMenuClick);
            // 
            // toggleStatusContextMenu
            // 
            this.toggleStatusContextMenu.Name = "toggleStatusContextMenu";
            this.toggleStatusContextMenu.Size = new System.Drawing.Size(157, 22);
            this.toggleStatusContextMenu.Text = "Toggle Status";
            this.toggleStatusContextMenu.Click += new System.EventHandler(this.ToggleStatusContextMenuClick);
            // 
            // id
            // 
            this.id.Text = "ID";
            // 
            // siteName
            // 
            this.siteName.Text = "Name";
            this.siteName.Width = 143;
            // 
            // status
            // 
            this.status.Text = "Status";
            this.status.Width = 86;
            // 
            // processId
            // 
            this.processId.Text = "Process ID";
            this.processId.Width = 114;
            // 
            // portNumber
            // 
            this.portNumber.Text = "Port Number";
            this.portNumber.Width = 118;
            // 
            // notificationTextBox
            // 
            this.notificationTextBox.Dock = System.Windows.Forms.DockStyle.Right;
            this.notificationTextBox.Location = new System.Drawing.Point(751, 0);
            this.notificationTextBox.Multiline = true;
            this.notificationTextBox.Name = "notificationTextBox";
            this.notificationTextBox.ReadOnly = true;
            this.notificationTextBox.Size = new System.Drawing.Size(207, 466);
            this.notificationTextBox.TabIndex = 12;
            // 
            // systemTrayNotifyIcon
            // 
            this.systemTrayNotifyIcon.ContextMenuStrip = this.notificationContextMenuStrip;
            this.systemTrayNotifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("systemTrayNotifyIcon.Icon")));
            this.systemTrayNotifyIcon.Text = "IIS Express Manager";
            this.systemTrayNotifyIcon.Visible = true;
            this.systemTrayNotifyIcon.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.NotifyIconMouseDoubleClick);
            // 
            // notificationContextMenuStrip
            // 
            this.notificationContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.appExitContextMenu});
            this.notificationContextMenuStrip.Name = "contextMenuStrip1";
            this.notificationContextMenuStrip.Size = new System.Drawing.Size(93, 26);
            // 
            // appExitContextMenu
            // 
            this.appExitContextMenu.Name = "appExitContextMenu";
            this.appExitContextMenu.Size = new System.Drawing.Size(92, 22);
            this.appExitContextMenu.Text = "Exit";
            this.appExitContextMenu.Click += new System.EventHandler(this.NotificationIconContextItem1Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem,
            this.toolsToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(7, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(751, 24);
            this.menuStrip1.TabIndex = 16;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.runSiteToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // runSiteToolStripMenuItem
            // 
            this.runSiteToolStripMenuItem.Name = "runSiteToolStripMenuItem";
            this.runSiteToolStripMenuItem.Size = new System.Drawing.Size(117, 22);
            this.runSiteToolStripMenuItem.Text = "Run Site";
            this.runSiteToolStripMenuItem.Click += new System.EventHandler(this.runSiteToolStripMenuItem_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.editSiteToolStripMenuItem});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
            this.editToolStripMenuItem.Text = "Edit";
            // 
            // editSiteToolStripMenuItem
            // 
            this.editSiteToolStripMenuItem.Name = "editSiteToolStripMenuItem";
            this.editSiteToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
            this.editSiteToolStripMenuItem.Text = "Edit Site";
            this.editSiteToolStripMenuItem.Click += new System.EventHandler(this.editSiteToolStripMenuItem_Click);
            // 
            // toolsToolStripMenuItem
            // 
            this.toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.resetToolStripMenuItem,
            this.stopAllToolStripMenuItem,
            this.refreshToolStripMenuItem,
            this.optionsToolStripMenuItem});
            this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            this.toolsToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.toolsToolStripMenuItem.Text = "Tools";
            // 
            // resetToolStripMenuItem
            // 
            this.resetToolStripMenuItem.Name = "resetToolStripMenuItem";
            this.resetToolStripMenuItem.Size = new System.Drawing.Size(132, 22);
            this.resetToolStripMenuItem.Text = "Reset";
            this.resetToolStripMenuItem.Click += new System.EventHandler(this.resetToolStripMenuItem_Click);
            // 
            // stopAllToolStripMenuItem
            // 
            this.stopAllToolStripMenuItem.Name = "stopAllToolStripMenuItem";
            this.stopAllToolStripMenuItem.Size = new System.Drawing.Size(132, 22);
            this.stopAllToolStripMenuItem.Text = "Stop All";
            this.stopAllToolStripMenuItem.Click += new System.EventHandler(this.stopAllToolStripMenuItem_Click);
            // 
            // refreshToolStripMenuItem
            // 
            this.refreshToolStripMenuItem.Name = "refreshToolStripMenuItem";
            this.refreshToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F5;
            this.refreshToolStripMenuItem.Size = new System.Drawing.Size(132, 22);
            this.refreshToolStripMenuItem.Text = "Refresh";
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(132, 22);
            this.optionsToolStripMenuItem.Text = "Options";
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.helpToolStripMenuItem1,
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // helpToolStripMenuItem1
            // 
            this.helpToolStripMenuItem1.Name = "helpToolStripMenuItem1";
            this.helpToolStripMenuItem1.Size = new System.Drawing.Size(107, 22);
            this.helpToolStripMenuItem1.Text = "Help";
            this.helpToolStripMenuItem1.Click += new System.EventHandler(this.helpToolStripMenuItem1_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // statusBarStrip
            // 
            this.statusBarStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.iisConfigFileLabel,
            this.iisExpressConfigStatusLabel,
            this.toolStripSplitButton1,
            this.toolStripStatusLabel1,
            this.iisExpressStatusLabel,
            this.toolStripStatusLabel3,
            this.toolStripStatusLabel4});
            this.statusBarStrip.Location = new System.Drawing.Point(0, 466);
            this.statusBarStrip.Name = "statusBarStrip";
            this.statusBarStrip.Padding = new System.Windows.Forms.Padding(1, 0, 16, 0);
            this.statusBarStrip.Size = new System.Drawing.Size(958, 22);
            this.statusBarStrip.TabIndex = 17;
            this.statusBarStrip.Text = "statusStrip1";
            // 
            // iisConfigFileLabel
            // 
            this.iisConfigFileLabel.Name = "iisConfigFileLabel";
            this.iisConfigFileLabel.Size = new System.Drawing.Size(79, 17);
            this.iisConfigFileLabel.Text = "IIS Config File";
            // 
            // iisExpressConfigStatusLabel
            // 
            this.iisExpressConfigStatusLabel.Name = "iisExpressConfigStatusLabel";
            this.iisExpressConfigStatusLabel.Size = new System.Drawing.Size(64, 17);
            this.iisExpressConfigStatusLabel.Text = "Not Found";
            // 
            // toolStripSplitButton1
            // 
            this.toolStripSplitButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripSplitButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripSplitButton1.Image")));
            this.toolStripSplitButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripSplitButton1.Name = "toolStripSplitButton1";
            this.toolStripSplitButton1.Size = new System.Drawing.Size(10, 17);
            this.toolStripSplitButton1.Text = "|";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(60, 17);
            this.toolStripStatusLabel1.Text = "IIS Express";
            // 
            // iisExpressStatusLabel
            // 
            this.iisExpressStatusLabel.Name = "iisExpressStatusLabel";
            this.iisExpressStatusLabel.Size = new System.Drawing.Size(64, 17);
            this.iisExpressStatusLabel.Text = "Not Found";
            // 
            // toolStripStatusLabel3
            // 
            this.toolStripStatusLabel3.Name = "toolStripStatusLabel3";
            this.toolStripStatusLabel3.Size = new System.Drawing.Size(522, 17);
            this.toolStripStatusLabel3.Spring = true;
            // 
            // toolStripStatusLabel4
            // 
            this.toolStripStatusLabel4.Name = "toolStripStatusLabel4";
            this.toolStripStatusLabel4.Size = new System.Drawing.Size(142, 17);
            this.toolStripStatusLabel4.Text = "IIS Express Manager V0.5B";
            // 
            // ViewInBrowserColumn
            // 
            this.ViewInBrowserColumn.HeaderText = "";
            this.ViewInBrowserColumn.Name = "ViewInBrowserColumn";
            this.ViewInBrowserColumn.ReadOnly = true;
            this.ViewInBrowserColumn.Width = 20;
            // 
            // siteGrid_Id_Column
            // 
            this.siteGrid_Id_Column.DataPropertyName = "Id";
            this.siteGrid_Id_Column.HeaderText = "ID";
            this.siteGrid_Id_Column.Name = "siteGrid_Id_Column";
            this.siteGrid_Id_Column.ReadOnly = true;
            this.siteGrid_Id_Column.Width = 50;
            // 
            // SiteGrid_Name_Column
            // 
            this.SiteGrid_Name_Column.DataPropertyName = "SiteName";
            this.SiteGrid_Name_Column.HeaderText = "Site Name";
            this.SiteGrid_Name_Column.Name = "SiteGrid_Name_Column";
            this.SiteGrid_Name_Column.ReadOnly = true;
            this.SiteGrid_Name_Column.Width = 300;
            // 
            // SiteGrid_Port_Column
            // 
            this.SiteGrid_Port_Column.DataPropertyName = "Port";
            this.SiteGrid_Port_Column.HeaderText = "Port #";
            this.SiteGrid_Port_Column.Name = "SiteGrid_Port_Column";
            this.SiteGrid_Port_Column.ReadOnly = true;
            this.SiteGrid_Port_Column.Width = 50;
            // 
            // SiteGrid_Status_Column
            // 
            this.SiteGrid_Status_Column.DataPropertyName = "Status";
            this.SiteGrid_Status_Column.HeaderText = "Status";
            this.SiteGrid_Status_Column.Name = "SiteGrid_Status_Column";
            this.SiteGrid_Status_Column.ReadOnly = true;
            // 
            // ToggleStatus
            // 
            this.ToggleStatus.HeaderText = "";
            this.ToggleStatus.Name = "ToggleStatus";
            this.ToggleStatus.ReadOnly = true;
            this.ToggleStatus.Width = 20;
            // 
            // SiteGrid_ProcessId_Column
            // 
            this.SiteGrid_ProcessId_Column.DataPropertyName = "ProcessId";
            this.SiteGrid_ProcessId_Column.HeaderText = "Process #";
            this.SiteGrid_ProcessId_Column.Name = "SiteGrid_ProcessId_Column";
            this.SiteGrid_ProcessId_Column.ReadOnly = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(958, 488);
            this.Controls.Add(this.siteListView);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.notificationTextBox);
            this.Controls.Add(this.statusBarStrip);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(655, 348);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "IISExpressManager (Beta)";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormClosingEvent);
            ((System.ComponentModel.ISupportInitialize)(this.siteListView)).EndInit();
            this.gridViewRowContextMenuStrip.ResumeLayout(false);
            this.notificationContextMenuStrip.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusBarStrip.ResumeLayout(false);
            this.statusBarStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ColumnHeader id;
        private System.Windows.Forms.ColumnHeader siteName;
        private System.Windows.Forms.TextBox notificationTextBox;
        private System.Windows.Forms.ColumnHeader status;
        private System.Windows.Forms.NotifyIcon systemTrayNotifyIcon;
        private System.Windows.Forms.ContextMenuStrip notificationContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem appExitContextMenu;
        private System.Windows.Forms.ColumnHeader processId;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem resetToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem stopAllToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem refreshToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
        private System.Windows.Forms.ColumnHeader portNumber;
        private System.Windows.Forms.ToolStripMenuItem runSiteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editSiteToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip gridViewRowContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem viewInBrowserContextMenu;
        private System.Windows.Forms.ToolStripMenuItem toggleStatusContextMenu;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.StatusStrip statusBarStrip;
        private System.Windows.Forms.ToolStripStatusLabel iisConfigFileLabel;
        private System.Windows.Forms.ToolStripStatusLabel iisExpressConfigStatusLabel;
        private System.Windows.Forms.ToolStripStatusLabel toolStripSplitButton1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel iisExpressStatusLabel;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel3;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel4;
        private System.Windows.Forms.DataGridView siteListView;
        private System.Windows.Forms.DataGridViewImageColumn ViewInBrowserColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn siteGrid_Id_Column;
        private System.Windows.Forms.DataGridViewTextBoxColumn SiteGrid_Name_Column;
        private System.Windows.Forms.DataGridViewTextBoxColumn SiteGrid_Port_Column;
        private System.Windows.Forms.DataGridViewTextBoxColumn SiteGrid_Status_Column;
        private System.Windows.Forms.DataGridViewButtonColumn ToggleStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn SiteGrid_ProcessId_Column;
    }
}

