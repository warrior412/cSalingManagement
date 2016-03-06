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
using Prism4MefDemo.Infrastructure.Behaviour;
using Prism4MefDemo.Infrastructure.Models;

namespace Prism4MefDemo.Views
{
    /// <summary>
    /// Interaction logic for HomeView.xaml
    /// </summary>
    [Export("HomeView")]
    [ViewExport(RegionName = RegionNames.WorkspaceRegion)]
    [PartCreationPolicy(CreationPolicy.Shared)]
    public partial class HomeView : UserControl
    {
        public HomeView()
        {
            InitializeComponent();
        }
    }
}
