using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Runtime.CompilerServices;
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
using Prism4MefDemo.ModuleOne.ViewModel;

namespace Prism4MefDemo.ModuleOne.Views
{
    /// <summary>
    /// Interaction logic for ModuleOneNavigator.xaml
    /// </summary>
    [ViewExport(RegionName = RegionNames.NavigatorRegion)]
    [PartCreationPolicy(CreationPolicy.Shared)]
    [ViewSortHint("1")]

    public partial class ModuleOneNavigator : UserControl
    {

        public ModuleOneNavigator()
        {
            InitializeComponent();
        }

        [Import]
        public ModuleOneNavigatorModel NavigationViewModel
        {
            get { return this.DataContext as ModuleOneNavigatorModel; }
            set { this.DataContext = value; }
        }

 
    }
}
