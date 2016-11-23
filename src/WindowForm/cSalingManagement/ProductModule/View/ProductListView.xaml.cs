using cSalingmanagement.Webservice;
using cSalingManagement.Infrastructure.Common;
using cSalingManagement.Infrastructure.Model;
using Newtonsoft.Json;
using Prism.Commands;
using Prism.Regions;
using ProductModule.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ProductModule.View
{
    /// <summary>
    /// Interaction logic for ProductListView.xaml
    /// </summary>
    public partial class ProductListView : UserControl, INavigationAware
    {

        
        #region Navigation Region
        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            Console.WriteLine("ProductListView :IsNavigationTarget");
            return false;
        }

        public void OnNavigatedFrom(NavigationContext navigationContext)
        {
            Console.WriteLine("ProductListView :OnNavigatedFrom");
        }

        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            Console.WriteLine("ProductListView :OnNavigatedTo");
        } 
        #endregion


        private ProductListViewModel _vm = null;

        public ProductListViewModel Vm
        {
            get { return _vm; }
            set
            {
                _vm = value;
            }
        }
        
        public ProductListView(ProductListViewModel vm)
        {
            InitializeComponent();
            vm.view = this;
            _vm = vm;
            _vm.GetInitData();
            DataContext = _vm;
        }
        
        


        




        
    }
}
