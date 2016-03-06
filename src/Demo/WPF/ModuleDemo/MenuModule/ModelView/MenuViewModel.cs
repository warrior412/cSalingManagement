using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MenuModule.ModelView
{
    public class MenuViewModel
    {
        private DelegateCommand loadModule1Command;

        public DelegateCommand LoadModule1Command
        {
            get { return loadModule1Command; }
        }



        private DelegateCommand loadModule2Command;

        public DelegateCommand LoadModule2Command
        {
            get { return loadModule2Command; }
        }



        private DelegateCommand loadSubModule1Command;

        public DelegateCommand LoadSubModule1Command
        {
            get { return loadSubModule1Command; }
        }



        private bool canLoadSoftwareModule()
        {
            return true;
        }

        private void loadModule1()
        {
            // LoadModule method is responsible to load and initialize the module
            // It loads only if module is not initialize already.
            ModuleManager.LoadModule("Module1");
            var requestInfoRegion = RegionManager.Regions["ModuleRegion"];
            var newView = requestInfoRegion.GetView("Module1View");
            // As RequestInfoRegion uses ContentControlRegionAdapter so at a time only one view will be activated.
            requestInfoRegion.Activate(newView);
        }
        private void loadSubModule1()
        {
            // LoadModule method is responsible to load and initialize the module
            // It loads only if module is not initialize already.
            ModuleManager.LoadModule("Module1");
            var requestInfoRegion = RegionManager.Regions["ModuleRegion"];
            var newView = requestInfoRegion.GetView("SubModule1View");
            // As RequestInfoRegion uses ContentControlRegionAdapter so at a time only one view will be activated.
            requestInfoRegion.Activate(newView);
        }
        private void loadModule2()
        {
            // LoadModule method is responsible to load and initialize the module
            // It loads only if module is not initialize already.
            ModuleManager.LoadModule("Module2");
            var requestInfoRegion = RegionManager.Regions["ModuleRegion"];
            var newView = requestInfoRegion.GetView("Module2View");
            // As RequestInfoRegion uses ContentControlRegionAdapter so at a time only one view will be activated.
            requestInfoRegion.Activate(newView);
        }

        public MenuViewModel(IRegionManager regionManager, IModuleManager moduleManager, IUnityContainer container)
        {
            this.RegionManager = regionManager;
            this.ModuleManager = moduleManager;
            this.UnityContainer = container;
            loadModule1Command = new DelegateCommand(loadModule1, canLoadSoftwareModule);
            loadModule2Command = new DelegateCommand(loadModule2, canLoadSoftwareModule);
            loadSubModule1Command = new DelegateCommand(loadSubModule1, canLoadSoftwareModule);
        }
        #region Public Properties
        public IRegionManager RegionManager { get; set; }
        public IUnityContainer UnityContainer { get; set; }
        public IModuleManager ModuleManager { get; set; }
        #endregion
    }
}
