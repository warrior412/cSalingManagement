using cSalingManagement.Common;
using Microsoft.Practices.Unity;
using OrderModule.View;
using Prism.Modularity;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderModule
{
    public class OrderModule:IModule
    {
        #region Public Properties
        public IRegionManager RegionManager { get; set; }
        public IUnityContainer UnityContainer { get; set; }
        public IModuleManager ModuleManager { get; set; }
        #endregion


        public OrderModule(IRegionManager regionManager, IModuleManager moduleManager, IUnityContainer container)
        {
            this.UnityContainer = container;
            this.RegionManager = regionManager;
            this.ModuleManager = moduleManager;
        }

        public void Initialize()
        {

            this.RegionManager.RegisterViewWithRegion(SalingManagementConstant.STRING_REGION_CONTENT,
                                                      () => this.UnityContainer.Resolve<OrderModule>());
        }
    }
}
