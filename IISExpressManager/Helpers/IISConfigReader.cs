using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text.RegularExpressions;
using System.Xml.Linq;
using IISExpressManager.ViewModels;

namespace IISExpressManager.Helpers
{
    internal class IISConfigReader
    {
        private static List<IISExpressSite> _iisSites;

        internal static List<IISExpressSite> ReadXmlFromConfig(IISExpressConfiguration iisExConfig)
        {
            _iisSites = new List<IISExpressSite>();

            if (!iisExConfig.ConfigurationFound()) return null;

            var rootElement = XElement.Load(iisExConfig.IISExpressConfigAddress);

            var sites = (from sitesNode in rootElement.Descendants("sites") select sitesNode).First();
            if (sites == null) throw new ConfigurationErrorsException("No sites element found in configuration!");
            var siteList = sites.Descendants("site");
            _iisSites = (from site in siteList
                let id = site.Attribute("id")
                where id != null
                let name = site.Attribute("name")
                where name != null
                let bindingInfo = site.Descendants("binding").First().Attribute("bindingInformation")
                where bindingInfo != null
                select
                new IISExpressSite(name.Value, id.Value,
                    FindPort(bindingInfo.Value))).ToList();
            return _iisSites;
        }

        private static string FindPort(string bindingInfo)
        {
            //<binding protocol=\"http\" bindingInformation=\":8080:localhost\" />
            //<binding protocol=\"http\" bindingInformation=\"*:1038:localhost\" />
            var regEx = new Regex("(\\d+)");
            var portNumber = regEx.Match(bindingInfo).Value;
            return portNumber;
        }
    }
}