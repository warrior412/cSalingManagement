using MenuModule.View;
using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MenuModule
{
    public class MenuViewModule : IModule
    {
        private readonly IRegionManager regionManager;
        private readonly IUnityContainer container;

        
        public MenuViewModule(IUnityContainer container, IRegionManager regionManager)
        {
            this.container = container;
            this.regionManager = regionManager;
            
        }

        public void Initialize()
        {
            this.regionManager.RegisterViewWithRegion("MenuRegion",
                                                       () => this.container.Resolve<MenuView>());

        }
        
    }
}
