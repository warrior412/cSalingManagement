using System.ComponentModel.Composition;
using System.Windows.Input;
using Microsoft.Practices.Prism.ViewModel;
using Prism4MefDemo.Infrastructure.Data;
using Prism4MefDemo.ModuleOne.Controllers;

namespace Prism4MefDemo.ModuleOne.ViewModel
{
    [Export(typeof(ModuleOneRibbonTabModel))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class ModuleOneRibbonTabModel : NotificationObject
    {
        private ICommand showView;

        [ImportingConstructor]
        public ModuleOneRibbonTabModel(IModuleController moduleController)
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
