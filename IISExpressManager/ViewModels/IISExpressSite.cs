using System;
using System.Diagnostics;
using IISExpressManager.AppEvents;
using IISExpressManager.Helpers;
using PropertyChanged;
using WinForms.Framework.Commands;
using WinForms.Framework.Messaging;

namespace IISExpressManager.ViewModels
{
    [ImplementPropertyChanged]
    public class IISExpressSite
    {
        private IEventAggregator _eventAggregator;
        private const string NOT_FOUND = "Not Found";

        private IISExpressSite() {
            _eventAggregator = EventAggregator.Instance;
        }

        public IISExpressSite(string siteName, string id, string portNumber) : this()
        {
            SiteName = siteName;
            Id = id;
            Status = SiteStatus.Stopped;
            ProcessId = NOT_FOUND;
            Port = portNumber;

            ToggleStatusCommand = new DelegateCommand("", "Toggle Status", 
                ()=> { ToggleStatus(); }, 
                ()=> true );

            ViewInBrowserCommand = new DelegateCommand("", "View in Browser",
                () => { ViewInBrowser(); },
                () => Status == SiteStatus.Running);
        }

        private void ViewInBrowser()
        {
            if (Status == SiteStatus.Running) {
                var uri = @"http://localhost:";
                uri += Port;
                Process.Start(uri);
            }
        }

        public string ProcessId { get; set; }
        public SiteStatus Status { get; set; }
        public string Id { get; set; }
        public string SiteName { get; set; }
        public string Port { get; set; }
        [System.ComponentModel.Browsable(false)]
        public ICommand ToggleStatusCommand { get; set; }
        [System.ComponentModel.Browsable(false)]
        public ICommand ViewInBrowserCommand { get; set; }

        internal void ToggleStatus()
        {
            if (Status == SiteStatus.Stopped || Status == SiteStatus.Error)
            {
                Status = SiteStatus.Starting;
                StartSite();
                _eventAggregator.Publish<BalloonNotificationEvent>(new BalloonNotificationEvent {
                    Title = "Site Started",
                    Message = "Website " + SiteName + " has started!",
                    IconType = IconType.Info
                });
            }
            else if (Status == SiteStatus.Running)
            {
                Status = SiteStatus.Stopping;
                StopSite();
                _eventAggregator.Publish<BalloonNotificationEvent>(new BalloonNotificationEvent {
                    Title = "Site Stopped",
                    Message = "Website " + SiteName + " has stopped!",
                    IconType = IconType.Info
                });
            }
        }

        private void StartSite()
        {
            try
            {
                
                var procId = IISProcessManager.ExecuteProcess(
                    App.IISExpressConfig.IISExpressAddress, "/site:\"" + SiteName + "\"");
                ProcessId = procId.ToString();
            }
            catch (Exception)
            {
                Status = SiteStatus.Error;
                throw new InvalidOperationException("Could not start the process!");
            }
            Status = SiteStatus.Running;
        }

        private void StopSite()
        {
            try
            {
                IISProcessManager.ExecuteProcess("taskkill", "/pid "
                                              + ProcessId);
                ProcessId = NOT_FOUND;
            }
            catch (Exception)
            {
                Status = SiteStatus.Error;
                throw new InvalidOperationException("Could not start the process!");
            }
            Status = SiteStatus.Stopped;
        }
    }

    public enum SiteStatus
    {
        Stopped = 0,
        Starting,
        Running,
        Stopping,
        Error
    }
}