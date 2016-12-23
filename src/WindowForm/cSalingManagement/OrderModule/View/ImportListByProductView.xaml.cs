using OrderModule.ViewModel;
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
using System.Windows.Shapes;

namespace OrderModule.View
{
    /// <summary>
    /// Interaction logic for ImportListByProductView.xaml
    /// </summary>
    public partial class ImportListByProductView : Window, INavigationAware
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
        }
        #endregion

        #region Getter-Setter
        private ImportListByProductViewModel _vm = null;

        public ImportListByProductViewModel Vm
        {
            get { return _vm; }
            set { _vm = value; }
        }
        private string productID;

        public string ProductID
        {
            get { return productID; }
            set { productID = value; }
        }

        private int orderedQuantity;

        public int OrderedQuantity
        {
            get { return orderedQuantity; }
            set { orderedQuantity = value; }
        }
        #endregion
        public ImportListByProductView(string productID)
        {
            InitializeComponent();
            ProductID = productID;
            _vm = new ImportListByProductViewModel();
            _vm.view = this;
            DataContext = Vm;
            GetInitData();
        }


        private void GetInitData()
        {
            Vm.GetProductDetailByID(ProductID);
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }
    }
}
