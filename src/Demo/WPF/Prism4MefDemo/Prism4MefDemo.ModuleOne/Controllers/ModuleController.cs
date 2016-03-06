using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.Regions;
using Prism4MefDemo.Infrastructure.Data;
using Prism4MefDemo.Infrastructure.Models;

namespace Prism4MefDemo.ModuleOne.Controllers
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
                                          Section = "Module One",
                                          Title = "View 1",
                                          View = "/View1"
                                      },
                                  new ViewObject
                                      {
                                          Section = "Module One",
                                          Title = "View 2",
                                          View = "/View2"
                                      }
                              };
            ShowViewCommand = new DelegateCommand<ViewObject>(OnShowExecuted);
        }

        public DelegateCommand<ViewObject> ShowViewCommand { get; private set; }

        public ViewObjects ViewObjects { get; private set; }

        /// <summary>
        /// Showing the selected view in the Workspace Region
        /// </summary>
        /// <param name="viewObject">View object that has been selected in the binding</param>
        private void OnShowExecuted(ViewObject viewObject)
        {

            Uri viewNav = new Uri(viewObject.View, UriKind.Relative);
            regionManager.RequestNavigate(RegionNames.WorkspaceRegion, viewNav);

        }
    }
}
