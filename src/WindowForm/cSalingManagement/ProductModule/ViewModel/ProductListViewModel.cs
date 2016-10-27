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
    public class ProductListViewModel:BindableBase
    {
        private ObservableCollection<MProductInfo> lstProductInfo= new ObservableCollection<MProductInfo>();

        public ObservableCollection<MProductInfo> LstProductInfo
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
                return new DelegateCommand(openProductDetailView);
            }
        }

        private void openProductDetailView()
        {
            this.RegionManager.Regions[SalingManagementConstant.STRING_REGION_CONTENT].RequestNavigate(SalingManagementConstant.STRING_VIEW_PRODUCT_DETAIL);
        }
    }
}
