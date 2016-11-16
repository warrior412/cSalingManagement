using cSalingmanagement.Webservice;
using cSalingManagement.Infrastructure.Common;
using cSalingManagement.Infrastructure.Model;
using Newtonsoft.Json;
using ProductModule.ViewModel;
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

namespace ProductModule.View
{
    /// <summary>
    /// Interaction logic for ProductImportRequestView.xaml
    /// </summary>
    public partial class ProductImportRequestView : UserControl
    {
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
            GetInitData();
        }
        public void GetInitData()
        {
            try
            {
                busyIndicator.IsBusy = true;
                DAOProvider dao = DAOProvider.GetInstance();
                dao.CallBackComplete = new DAOProvider.FinishCompleted(Completed);
                dao.CallBackFail = new DAOProvider.FinishFail(Failed);
                dao.GetALL_M_ProductInfoWithImportData();
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
                if (tag == SalingManagement_WebServiceTag.TAG_GETALL_M_PRODUCTINFOWITHIMPORTDATA)
                {
                    _vm.LstProductInfo = JsonConvert.DeserializeObject<ObservableCollection<M_ProductInfo>>(data.ToString());
                    DataContext = null;
                    DataContext = _vm;
                    this.gvListProduct.ItemsSource = _vm.LstProductInfo;

                    ListCollectionView collectionView = new ListCollectionView(_vm.LstProductInfoWithImportInfo);
                    collectionView.GroupDescriptions.Add(new PropertyGroupDescription("Supplier"));
                    this.gvImportList.ItemsSource = collectionView;
                    this.UpdateLayout();
                    busyIndicator.IsBusy = false;
                }
                if(tag==SalingManagement_WebServiceTag.TAG_GETALL_M_SUPPLIERINFO)
                {
                    _vm.LstSupplierInfo = JsonConvert.DeserializeObject<ObservableCollection<M_Supplier>>(data.ToString());
                    DataContext = null;
                    DataContext = _vm;
                }
            }));
        }

        void Failed(string tag, string data)
        {
            this.Dispatcher.Invoke((Action)(() =>
            {
                MessageBox.Show(data);
                busyIndicator.IsBusy = false;
            }));
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox cb = sender as ComboBox;
            if (cb.SelectedValue != null)
            {
                int selectedIndex = this.gvImportList.Items.IndexOf(this.gvImportList.SelectedItem);
                _vm.LstProductInfoWithImportInfo[selectedIndex].Supplier = cb.SelectedValue.ToString();
                ListCollectionView collectionView = new ListCollectionView(_vm.LstProductInfoWithImportInfo);
                collectionView.GroupDescriptions.Add(new PropertyGroupDescription("Supplier"));
                this.gvImportList.ItemsSource = collectionView;
            }
        }
    }
}
