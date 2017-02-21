using System.Collections.Generic;
using System.ComponentModel;

namespace IISExpressManager.ViewModels
{
    //Implementing limited SortableBinding. This is for handling the specific sorting for
    //Process Id property which is eitehr integer or string. This can be changed if a generic
    //Process ID like -1 is set for not running processes. Which can then be interpreted on 
    //user interface. For full generic implementation of this class 
    //refer to URL: http://martinwilley.com/net/code/forms/sortablebindinglist.html
    public class SortableBindingList<T> : BindingList<T> where T : IISExpressSite
    {
        private bool _isSorted;
        private ListSortDirection _sortDirection = ListSortDirection.Ascending;

        public SortableBindingList()
        {
            _isSorted = false;
        }

        protected override bool SupportsSortingCore => true;

        protected override bool IsSortedCore => _isSorted;

        protected override ListSortDirection SortDirectionCore => _sortDirection;

        protected override void ApplySortCore(PropertyDescriptor prop, ListSortDirection direction)
        {
            var list = Items as List<T>;
            if (list != null)
            {
                var comparer = new ExpressSiteComparer(prop.Name, direction);
                _sortDirection = direction;
                list.Sort(comparer);
                _isSorted = true;
                //Resetting the list here clears the sort order from the form 
                //and the list is always sorted in ascending order.
                //OnListChanged(new ListChangedEventArgs(ListChangedType.Reset, -1));
            }
        }
    }
}