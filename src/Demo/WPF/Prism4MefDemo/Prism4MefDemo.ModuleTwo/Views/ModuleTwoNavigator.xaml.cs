using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.Practices.Prism.Regions;
using Prism4MefDemo.Infrastructure.Behaviour;
using Prism4MefDemo.Infrastructure.Models;
using Prism4MefDemo.ModuleTwo.ViewModel;

namespace Prism4MefDemo.ModuleTwo.Views
{
    /// <summary>
    /// Interaction logic for ModuleTwoNavigator.xaml
    /// </summary>
    [ViewExport(RegionName = RegionNames.NavigatorRegion)]
    [PartCreationPolicy(CreationPolicy.Shared)]
    [ViewSortHint("2")]

    public partial class ModuleTwoNavigator : UserControl
    {
        public ModuleTwoNavigator()
        {
            InitializeComponent();
        }

        [Import]
        public ModuleTwoNavigatorModel NavigationViewModel
        {
            get { return this.DataContext as ModuleTwoNavigatorModel; }
            set { this.DataContext = value; }
        }
    }
}
