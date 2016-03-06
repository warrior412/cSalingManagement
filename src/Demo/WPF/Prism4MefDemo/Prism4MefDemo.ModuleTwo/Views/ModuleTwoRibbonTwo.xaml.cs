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
using Microsoft.Windows.Controls.Ribbon;
using Prism4MefDemo.Infrastructure.Behaviour;
using Prism4MefDemo.Infrastructure.Models;
using Prism4MefDemo.ModuleTwo.ViewModel;

namespace Prism4MefDemo.ModuleTwo.Views
{
    /// <summary>
    /// Interaction logic for ModuleTwoRibbonTwo.xaml
    /// </summary>
    [ViewExport(RegionName = RegionNames.RibbonRegion)]
    [PartCreationPolicy(CreationPolicy.Shared)]
    [ViewSortHint("2")]
    public partial class ModuleTwoRibbonTwo : RibbonTab
    {

        public ModuleTwoRibbonTwo()
        {
            InitializeComponent();
        }

        [Import]
        public ModuleTwoRibbonTabModel NavigationViewModel
        {
            get { return this.DataContext as ModuleTwoRibbonTabModel; }
            set { this.DataContext = value; }
        }



        

    }
}
