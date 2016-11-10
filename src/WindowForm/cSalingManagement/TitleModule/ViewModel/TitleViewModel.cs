
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
using cSalingManagement.Infrastructure;
using cSalingManagement.Common;

namespace TitleModule.ViewModel
{
    public class TitleViewModel:BindableBase
    {
        private bool isMaximized = false;
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
            if (!isMaximized)
            {
                
                Application.Current.MainWindow.Top = 0;
                Application.Current.MainWindow.Left = 0;
                Application.Current.MainWindow.Height = System.Windows.Forms.Screen.PrimaryScreen.WorkingArea.Height;
                Application.Current.MainWindow.Width = System.Windows.Forms.Screen.PrimaryScreen.WorkingArea.Width;
                isMaximized = true;
            }
            else
            {
                Application.Current.MainWindow.Height = SalingManagementConstant.Application_Height;
                Application.Current.MainWindow.Width = SalingManagementConstant.Applicaton_Width;
                Application.Current.MainWindow.Top = 0;
                Application.Current.MainWindow.Left = 
                    (System.Windows.Forms.Screen.PrimaryScreen.WorkingArea.Width -SalingManagementConstant.Applicaton_Width)/2  ;
                isMaximized = false;
            }
        }
        public void MinimizedCommandExecute()
        {
            Application.Current.MainWindow.WindowState = WindowState.Minimized;
        } 
        #endregion
    }
}
