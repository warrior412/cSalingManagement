using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.Prism.Regions;


namespace simpleprismapplicationmodule
{
    public class simpleprismapplicationmodule:IModule
    {
        private readonly IRegionManager regionManager;
        public simpleprismapplicationmodule(IRegionManager regionManager)
        {
            this.regionManager = regionManager;
          
        }

        public void Initialize()
        {
            regionManager.RegisterViewWithRegion("MainRegion", typeof(View.simpleprismapplicationview));
        }
    }
}
