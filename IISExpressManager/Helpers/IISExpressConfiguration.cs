using System;
using System.IO;

namespace IISExpressManager.Helpers {
    public class IISExpressConfiguration {
        public IISExpressConfiguration() {
            SetIISExpressConfigAddress();
            SetIISExpressAddress();
        }

        internal string IISExpressAddress { get; private set; }

        internal string IISExpressConfigAddress { get; private set; }

        private void SetIISExpressAddress() {
            switch (IntPtr.Size) {
                case 8:
                    IISExpressAddress = @"C:\Program Files (x86)\IIS Express\iisexpress.exe";
                    break;
                case 4:
                    IISExpressAddress = @"C:\Program Files\IIS Express\iisexpress.exe";
                    break;
                default:
                    throw new InvalidOperationException("This application cannot be run on this operating system.");
            }
        }

        public bool IISExpressInstalled() {
            return IISExpressAddress != null && File.Exists(IISExpressAddress);
        }

        internal void SetIISExpressConfigAddress() {
            /*
                         * Code changed based on the valuable feedbacks of Ido Flatow and Mike Van
                         * 24 June, 2012             
                         */
            IISExpressConfigAddress = Environment.GetFolderPath(
                                          Environment.SpecialFolder.MyDocuments) +
                                      "\\IISExpress\\config\\applicationhost.config";
        }

        public bool ConfigurationFound() {
            return IISExpressConfigAddress != null && File.Exists(IISExpressConfigAddress);
        }
    }
}