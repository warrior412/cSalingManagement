using cSalingmanagement.Webservice;
using cSalingManagement.Infrastructure.Common;
using cSalingManagement.Infrastructure.Model;
using Newtonsoft.Json;
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
    /// Interaction logic for ProductImportRequestView.xaml
    /// </summary>
    public partial class ProductImportRequestView : UserControl, INavigationAware
    {
        private int CallServiceCount = 0; 
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
        private ProductImportRequestViewModel _vm = null;

        public ProductImportRequestViewModel Vm
        {
            get { return _vm; }
            set
            {
                _vm = value;
            }
        }

        public ProductImportRequestView(ProductImportRequestViewModel vm)
        {
            InitializeComponent();
            _vm = vm;
            _vm.view = this;
            GetInitData();
        }

        public void Insert_T_ImportProductInfo(ObservableCollection<M_ProductInfoWithImportInfo> lstImportProduct)
        {
            busyIndicator.IsBusy = true;
            CallServiceCount++;
            DAOProvider dao = DAOProvider.GetInstance();
            dao.CallBackComplete = new DAOProvider.FinishCompleted(Completed);
            dao.CallBackFail = new DAOProvider.FinishFail(Failed);
            dao.InsertT_ImportInfo(lstImportProduct);
        }
        public void GetInitData()
        {
            try
            {
                busyIndicator.IsBusy = true;
                DAOProvider dao = DAOProvider.GetInstance();
                dao.CallBackComplete = new DAOProvider.FinishCompleted(Completed);
                dao.CallBackFail = new DAOProvider.FinishFail(Failed);
                CallServiceCount++;
                dao.GetALL_M_ProductInfo();
                CallServiceCount++;
                dao.GetALL_M_SupplierInfo();
            }
            catch (Exception ex)
            {
                busyIndicator.IsBusy = false;

                if (!ex.Message.Contains("The request was aborted: The request was canceled."))
                {
                    MessageBox.Show("Unexpected error: " + ex.Message,
                        "Async Await Demo", MessageBoxButton.OK, MessageBoxImage.Error);

                }
            }
        }
        void Completed(string tag, object data)
        {
            
            this.Dispatcher.Invoke((Action)(() =>
            {
                if (tag == SalingManagement_WebServiceTag.TAG_GETALL_M_PRODUCTINFO)
                {
                    _vm.LstProductInfo = JsonConvert.DeserializeObject<ObservableCollection<M_ProductInfo>>(data.ToString());
                    DataContext = null;
                    DataContext = _vm;
                    this.gvListProduct.ItemsSource = _vm.LstProductInfo;

                    ListCollectionView collectionView = new ListCollectionView(_vm.LstProductInfoWithImportInfo);
                    collectionView.GroupDescriptions.Add(new PropertyGroupDescription("Supplier"));
                    collectionView.SortDescriptions.Add(new SortDescription("Supplier", ListSortDirection.Ascending));
                    this.gvImportList.ItemsSource = collectionView;
                    this.UpdateLayout();
                    CallServiceCount--;
                }
                if(tag==SalingManagement_WebServiceTag.TAG_GETALL_M_SUPPLIERINFO)
                {
                    _vm.LstSupplierInfo = JsonConvert.DeserializeObject<ObservableCollection<M_Supplier>>(data.ToString());
                    DataContext = null;
                    DataContext = _vm;
                    CallServiceCount--;
                }
                if(tag==SalingManagement_WebServiceTag.TAG_INSERT_T_IMPORTPRODUCTINFO)
                {
                    CallServiceCount--;
                }
                if (CallServiceCount <= 0)
                    this.busyIndicator.IsBusy = false;
            }));
            
        }

        void Failed(string tag, string data)
        {
            this.Dispatcher.Invoke((Action)(() =>
            {
                MessageBox.Show(data);
                CallServiceCount--;
                if (CallServiceCount <= 0)
                    this.busyIndicator.IsBusy = false;
            }));
            
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox cb = sender as ComboBox;
            if (cb.SelectedValue != null&& this.gvImportList.SelectedItem!=null)
            {
                int selectedIndex = this.gvImportList.Items.IndexOf(this.gvImportList.SelectedItem);
                M_ProductInfoWithImportInfo selectedItem = this.gvImportList.SelectedItem as M_ProductInfoWithImportInfo;
                foreach(M_ProductInfoWithImportInfo item in _vm.LstProductInfoWithImportInfo)
                {
                    if (item.ProductID.Equals(selectedItem.ProductID))
                    {
                        if(item.Supplier!=null && item.Supplier.Equals(cb.SelectedValue.ToString()))
                        {
                            cb.SelectedValue = null;
                            return;
                        }    
                    }
                }
                _vm.LstProductInfoWithImportInfo[_vm.LstProductInfoWithImportInfo.IndexOf(selectedItem)].Supplier
                    = cb.SelectedValue.ToString();
                ListCollectionView collectionView = new ListCollectionView(_vm.LstProductInfoWithImportInfo);
                collectionView.GroupDescriptions.Add(new PropertyGroupDescription("Supplier"));
                collectionView.SortDescriptions.Add(new SortDescription("Supplier", ListSortDirection.Ascending));
                this.gvImportList.ItemsSource = collectionView;
            }
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox tb = sender as TextBox;
            M_ProductInfoWithImportInfo selectedItem = this.gvImportList.SelectedItem as M_ProductInfoWithImportInfo;
            _vm.LstProductInfoWithImportInfo[_vm.LstProductInfoWithImportInfo.IndexOf(selectedItem)].Import_Quantity 
                = tb.Text.ToString().Trim().Equals("")?0: int.Parse(tb.Text.ToString());
        }
    }
}
