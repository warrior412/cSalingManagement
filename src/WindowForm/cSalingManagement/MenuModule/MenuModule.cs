using cSalingManagement.Common;
using MenuModule.View;
using Microsoft.Practices.Unity;
using OrderModule.View;
using Prism.Modularity;
using Prism.Regions;
using ProductModule.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MenuModule
{
    public class MenuModule:IModule
    {
        private readonly IRegionManager regionManager;
        private readonly IUnityContainer container;


        public MenuModule(IUnityContainer container, IRegionManager regionManager)
        {
            this.container = container;
            this.regionManager = regionManager;
            this.RegisterAllViewToContainer();
            
        }

        public void Initialize()
        {
            string temp = typeof(ProductDetailView).FullName;
            this.regionManager.RegisterViewWithRegion(SalingManagementConstant.STRING_REGION_MENU,
                                                       () => this.container.Resolve<MenuView>());

        }

        private void RegisterAllViewToContainer()
        {
            //NewRequest Module
            this.container.RegisterType(typeof(Object),
                typeof(NewRequestModule.View.NewRequestView),
                SalingManagementConstant.STRING_VIEW_NEW_REQUEST);
            //Product Module
            this.container.RegisterType(typeof(Object), 
                typeof(ProductDetailView), 
                SalingManagementConstant.STRING_VIEW_PRODUCT_DETAIL);
            this.container.RegisterType(typeof(Object), 
                typeof(ProductListView), 
                SalingManagementConstant.STRING_VIEW_PRODUCT_LIST);
            this.container.RegisterType(typeof(Object),
                typeof(ProductImportRequestView), 
                SalingManagementConstant.STRING_VIEW_PRODUCT_IMPORT_REQUEST);

            //Order Module
            this.container.RegisterType(typeof(Object), typeof(OrderAddNewView), SalingManagementConstant.STRING_VIEW_ORDER_ADD);
            this.container.RegisterType(typeof(Object), typeof(OrderListView), SalingManagementConstant.STRING_VIEW_ORDER_LIST);

            //Customer Module
            this.container.RegisterType(typeof(Object),typeof(CustomerModule.View.CustomerListView),SalingManagementConstant.STRING_VIEW_CUSTOMER_LIST);
            this.container.RegisterType(typeof(Object), typeof(CustomerModule.View.CustomerDetailView), SalingManagementConstant.STRING_VIEW_CUSTOMER_DETAIL);
        }
    }
}
