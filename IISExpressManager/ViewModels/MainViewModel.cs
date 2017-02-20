using System.Collections.Generic;
using System.ComponentModel;
using IISExpressManager.AppEvents;
using IISExpressManager.Helpers;
using WinForms.Framework.Commands;
using WinForms.Framework.Messaging;

namespace IISExpressManager.ViewModels {
    public class MainViewModel {
        private IEventAggregator _eventAggregator;

        public MainViewModel(IEventAggregator eventAggregator) {
            _eventAggregator = eventAggregator;
            ServerConfigFound = App.IISExpressConfig.ConfigurationFound();
            ServerFound = App.IISExpressConfig.ConfigurationFound() && App.IISExpressConfig.IISExpressInstalled();
            IISExpressAddress = App.IISExpressConfig.IISExpressAddress;
            Sites = new BindingList<IISExpressSite>();
            RefreshSiteList();
            RefreshSiteListCommand = new DelegateCommand("", "Refresh Sites", () => { RefreshSiteList(); }, () => true);
        }

        public bool ServerFound { get; set; }
        public bool ServerConfigFound { get; set; }
        public string IISExpressAddress { get; set; }
        public BindingList<IISExpressSite> Sites { get; set; }
        public ICommand RefreshSiteListCommand { get; set; }

        public void RefreshSiteList() {
            var iisSites = IISConfigReader.ReadXmlFromConfig(App.IISExpressConfig);
            IISProcessManager.AssignProcessIds(iisSites);
            Sites.Clear();
            foreach (var site in iisSites) Sites.Add(site);
            Sites.ResetBindings();
            _eventAggregator.Publish(new BalloonNotificationEvent {
                Title = "Refresh",
                Message = "List of sites was refreshsed"
            });
        }
    }
}