using cSalingmanagement.Webservice;
using cSalingManagement.Common;
using cSalingManagement.Infrastructure.Common;
using cSalingManagement.Infrastructure.Model;
using Microsoft.Practices.Unity;
using Newtonsoft.Json;
using Prism.Commands;
using Prism.Modularity;
using Prism.Mvvm;
using Prism.Regions;
using ProductModule.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;

namespace ProductModule.ViewModel
{
    public class ProductListViewModel : BindableBase
    {
        private int CallServiceCount = 0;

        public ProductListView view = null;
        private ObservableCollection<M_ProductInfoWithImportInfo_Row> lstProductInfo =
            new ObservableCollection<M_ProductInfoWithImportInfo_Row>();

        public ObservableCollection<M_ProductInfoWithImportInfo_Row> LstProductInfo
        {
            get { return lstProductInfo; }
            set { 
                SetProperty(ref this.lstProductInfo, value);
                this.collectionView = new ListCollectionView(this.LstProductInfo);
                collectionView.GroupDescriptions.Add(new PropertyGroupDescription("Category"));

                this.view.Dispatcher.Invoke(new Action(()=>{
                    view.gvCheckInfo.ItemsSource = this.collectionView;
                }));

            }
        }

        private ObservableCollection<M_ProductInfoWithImportInfo_Row> lstCart = new ObservableCollection<M_ProductInfoWithImportInfo_Row>();

        public ObservableCollection<M_ProductInfoWithImportInfo_Row> LstCart
        {
            get { return lstCart; }
            set { SetProperty(ref this.lstCart, value); }
        }


        private ListCollectionView collectionView;

        public ListCollectionView CollectionView
        {
            get { return collectionView; }
            set {SetProperty(ref this.collectionView ,value); }
        }
        

        private ObservableCollection<M_Supplier> lstSupplierInfo = new ObservableCollection<M_Supplier>();

        public ObservableCollection<M_Supplier> LstSupplierInfo
        {
            get { return lstSupplierInfo; }
            set { SetProperty(ref this.lstSupplierInfo, value); }
        }

        private bool isLoading;

        public bool IsLoading
        {
            get { return isLoading; }
            set { SetProperty(ref this.isLoading, value); }
        }

        private string text;

        public string Text
        {
            get { return text; }
            set { text = value; }
        }
        public ProductListViewModel(IRegionManager regionManager, IModuleManager moduleManager, IUnityContainer container)
        {
            this.RegionManager = regionManager;
            this.ModuleManager = moduleManager;
            this.UnityContainer = container;
        }



        #region Public Properties
        public IRegionManager RegionManager { get; set; }
        public IUnityContainer UnityContainer { get; set; }
        public IModuleManager ModuleManager { get; set; }
        #endregion

        public ICommand ProductDetailCommand
        {
            get
            {
                return new DelegateCommand<object>(openProductDetailView);
            }
        }

        public ICommand AddCartCommand
        {
            get
            {
                return new DelegateCommand<object>(doAddCart);
            }
        }

        public ICommand RemoveCartCommand
        {
            get
            {
                return new DelegateCommand<object>(doRemoveCart);
            }
        }

        public ICommand GoToCartCommand
        {
            get
            {
                return new DelegateCommand<object>(doGoToCartCommand);
            }
        }

        private void doGoToCartCommand(object param)
        {
            var navigationParameters = new NavigationParameters();
            navigationParameters.Add("ListOrder", this.LstCart);
            RegionManager.RequestNavigate(SalingManagementConstant.STRING_REGION_CONTENT,
                 new Uri(SalingManagementConstant.STRING_VIEW_ORDER_ADD, UriKind.Relative),navigationParameters);
        }

        private void doRemoveCart(object param)
        {
            DataGrid dgv = param as DataGrid;
            M_ProductInfoWithImportInfo_Row selectedRow = dgv.SelectedItem as M_ProductInfoWithImportInfo_Row;
            this.LstProductInfo[this.LstProductInfo.IndexOf(selectedRow)].IsAddedToCard = false;
            this.LstProductInfo = this.LstProductInfo;
            this.LstCart.Remove(selectedRow);
        }

        private void doAddCart(object param)
        {
            DataGrid dgv = param as DataGrid;
            M_ProductInfoWithImportInfo_Row selectedRow = dgv.SelectedItem as M_ProductInfoWithImportInfo_Row;
            this.LstProductInfo[this.LstProductInfo.IndexOf(selectedRow)].IsAddedToCard = true;
            this.LstProductInfo = this.LstProductInfo;
            this.LstCart.Add(selectedRow);
        }
        private void openProductDetailView(object productID)
        {
            if (productID == null)
                return;
            var navigationParameters = new NavigationParameters();
            navigationParameters.Add("ProductID", productID.ToString());
            RegionManager.RequestNavigate(SalingManagementConstant.STRING_REGION_CONTENT,
                 new Uri(SalingManagementConstant.STRING_VIEW_PRODUCT_DETAIL + navigationParameters.ToString(), UriKind.Relative));
        }


        public void GetInitData()
        {
            try
            {
                this.IsLoading = true;
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
                this.IsLoading = false;

            }
        }

        void Completed(string tag, object data)
        {
            if (tag == SalingManagement_WebServiceTag.TAG_GETALL_M_PRODUCTINFOWITHIMPORTDATA)
            {
                CallServiceCount--;
                this.LstProductInfo = JsonConvert.DeserializeObject<ObservableCollection<M_ProductInfoWithImportInfo_Row>>(data.ToString());
                //ListCollectionView collectionView = new ListCollectionView(_vm.LstProductInfo);
                //collectionView.GroupDescriptions.Add(new PropertyGroupDescription("ProductID"));
                //this.gvCheckInfo.ItemsSource = collectionView;

            }
            if (tag == SalingManagement_WebServiceTag.TAG_GETALL_M_SUPPLIERINFO)
            {
                this.LstSupplierInfo = JsonConvert.DeserializeObject<ObservableCollection<M_Supplier>>(data.ToString());
                CallServiceCount--;
            }
            if (CallServiceCount <= 0)
            {
                this.IsLoading = false;
            }
        }

        void Failed(string tag, string data)
        {
            //MessageBox.Show(data);
            this.IsLoading = false;
        }
    }
}
