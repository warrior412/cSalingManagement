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

namespace Prism4MefDemo.ModuleOne.Views
{
    /// <summary>
    /// Interaction logic for View2.xaml
    /// </summary>
    [Export("View2")]
    [PartCreationPolicy(CreationPolicy.Shared)]
    public partial class View2 : UserControl
    {
        public View2()
        {
            InitializeComponent();
        }
    }
}
