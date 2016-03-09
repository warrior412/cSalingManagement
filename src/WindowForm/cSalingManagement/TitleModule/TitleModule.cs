using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TitleModule.View;

namespace TitleModule
{
    public class TitleModule : IModule
    {
        private readonly IRegionManager regionManager;
        private readonly IUnityContainer container;


        public TitleModule(IUnityContainer container, IRegionManager regionManager)
        {
            this.container = container;
            this.regionManager = regionManager;

        }

        public void Initialize()
        {
            this.regionManager.RegisterViewWithRegion("TitleRegion",
                                                       () => this.container.Resolve<TitleView>());

        }
    }
}
