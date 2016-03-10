using cSalingManagement.Common;
using MenuModule.View;
using Microsoft.Practices.Unity;
using Prism.Modularity;
using Prism.Regions;
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
            
        }

        public void Initialize()
        {
            this.regionManager.RegisterViewWithRegion(SalingManagementConstant.STRING_REGION_MENU,
                                                       () => this.container.Resolve<MenuView>());

        }
    }
}
