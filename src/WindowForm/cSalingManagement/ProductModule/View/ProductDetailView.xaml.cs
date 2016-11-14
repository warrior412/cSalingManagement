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
        private int CallServiceCount = 0;

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
                return;
            string productID = param["ProductID"].ToString();
            GetProductDetailByID(productID);
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
            GetInitData();
        } 
        #endregion
        private void GetInitData()
        {
            GetAllCategoryInfo();
        }

        private void GetAllCategoryInfo()
        {
            busyIndicator.IsBusy = true;
            CallServiceCount++;
            DAOProvider dao = DAOProvider.GetInstance();
            dao.CallBackComplete = new DAOProvider.FinishCompleted(Completed);
            dao.CallBackFail = new DAOProvider.FinishFail(Failed);
            dao.GetALL_M_CategoryInfo();
        }

        private void GetProductDetailByID(string productID)
        {
            busyIndicator.IsBusy = true;
            CallServiceCount++;
            DAOProvider dao = DAOProvider.GetInstance();
            dao.CallBackComplete = new DAOProvider.FinishCompleted(Completed);
            dao.CallBackFail = new DAOProvider.FinishFail(Failed);
            dao.GetALL_M_ProductInfoWithImportData_ByProductID(productID);
        }

        #region Delegate CallBack Method
        void Completed(string tag, object data)
        {

            this.Dispatcher.Invoke((Action)(() =>
            {
                if (tag == SalingManagement_WebServiceTag.TAG_GETALL_M_CATEGORYINFO)
                {
                    CallServiceCount--;
                    Vm.LstCategoryInfo = new M_CategoryInfo().JSonToListCategory(data);
                    DataContext = null;
                    DataContext = Vm;
                    this.cbCategory.ItemsSource = Vm.LstCategoryInfo;
                    this.cbCategory.DisplayMemberPath = "CategoryName";
                    this.UpdateLayout();
                }
                if (tag == SalingManagement_WebServiceTag.TAG_GETALL_M_PRODUCTINFO_BYID)
                {
                    CallServiceCount--;
                    Vm.ProductDetail = new M_ProductInfoWithImportInfo().JSonToProductInfoWithImportInfo(data.ToString());
                    DataContext = null;
                    DataContext = Vm;
                    this.UpdateLayout();
                }
                if (CallServiceCount <= 0)
                    busyIndicator.IsBusy = false;
            }));
        }

        void Failed(string tag, string data)
        {
            this.Dispatcher.Invoke((Action)(() =>
            {
                MessageBox.Show(data);
                busyIndicator.IsBusy = false;
                if (tag == SalingManagement_WebServiceTag.TAG_GETALL_M_PRODUCTINFO_BYID)
                {
                }
            }));
        } 
        #endregion

        
    }
}
