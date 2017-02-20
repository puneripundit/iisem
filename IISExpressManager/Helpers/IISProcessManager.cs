using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows.Forms;
using IISExpressManager.Properties;
using IISExpressManager.ViewModels;

namespace IISExpressManager.Helpers
{
    internal class IISProcessManager
    {
        private static List<IISExpressSite> MapSiteNameWithProcessId(List<IISExpressSite> iisSites, string processId,
            string siteName)
        {
            foreach (var iisSite in iisSites)
            {
                if (iisSite.SiteName.Equals(siteName))
                {
                    iisSite.Status = SiteStatus.Running;
                    iisSite.ProcessId = processId;
                }
            }
            return iisSites;
        }

        internal static List<IISExpressSite> AssignProcessIds(List<IISExpressSite> iisSites)
        {
            var onGoingIISProcesses = Process.GetProcessesByName("iisexpress");
            foreach (var process in onGoingIISProcesses)
            {
                var commandLine = ProcessCommandLineFinder.FindProcessStartCommandLineByProcessId(process.Id);
                if (commandLine.Contains("/site:\""))
                {
                    var siteName = FindSiteName(commandLine);
                    iisSites = MapSiteNameWithProcessId(iisSites, process.Id.ToString(), siteName);
                }
            }
            return iisSites;
        }

        internal static int ExecuteProcess(string pathOfExe, string arguments)
        {
            using (var p = new Process { StartInfo = {
                                        CreateNoWindow = true,
                                        WindowStyle = ProcessWindowStyle.Hidden,
                                        FileName = pathOfExe,
                                        Arguments = arguments
                                    }})
            {
                try
                {
                    p.Start();
                    var processId = p.Id;
                    p.Close();
                    return processId;
                }
                catch (Win32Exception)
                {
                    MessageBox.Show(Resources.IISProcessManager_ExecuteProcess_ErrorMessage,
                        Resources.IISProcessManager_ExecuteProcess_ErrorMessageTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);

                    throw;
                }
            }
        }

        private static string FindSiteName(string listItem)
        {
            var indexOfSite = listItem.IndexOf("site:\"", StringComparison.Ordinal);
            var temp = listItem.Substring(indexOfSite + 6);
            var indexOfsecondQuoteAroundSiteName = temp.IndexOf("\"", StringComparison.Ordinal);
            return temp.Substring(0, indexOfsecondQuoteAroundSiteName);
        }

        internal static void FindWebsite()
        {
            var list = ProcessCommandLineFinder.FindAllProcessStartCommandLineByProcessName("iisexpress");

            foreach (var listItem in list)
            {
                if (listItem.Contains("/site:\""))
                {
                    FindSiteName(listItem);
                }
                else if (listItem.Contains("/siteId:"))
                {
                    Console.WriteLine(@"type2: " + listItem);
                }
            }
        }

        internal static void KillAllhostedApplications()
        {
            var p = new Process
            {
                StartInfo =
                {
                    CreateNoWindow = true,
                    WindowStyle = ProcessWindowStyle.Hidden,
                    FileName = "taskkill"
                }
            };
            foreach (var process in Process.GetProcessesByName("iisexpress"))
            {
                p.StartInfo.Arguments = "/pid " + process.Id;
                p.Start();
            }
            p.Close();
        }
    }
}