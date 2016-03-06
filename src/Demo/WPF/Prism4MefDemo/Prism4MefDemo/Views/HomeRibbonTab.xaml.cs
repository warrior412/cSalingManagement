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
using Prism4MefDemo.ViewModel;

namespace Prism4MefDemo.Views
{
    /// <summary>
    /// Interaction logic for HomeRibbonTab.xaml
    /// </summary>
    [ViewExport(RegionName = RegionNames.RibbonRegion)]
    [PartCreationPolicy(CreationPolicy.Shared)]
    [ViewSortHint("0")]
    public partial class HomeRibbonTab : RibbonTab
    {
        public HomeRibbonTab()
        {
            InitializeComponent();
        }

        [Import]
        private HomeNavigatorModel ViewModel
        {
            get { return this.DataContext as HomeNavigatorModel; }
            set { this.DataContext = value; }
        }
    }
}
