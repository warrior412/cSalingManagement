using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.Unity;
using Module1.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module1
{
    public class Module1:IModule
    {

        private readonly IRegionManager regionManager;
        private readonly IUnityContainer container;
        public Module1(IUnityContainer container, IRegionManager regionManager)
        {
            this.container = container;
            this.regionManager = regionManager;
        }

        public void Initialize()
        {
            var view = this.container.Resolve<View.Module1View>();
            this.regionManager.Regions["ModuleRegion"].Add(view, "Module1View");
            this.regionManager.Regions["ModuleRegion"].Add(view, "SubModule1View");

        }
    }
}
