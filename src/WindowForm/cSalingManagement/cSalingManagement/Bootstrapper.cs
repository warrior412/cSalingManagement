using cSalingManagement.View;
using Microsoft.Practices.Unity;
using Prism.Modularity;
using Prism.Regions;
using Prism.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace cSalingManagement
{
    public class Bootstrapper : UnityBootstrapper
    {
        protected override DependencyObject CreateShell()
        {
            return Container.Resolve<MainView>();
        }
        protected override void InitializeShell()
        {
            base.InitializeShell();

            App.Current.MainWindow = (Window)this.Shell;
            App.Current.MainWindow.Show();
        }

        protected override void ConfigureModuleCatalog()
        {
            ModuleCatalog moduleCatalog = (ModuleCatalog)this.ModuleCatalog;
            
            moduleCatalog.AddModule(typeof(TitleModule.TitleModule));
            moduleCatalog.AddModule(typeof(MenuModule.MenuModule));
            moduleCatalog.AddModule(typeof(NewRequestModule.NewRequestModule));
            moduleCatalog.AddModule(typeof(OrderModule.OrderModule), InitializationMode.OnDemand);
            moduleCatalog.AddModule(typeof(ProductModule.ProductModule), InitializationMode.OnDemand);
            moduleCatalog.AddModule(typeof(CustomerModule.CustomerModule), InitializationMode.OnDemand);
        }

        protected override void ConfigureContainer()
        {
            //Container.RegisterType<IHelpDeskRepository, HelpDeskXMLRepository>();
            //Container.RegisterType<IEmployeeService, EmployeeService>(new ContainerControlledLifetimeManager());

            //Container.RegisterType<RequestViewModel>();
            //Container.RegisterType<RequestDetail>();

            base.ConfigureContainer();
            this.Container.RegisterType(typeof(IRegionNavigationService), typeof(RegionNavigationService));
        }
    }
}
