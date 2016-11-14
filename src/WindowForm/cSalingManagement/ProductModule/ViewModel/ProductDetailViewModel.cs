using cSalingManagement.Common;
using cSalingManagement.Infrastructure.Model;
using Microsoft.Practices.Unity;
using Prism.Commands;
using Prism.Modularity;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ProductModule.ViewModel
{
    public class ProductDetailViewModel : BindableBase
    {
        private ObservableCollection<M_CategoryInfo> lstCategoryInfo = new ObservableCollection<M_CategoryInfo>();

        public ObservableCollection<M_CategoryInfo> LstCategoryInfo
        {
            get { return lstCategoryInfo; }
            set { lstCategoryInfo = value; }
        }

        private M_ProductInfoWithImportInfo productDetail = null;

        public M_ProductInfoWithImportInfo ProductDetail
        {
            get { return productDetail; }
            set { productDetail = value; }
        }
        private string text;

        public string Text
        {
            get { return text; }
            set { text = value; }
        }

        private string newProductImage;

        public string NewProductImage
        {
            get { return newProductImage; }
            set { SetProperty(ref this.newProductImage, value); }
        }

        private bool isAddNew;

        public bool IsAddNew
        {
            get { return isAddNew; }
            set { isAddNew = value; }
        }
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
    }
}
