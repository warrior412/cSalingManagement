using cSalingManagement.Common;
using cSalingManagement.Model;
using Microsoft.Practices.Unity;
using Prism.Commands;
using Prism.Modularity;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MenuModule.ViewModel
{
    public class MenuViewModel:BindableBase
    {
        public List<MenuItem> MenuItems { get; set; }

        #region Private Fields

        #endregion


        public MenuViewModel(IRegionManager regionManager, IModuleManager moduleManager, IUnityContainer container)
        {
            this.RegionManager = regionManager;
            this.ModuleManager = moduleManager;
            this.UnityContainer = container;
            this.MenuItems = SalingManagementConstant.MenuItems;
        }



        #region Public Properties
        public IRegionManager RegionManager { get; set; }
        public IUnityContainer UnityContainer { get; set; }
        public IModuleManager ModuleManager { get; set; }
        #endregion


        #region Command
        public ICommand MenuItemClickCommand
        {
            get
            {
                return new DelegateCommand<object>(openContentModule);
            }
        }
        #endregion



        #region Private Methods
        private void openContentModule(object param)
        {
            if (param == null)
                return;

            cSalingManagement.Model.Action action = param as cSalingManagement.Model.Action;
            // LoadModule method is responsible to load and initialize the module
            // It loads only if module is not initialize already.
            ModuleManager.LoadModule(action.ModuleName);
            var requestInfoRegion = RegionManager.Regions[action.RegionName];
            var newView = requestInfoRegion.GetView(action.ViewName);
            // As RequestInfoRegion uses ContentControlRegionAdapter so at a time only one view will be activated.
            requestInfoRegion.Activate(newView);
        }
        #endregion
    }
}
