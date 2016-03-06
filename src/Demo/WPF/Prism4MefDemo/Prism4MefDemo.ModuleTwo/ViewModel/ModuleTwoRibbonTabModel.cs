using System.ComponentModel.Composition;
using System.Windows.Input;
using Microsoft.Practices.Prism.ViewModel;
using Prism4MefDemo.Infrastructure.Data;
using Prism4MefDemo.ModuleTwo.Controllers;

namespace Prism4MefDemo.ModuleTwo.ViewModel
{
    [Export(typeof(ModuleTwoRibbonTabModel))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class ModuleTwoRibbonTabModel : NotificationObject
    {
        private ICommand showView;

        [ImportingConstructor]
        public ModuleTwoRibbonTabModel(IModuleController moduleController)
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
