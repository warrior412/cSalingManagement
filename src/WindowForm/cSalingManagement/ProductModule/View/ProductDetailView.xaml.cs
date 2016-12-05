using cSalingmanagement.Webservice;
using cSalingManagement.Infrastructure.Common;
using cSalingManagement.Infrastructure.Model;
using Prism.Regions;
using ProductModule.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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

namespace ProductModule.View
{
    /// <summary>
    /// Interaction logic for ProductDetailView.xaml
    /// </summary>
    public partial class ProductDetailView : UserControl, INavigationAware
    {
        #region Navigation Region
        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            Console.WriteLine("ProductDetailView :IsNavigationTarget");
            return false;
        }

        public void OnNavigatedFrom(NavigationContext navigationContext)
        {
            Console.WriteLine("ProductDetailView :IsNavigationTarget");
        }

        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            Console.WriteLine("ProductDetailView :IsNavigationTarget");
            var param = navigationContext.Parameters;
            if (param["ProductID"] == null)
            {
                Vm.IsEditing = true;
                return;
            }
            string productID = param["ProductID"].ToString();
            Vm.IsEditing = false;
            Vm.GetProductDetailByID(productID);
        }
        #endregion


        #region Getter - Setter
        private ProductDetailViewModel _vm = null;

        public ProductDetailViewModel Vm
        {
            get { return _vm; }
            set{_vm = value;}
        }
        #endregion

        #region Constructor
        public ProductDetailView(ProductDetailViewModel vm)
        {
            InitializeComponent();
            _vm = vm;
            _vm.view = this;
            DataContext = Vm;
            GetInitData();
        } 
        #endregion
        private void GetInitData()
        {
            Vm.GetAllCategoryInfo();
        }

        public void ShowMessage(string message)
        {
            MessageBox.Show(message);
        }
        

        private void cbCategory_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(cbCategory.SelectedValue!=null)
                Vm.ProductDetail.Category = cbCategory.SelectedValue.ToString();
        }

        
    }
}
