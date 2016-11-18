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
            _vm = vm;
            GetInitData();
        }
        
        public void GetInitData()
        {
            try
            {
                Vm.IsLoading = true;
                DAOProvider dao = DAOProvider.GetInstance();
                CallServiceCount++;
                dao.GetALL_M_ProductInfoWithImportData();
                CallServiceCount++;
                dao.GetALL_M_SupplierInfo();
                dao.CallBackComplete = new DAOProvider.FinishCompleted(Completed);
                dao.CallBackFail = new DAOProvider.FinishFail(Failed);
            }
            catch (Exception ex)
            {
                Vm.IsLoading  = false;

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
                if (tag == SalingManagement_WebServiceTag.TAG_GETALL_M_PRODUCTINFOWITHIMPORTDATA)
                {
                    CallServiceCount--;
                    _vm.LstProductInfo = JsonConvert.DeserializeObject<ObservableCollection<M_ProductInfoWithImportInfo>>(data.ToString());
                    _vm.Text = "text";
                    DataContext = _vm;
                    ListCollectionView collectionView = new ListCollectionView(_vm.LstProductInfo);
                    collectionView.GroupDescriptions.Add(new PropertyGroupDescription("ProductID"));
                    this.gvCheckInfo.ItemsSource = collectionView;
                    this.UpdateLayout();
                    
                }
                if (tag == SalingManagement_WebServiceTag.TAG_GETALL_M_SUPPLIERINFO)
                {
                    _vm.LstSupplierInfo = JsonConvert.DeserializeObject<ObservableCollection<M_Supplier>>(data.ToString());
                    DataContext = null;
                    DataContext = _vm;
                    CallServiceCount--;
                }
                if(CallServiceCount<=0)
                {
                    Vm.IsLoading = false;
                }
            }));
        }

        void Failed(string tag, string data)
        {
            this.Dispatcher.Invoke((Action)(() =>
            {
                MessageBox.Show(data);
                Vm.IsLoading = false;
            }));
        }




        
    }
}
