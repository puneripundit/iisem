using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace IISExpressManager.ViewModels
{
    public class ExpressSiteComparer : IComparer<IISExpressSite>
    {
        private readonly string _fieldName;
        private readonly ListSortDirection _sortOrder;

        public ExpressSiteComparer(string fieldName, ListSortDirection sortOrder)
        {
            var fieldNames = from propName in typeof(IISExpressSite).GetProperties()
                select propName.Name;
            if (fieldNames.Contains(fieldName))
            {
                _fieldName = fieldName;
                _sortOrder = sortOrder;
            }
            else
            {
                throw new ArgumentException($"{fieldName} is an invalid property name!");
            }
        }

        public int Compare(IISExpressSite x, IISExpressSite y)
        {
            IISExpressSite first;
            IISExpressSite second;
            if (_sortOrder == ListSortDirection.Ascending)
            {
                first = x;
                second = y;
            }
            else
            {
                first = y;
                second = x;
            }
            switch (_fieldName)
            {
                case "Id":
                    return Convert.ToInt32(first.Id).CompareTo(Convert.ToInt32(second.Id));
                case "ProcessId":
                    if (first.Status == SiteStatus.Running && second.Status == SiteStatus.Running)
                        return Convert.ToInt32(first.ProcessId).CompareTo(Convert.ToInt32(second.ProcessId));
                    return string.Compare(first.ProcessId, second.ProcessId, StringComparison.InvariantCultureIgnoreCase);
                case "SiteName":
                    return string.Compare(first.SiteName, second.SiteName, StringComparison.InvariantCultureIgnoreCase);
                case "Status":
                    return string.Compare(first.Status.ToString(), second.Status.ToString(),
                        StringComparison.InvariantCultureIgnoreCase);
                default:
                    return Convert.ToInt32(first.Id).CompareTo(Convert.ToInt32(second.Id));
            }
        }
    }
}