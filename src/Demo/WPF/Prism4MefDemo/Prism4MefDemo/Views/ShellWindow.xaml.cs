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
using Microsoft.Windows.Controls.Ribbon;
using Prism4MefDemo.ViewModel;

namespace Prism4MefDemo
{
    /// <summary>
    /// Interaction logic for ShellWindow.xaml
    /// </summary>
    [Export]
    public partial class ShellWindow : RibbonWindow
    {
        public ShellWindow()
        {
            InitializeComponent();

            // Insert code required on object creation below this point.
        }

        [Import]
        private ShellWindowModel ViewModel
        {
            get { return this.DataContext as ShellWindowModel; }
            set { this.DataContext = value; }
        }
    }
}
