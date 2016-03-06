using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module2
{
    public class Module2:IModule
    {
        private readonly IRegionManager regionManager;
        private readonly IUnityContainer container;
        public Module2(IUnityContainer container, IRegionManager regionManager)
        {
            this.container = container;
            this.regionManager = regionManager;
        }

        public void Initialize()
        {
            var view = this.container.Resolve<View.Module2View>();
            this.regionManager.Regions["ModuleRegion"].Add(view, "Module2View");

        }
    }
}
