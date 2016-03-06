using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Input;
using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.Prism.ViewModel;
using Prism4MefDemo.Infrastructure.Data;
using Prism4MefDemo.Infrastructure.Models;

namespace Prism4MefDemo.ViewModel
{
    [Export(typeof(HomeNavigatorModel))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class HomeNavigatorModel : NotificationObject
    {
        private ICommand showView;
        public ViewObjects ViewObjects { get; set; }

        [Import]
        public IRegionManager regionManager;


        [ImportingConstructor]
        public HomeNavigatorModel()
        {
            ViewObjects = new ViewObjects
                              {
                                  new ViewObject
                                      {
                                          Section = "Home",
                                          Title = "Home View",
                                          View = "/HomeView"
                                      }
                              };


            ShowView = new DelegateCommand<ViewObject>(OnShowExecuted);
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

        private void OnShowExecuted(ViewObject viewObject)
        {

            Uri viewNav = new Uri(viewObject.View, UriKind.Relative);
            regionManager.RequestNavigate(RegionNames.WorkspaceRegion, viewNav);

        }
    }
}
