using cSalingManagement.Common;
using Microsoft.Practices.Unity;
using NewRequestModule.View;
using Prism.Modularity;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewRequestModule
{
    public class NewRequestModule:IModule
    {
        private readonly IRegionManager regionManager;
        private readonly IUnityContainer container;


        public NewRequestModule(IUnityContainer container, IRegionManager regionManager)
        {
            this.container = container;
            this.regionManager = regionManager;
        }

        public void Initialize()
        {
            this.regionManager.RegisterViewWithRegion(SalingManagementConstant.STRING_REGION_CONTENT,
                                                      () => this.container.Resolve<NewRequestView>());
        }
    }
}
