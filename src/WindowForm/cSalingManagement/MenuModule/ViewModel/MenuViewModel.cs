using cSalingManagement.Common;
using cSalingManagement.Infrastructure.Common;
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
        private int _requestNumber;

        public int RequestNumber
        {
            get { return _requestNumber; }
            set { _requestNumber = value; }
        }
        #endregion


        public MenuViewModel(IRegionManager regionManager, IModuleManager moduleManager, IUnityContainer container)
        {
            this.RegionManager = regionManager;
            this.ModuleManager = moduleManager;
            this.UnityContainer = container;
            this.MenuItems = SalingManagementCommonFunction.GetInstance().GetListMenuItem();
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

        public ICommand NewRequestCommand
        {
            get
            {
                return new DelegateCommand(openNewRequestModule);
            }
        }
        public ICommand HideCommand
        {
            get
            {
                return new DelegateCommand(hideContent);
            }
        }
        #endregion



        #region Private Methods
        private void openContentModule(object param)
        {
            if (param == null)
                return;

            

            cSalingManagement.Model.Action action = param as cSalingManagement.Model.Action;
            var navigationParameters = new NavigationParameters();
            navigationParameters.Add("IsInit", true);
            RegionManager.RequestNavigate(SalingManagementConstant.STRING_REGION_CONTENT,
                 new Uri(action.ViewName + navigationParameters.ToString(), UriKind.Relative));


            //// LoadModule method is responsible to load and initialize the module
            //// It loads only if module is not initialize already.
            //ModuleManager.LoadModule(action.ModuleName);
            //var requestInfoRegion = RegionManager.Regions[action.RegionName];
            //var newView = requestInfoRegion.GetView(action.ViewName);
            //// As RequestInfoRegion uses ContentControlRegionAdapter so at a time only one view will be activated.
            //requestInfoRegion.Activate(newView);
        }
        private void openNewRequestModule()
        {
            this.RegionManager.Regions[SalingManagementConstant.STRING_REGION_CONTENT].RequestNavigate(SalingManagementConstant.STRING_VIEW_NEW_REQUEST);
        }

        private void hideContent()
        {

        }
        #endregion
    }
}
