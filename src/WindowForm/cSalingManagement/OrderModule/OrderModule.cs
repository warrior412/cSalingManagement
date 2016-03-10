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
        private readonly IRegionManager regionManager;
        private readonly IUnityContainer container;


        public OrderModule(IUnityContainer container, IRegionManager regionManager)
        {
            this.container = container;
            this.regionManager = regionManager;
        }

        public void Initialize()
        {
            var view = this.container.Resolve<OrderDetailView>();
            this.regionManager.Regions["ContentRegion"].Add(view, "OrderDetailView");
            
        }
    }
}
