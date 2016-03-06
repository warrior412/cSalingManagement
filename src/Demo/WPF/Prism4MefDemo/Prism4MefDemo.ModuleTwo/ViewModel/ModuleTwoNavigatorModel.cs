using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Input;
using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.ViewModel;
using Prism4MefDemo.Infrastructure.Data;
using Prism4MefDemo.Infrastructure.Models;
using Prism4MefDemo.ModuleTwo.Controllers;

namespace Prism4MefDemo.ModuleTwo.ViewModel
{
    [Export(typeof(ModuleTwoNavigatorModel))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class ModuleTwoNavigatorModel : NotificationObject
    {
        private ICommand showView;
        public ViewObjects ViewObjects { get; set; }

        [ImportingConstructor]
        public ModuleTwoNavigatorModel(IModuleController moduleController)
        {
            ViewObjects = moduleController.ViewObjects;
            showView = moduleController.ShowViewCommand;
        }

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

