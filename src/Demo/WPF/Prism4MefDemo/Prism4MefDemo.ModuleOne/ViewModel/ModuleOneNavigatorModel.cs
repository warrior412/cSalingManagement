using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Input;
using Microsoft.Practices.Prism;
using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.Prism.ViewModel;
using Prism4MefDemo.Infrastructure.Data;
using Prism4MefDemo.Infrastructure.Models;
using Prism4MefDemo.ModuleOne.Controllers;

namespace Prism4MefDemo.ModuleOne.ViewModel
{
    [Export(typeof(ModuleOneNavigatorModel))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class ModuleOneNavigatorModel : NotificationObject
    {
        private ICommand showView;

        [ImportingConstructor]
        public ModuleOneNavigatorModel(IModuleController moduleController)
        {
            ViewObjects = moduleController.ViewObjects;
            showView = moduleController.ShowViewCommand;
        }

        public ViewObjects ViewObjects { get; set; }

        public ICommand ShowView
        {
            get { return showView; }
            set
            {
                if (showView != value)
                {
                    showView = value;
                    RaisePropertyChanged("ShowView");
                }
            }
        }

       
    }
}
