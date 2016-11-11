using cSalingManagement.Common;
using cSalingManagement.Infrastructure.Model;
using Microsoft.Practices.Unity;
using Prism.Commands;
using Prism.Modularity;
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
    public class ProductDetailViewModel
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

        private void openProductDetailView()
        {
            this.RegionManager.Regions[SalingManagementConstant.STRING_REGION_CONTENT].RequestNavigate(SalingManagementConstant.STRING_VIEW_PRODUCT_DETAIL);
        }
    }
}
