using cSalingmanagement.Webservice;
using cSalingManagement.Common;
using cSalingManagement.Infrastructure.Common;
using cSalingManagement.Infrastructure.Model;
using Microsoft.Practices.Unity;
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
using System.Windows.Input;

namespace ProductModule.ViewModel
{
    public class ProductDetailViewModel : BindableBase
    {
        #region Private Properties
        public ProductDetailView view = null;
        private int CallServiceCount = 0;
        private M_CategoryInfo selectedCategoryInfo;

        public M_CategoryInfo SelectedCategoryInfo
        {
            get { return selectedCategoryInfo; }
            set { SetProperty(ref this.selectedCategoryInfo, value); }
        }
        private ObservableCollection<M_CategoryInfo> lstCategoryInfo = new ObservableCollection<M_CategoryInfo>();

        public ObservableCollection<M_CategoryInfo> LstCategoryInfo
        {
            get { return lstCategoryInfo; }
            set { SetProperty(ref this.lstCategoryInfo, value); }
        }

        private M_ProductInfoWithImportInfo productDetail = new M_ProductInfoWithImportInfo();

        public M_ProductInfoWithImportInfo ProductDetail
        {
            get { return productDetail; }
            set { SetProperty(ref this.productDetail,value); }
        }

        private ObservableCollection<M_ProductInfoWithImportInfo> lstProductWithImport = new ObservableCollection<M_ProductInfoWithImportInfo>();

        public ObservableCollection<M_ProductInfoWithImportInfo> LstProductWithImport
        {
            get { return lstProductWithImport; }
            set { SetProperty(ref this.lstProductWithImport, value); }
        }

        private string newProductImage;

        public string NewProductImage
        {
            get { return newProductImage; }
            set { SetProperty(ref this.newProductImage, value); }
        }

        private bool isEditing;

        public bool IsEditing
        {
            get { return isEditing; }
            set { SetProperty(ref this.isEditing, value); }
        }

        private bool isBusy;

        public bool IsBusy
        {
            get { return isBusy; }
            set { SetProperty(ref this.isBusy, value); }
        } 
        #endregion
        public ProductDetailViewModel(IRegionManager regionManager, IModuleManager moduleManager, IUnityContainer container)
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

        #region Command Declaration
        public ICommand ProductDetailCommand
        {
            get
            {
                return new DelegateCommand(openProductDetailView);
            }
        }
        public ICommand BrowseCommand
        {
            get
            {
                return new DelegateCommand(browseImage);
            }
        }

        public ICommand UpdateCommand
        {
            get
            {
                return new DelegateCommand(doUpdate);
            }
        }
        public ICommand FinishCommand
        {
            get
            {
                return new DelegateCommand(doFinish);
            }
        } 
        #endregion

        #region Command Excution Method
        private void doUpdate()
        {
            IsEditing = true;
        }
        private void doFinish()
        {
            //Insert new product
            if (this.ProductDetail.ProductID == null || this.ProductDetail.ProductID.Equals(""))
            {
                if (this.NewProductImage == null || this.NewProductImage.Equals(""))
                {
                    this.InsertNewProduct();
                    return;
                }
                this.UploadImage();
                return;
            }

            //Update product
            if(this.NewProductImage==null||this.NewProductImage.Equals(""))
            {
                this.UpdateProductDetail();
                return;
            }
            this.UploadImage();
        }
        private void openProductDetailView()
        {
            this.RegionManager.Regions[SalingManagementConstant.STRING_REGION_CONTENT].RequestNavigate(SalingManagementConstant.STRING_VIEW_PRODUCT_DETAIL);
        }
        private void browseImage()
        {
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();



            // Set filter for file extension and default file extension 
            dlg.DefaultExt = ".png";
            dlg.Filter = "JPG Files (*.jpg)|*.jpeg|PNG Files (*.png)|*.png|JPEG Files (*.jpeg)|*.jpg|GIF Files (*.gif)|*.gif";


            // Display OpenFileDialog by calling ShowDialog method 
            Nullable<bool> result = dlg.ShowDialog();


            // Get the selected file name and display in a TextBox 
            if (result == true)
            {
                // Open document 
                string filename = dlg.FileName;
                NewProductImage = filename;
            }
        } 
        #endregion

