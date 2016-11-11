using cSalingManagement.Common;
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
using System.Windows.Input;

namespace ProductModule.ViewModel
{
    public class ProductListViewModel : BindableBase
    {
        private ObservableCollection<M_ProductInfo> lstProductInfo = new ObservableCollection<M_ProductInfo>();

        public ObservableCollection<M_ProductInfo> LstProductInfo
        {
            get { return lstProductInfo; }
            set { lstProductInfo = value; }
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

        private void openProductDetailView(object productID)
        {
            if (productID == null)
                return;
            var navigationParameters = new NavigationParameters();
            navigationParameters.Add("ProductID", productID.ToString());
            RegionManager.RequestNavigate(SalingManagementConstant.STRING_REGION_CONTENT,
                 new Uri(SalingManagementConstant.STRING_VIEW_PRODUCT_DETAIL + navigationParameters.ToString(), UriKind.Relative));
        }
    }
}
