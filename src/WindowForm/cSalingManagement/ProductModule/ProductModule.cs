
using cSalingManagement.Common;
using Microsoft.Practices.Unity;
using Prism.Modularity;
using Prism.Regions;
using ProductModule.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductModule
{
    public class ProductModule:IModule
    {
      private readonly IRegionManager regionManager;
        private readonly IUnityContainer container;


        public ProductModule(IUnityContainer container, IRegionManager regionManager)
        {
            this.container = container;
            this.regionManager = regionManager;
        }

        public void Initialize()
        {
        }
    }
}