        public void UploadImage()
        {
            IsBusy = true;
            CallServiceCount++;
            DAOProvider dao = DAOProvider.GetInstance();
            dao.CallBackComplete = new DAOProvider.FinishCompleted(Completed);
            dao.CallBackFail = new DAOProvider.FinishFail(Failed);
            dao.PostImageToServer(this.NewProductImage);
        }
        public void UpdateProductDetail()
        {
            IsBusy = true;
            CallServiceCount++;
            DAOProvider dao = DAOProvider.GetInstance();
            dao.CallBackComplete = new DAOProvider.FinishCompleted(Completed);
            dao.CallBackFail = new DAOProvider.FinishFail(Failed);
            dao.UpdateM_ProductInfo(this.ProductDetail);
        }
        public void InsertNewProduct()
        {
            IsBusy = true;
            CallServiceCount++;
            DAOProvider dao = DAOProvider.GetInstance();
            dao.CallBackComplete = new DAOProvider.FinishCompleted(Completed);
            dao.CallBackFail = new DAOProvider.FinishFail(Failed);
            dao.InsertM_ProductInfo(this.ProductDetail);
        }
        public void GetAllCategoryInfo()
        {
            IsBusy = true;
            CallServiceCount++;
            DAOProvider dao = DAOProvider.GetInstance();
            dao.CallBackComplete = new DAOProvider.FinishCompleted(Completed);
            dao.CallBackFail = new DAOProvider.FinishFail(Failed);
            dao.GetALL_M_CategoryInfo();
        }

        public void GetProductDetailByID(string productID)
        {
            IsBusy = true;
            CallServiceCount++;
            DAOProvider dao = DAOProvider.GetInstance();
            dao.CallBackComplete = new DAOProvider.FinishCompleted(Completed);
            dao.CallBackFail = new DAOProvider.FinishFail(Failed);
            dao.GetALL_M_ProductInfoWithImportData_ByProductID(productID);
        }

        #region Delegate CallBack Method
        void Completed(string tag, object data)
        {
            if (tag == SalingManagement_WebServiceTag.TAG_UPLOAD_IMAGES)
            {
                CallServiceCount--;
                this.ProductDetail.Pro_Image = data.ToString();
                if (this.ProductDetail.ProductID == null || this.ProductDetail.ProductID.Equals(""))
                    this.InsertNewProduct();
                else
                    this.UpdateProductDetail();
            }
            if (tag == SalingManagement_WebServiceTag.TAG_UPDATE_M_PRODUCTINFO)
            {
                CallServiceCount--;
                this.IsEditing = false;
                this.view.ShowMessage("Update successfully");
            }
            if (tag == SalingManagement_WebServiceTag.TAG_INSERT_M_PRODUCTINFO)
            {
                CallServiceCount--;
                this.IsEditing = false;
                this.view.ShowMessage("Insert successfully");
            }
            if (tag == SalingManagement_WebServiceTag.TAG_GETALL_M_CATEGORYINFO)
            {
                CallServiceCount--;
                LstCategoryInfo = new M_CategoryInfo().JSonToListCategory(data);
                if (ProductDetail != null && ProductDetail.ProductID!=null)
                {
                    SelectedCategoryInfo = LstCategoryInfo.Where(x => x.CategoryID.Equals(ProductDetail.Category)).FirstOrDefault();
                }

            }
            if (tag == SalingManagement_WebServiceTag.TAG_GETALL_M_PRODUCTINFO_BYID)
            {
                CallServiceCount--;
                LstProductWithImport = new M_ProductInfoWithImportInfo().JSonToListProductInfoWithImportInfo(data.ToString());
                ProductDetail = LstProductWithImport.FirstOrDefault();
                if(LstCategoryInfo!=null && LstCategoryInfo.Count>0)
                {
                    SelectedCategoryInfo = LstCategoryInfo.Where(x => x.CategoryID.Equals(ProductDetail.Category)).FirstOrDefault();
                }
            }
            if (CallServiceCount <= 0)
                IsBusy = false;
        }

        void Failed(string tag, string data)
        {
            if (tag == SalingManagement_WebServiceTag.TAG_UPLOAD_IMAGES)
            {
                CallServiceCount--;
            }
            if (CallServiceCount <= 0)
                IsBusy = false;
        }
        #endregion

        
    }
}
