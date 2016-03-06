using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.Regions;
using Prism4MefDemo.Infrastructure.Data;
using Prism4MefDemo.Infrastructure.Models;

namespace Prism4MefDemo.ModuleTwo.Controllers
{
    [Export(typeof(IModuleController))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class ModuleController : IModuleController
    {

        [Import]
        public IRegionManager regionManager;

        [ImportingConstructor]
        public ModuleController()
        {
            ViewObjects = new ViewObjects
                              {
                                  new ViewObject
                                      {
                                          Section = "Module Two",
                                          Title = "View 3",
                                          View = "/View3"
                                      },
                                  new ViewObject
                                      {
                                          Section = "Module Two",
                                          Title = "View 4",
                                          View = "/View4"
                                      }
                              };
            ShowViewCommand = new DelegateCommand<ViewObject>(OnShowExecuted);
        }

        public DelegateCommand<ViewObject> ShowViewCommand { get; private set; }

        public ViewObjects ViewObjects { get; private set; }

        private void OnShowExecuted(ViewObject viewObject)
        {

            Uri viewNav = new Uri(viewObject.View, UriKind.Relative);
            regionManager.RequestNavigate(RegionNames.WorkspaceRegion, viewNav);

        }
    }
}
