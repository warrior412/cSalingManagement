using CustomerModule.ViewModel;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

namespace CustomerModule.View
{
    /// <summary>
    /// Interaction logic for CustomerListView.xaml
    /// </summary>
    public partial class CustomerListView : UserControl, INavigationAware
    {
        #region Navigation Region
        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return false;
        }

        public void OnNavigatedFrom(NavigationContext navigationContext)
        {
        }

        public void OnNavigatedTo(NavigationContext navigationContext)
        {
        }
        #endregion

        private CustomerListViewModel _vm = null;

        public CustomerListViewModel Vm
        {
            get { return _vm; }
            set
            {
                _vm = value;
            }
        }
        public CustomerListView(CustomerListViewModel vm)
        {
            InitializeComponent();
            vm.GetInitData();
            vm.view = this;
            _vm = vm;
            DataContext = _vm;
        }

        public void ShowMessage(string message)
        {
            MessageBox.Show(message);
        }
    }
}
