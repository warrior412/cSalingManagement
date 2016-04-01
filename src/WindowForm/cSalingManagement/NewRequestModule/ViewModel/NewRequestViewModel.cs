using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewRequestModule.ViewModel
{
    public class NewRequestViewModel:BindableBase
    {
        private ObservableCollection<TabControlItemsResource> _tabItems;

        public ObservableCollection<TabControlItemsResource> TabItems
        {
            get { return new ObservableCollection<TabControlItemsResource> { 
                new TabControlItemsResource{TabName= "Tab 1",ItemResource= null},
                new TabControlItemsResource{TabName= "Tab 2",ItemResource= null},
                new TabControlItemsResource{TabName= "Tab 3",ItemResource= null}
            }; }
            set { _tabItems = value; }
        }
    }
    public class TabControlItemsResource
    {
        public string TabName { get; set; }
        public ObservableCollection<ItemResource> ItemResource { get; set; }
    }
    public class ItemResource
    {
    }
}
