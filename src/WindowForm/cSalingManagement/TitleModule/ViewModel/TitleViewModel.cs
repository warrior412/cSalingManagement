
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
using System.Windows;
using System.Windows.Input;

namespace TitleModule.ViewModel
{
    public class TitleViewModel:BindableBase
    {
        public TitleViewModel(IRegionManager regionManager, IModuleManager moduleManager, IUnityContainer container)
        {
            this.RegionManager = regionManager;
            this.ModuleManager = moduleManager;
            this.UnityContainer = container;
        }

        #region Public Properties
        public IRegionManager RegionManager { get; set; }
        public IUnityContainer UnityContainer { get; set; }
        public IModuleManager ModuleManager { get; set; }
        #endregion

        #region Command
        public ICommand CloseCommand
        {
            get
            {
                return new DelegateCommand(CloseCommandExecute);
            }
        }
        public ICommand ExpandCommand
        {
            get
            {
                return new DelegateCommand(ExpandCommandExecute);
            }
        }
        public ICommand MinimizedCommand
        {
            get
            {
                return new DelegateCommand(MinimizedCommandExecute);
            }
        }
        #endregion

        #region Delegate Method
        public void CloseCommandExecute()
        {
            Application.Current.Shutdown();
        }
        public void ExpandCommandExecute()
        {
            if(Application.Current.MainWindow.WindowState== WindowState.Normal)
                Application.Current.MainWindow.WindowState = WindowState.Maximized;
            else
                Application.Current.MainWindow.WindowState = WindowState.Normal;
        }
        public void MinimizedCommandExecute()
        {
            Application.Current.MainWindow.WindowState = WindowState.Minimized;
        } 
        #endregion
    }
}
