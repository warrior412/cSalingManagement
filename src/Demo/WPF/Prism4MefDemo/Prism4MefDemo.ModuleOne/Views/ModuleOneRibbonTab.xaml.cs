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
using Prism4MefDemo.ModuleOne.ViewModel;

namespace Prism4MefDemo.ModuleOne.Views
{
    /// <summary>
    /// Interaction logic for ModuleOneRibbonTab.xaml
    /// </summary>
    [ViewExport(RegionName = RegionNames.RibbonRegion)]
    [PartCreationPolicy(CreationPolicy.Shared)]
    [ViewSortHint("1")]
    public partial class ModuleOneRibbonTab : RibbonTab
    {
        public ModuleOneRibbonTab()
        {
            InitializeComponent();
        }

        [Import]
        private ModuleOneRibbonTabModel ViewModel
        {
            get { return this.DataContext as ModuleOneRibbonTabModel; }
            set { this.DataContext = value; }
        }


       
    }
}
