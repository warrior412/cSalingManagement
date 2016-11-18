using cSalingmanagement.Webservice;
using cSalingManagement.Infrastructure.Common;
using cSalingManagement.Infrastructure.Model;
using NewRequestModule.ViewModel;
using Newtonsoft.Json;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace NewRequestModule.View
{
    /// <summary>
    /// Interaction logic for NewRequestView.xaml
    /// </summary>
    public partial class NewRequestView : UserControl, INavigationAware
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

        private NewRequestViewModel _vm = null;

        public NewRequestViewModel Vm
        {
            get { return _vm; }
            set
            {
                _vm = value;
            }
        }

        public NewRequestView(NewRequestViewModel vm)
        {
            InitializeComponent();
            _vm = vm;
            _vm.view = this;
            GetInitData();
        }

        public void GetInitData()
        {
            try
            {
                
                busyIndicator.IsBusy = true;
                DAOProvider dao = DAOProvider.GetInstance();
                CallServiceCount++;
                dao.GetAll_M_ProductInfoWithImportInfo_OnWaiting();
                CallServiceCount++;
                dao.GetALL_M_SupplierInfo();
                dao.CallBackComplete = new DAOProvider.FinishCompleted(Completed);
                dao.CallBackFail = new DAOProvider.FinishFail(Failed);
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
        public void UpdateImportList(ObservableCollection<NewRequestView_ImportList_Row> lstImport)
        {
            busyIndicator.IsBusy = true;
            DAOProvider dao = DAOProvider.GetInstance();
            CallServiceCount++;
            dao.Update_T_ImportProduct(lstImport);
            dao.CallBackComplete = new DAOProvider.FinishCompleted(Completed);
            dao.CallBackFail = new DAOProvider.FinishFail(Failed);
        }

        public void ShowMessageBox(string message)
        {
            MessageBox.Show(message);
        }
        public bool ShowMessageBoxConfirm(string message)
        {
            return MessageBox.Show(message,"Xác nhận",MessageBoxButton.OKCancel) == MessageBoxResult.OK?true:false;
        }

        #region Delegate Callback Methods
        void Completed(string tag, object data)
        {

            this.Dispatcher.Invoke((Action)(() =>
            {
                if (tag == SalingManagement_WebServiceTag.TAG_GETALL_M_PRODUCTINFOWITHIMPORTDATA_ONWAITING)
                {
                    CallServiceCount--;
                    _vm.LstProductInfo = JsonConvert.DeserializeObject<ObservableCollection<NewRequestView_ImportList_Row>>(data.ToString());
                    DataContext = _vm;
                    this.UpdateLayout();
                    
                }
                if (tag == SalingManagement_WebServiceTag.TAG_GETALL_M_SUPPLIERINFO)
                {
                    _vm.LstSupplierInfo = JsonConvert.DeserializeObject<ObservableCollection<M_Supplier>>(data.ToString());
                    DataContext = null;
                    DataContext = _vm;
                    CallServiceCount--;
                }
                if(tag == SalingManagement_WebServiceTag.TAG_UPDATE_T_IMPORTPRODUCT)
                {
                    CallServiceCount--;
                    MessageBox.Show("Xác nhận thay đổi thành công!");
                }
                if(CallServiceCount<=0)
                    busyIndicator.IsBusy = false;
            }));
        }

        void Failed(string tag, string data)
        {
            this.Dispatcher.Invoke((Action)(() =>
            {
                MessageBox.Show(data);
                CallServiceCount--;
                if (CallServiceCount <= 0)
                    busyIndicator.IsBusy = false;
            }));
        } 
        #endregion
    }
}
