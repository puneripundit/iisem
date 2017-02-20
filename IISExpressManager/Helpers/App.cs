using System.Diagnostics;
using System.Windows.Forms;
using IISExpressManager.AppEvents;

namespace IISExpressManager.Helpers {
    internal static class App {
        public static IISExpressConfiguration IISExpressConfig { get; }

        static App() {
            //Find IIS Express Configuration & Status
            IISExpressConfig = new IISExpressConfiguration();
        }

        internal static bool InstanceAlreadyExists() {
            var processes = Process.GetProcessesByName("iisexpressmanager");
            if (processes.Length > 1) return true;
            return false;
        }

        public static ToolTipIcon MapTipIcon(this IconType type) {
            switch (type) {
                case IconType.Error:
                    return ToolTipIcon.Error;
                case IconType.Info:
                    return ToolTipIcon.Info;
                case IconType.Warning:
                    return ToolTipIcon.Warning;
                default:
                    return ToolTipIcon.None;
            }
        }
    }
}
