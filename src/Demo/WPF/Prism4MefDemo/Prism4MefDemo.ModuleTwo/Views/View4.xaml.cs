﻿using System;
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

namespace Prism4MefDemo.ModuleTwo.Views
{
    /// <summary>
    /// Interaction logic for View4.xaml
    /// </summary>
    [Export("View4")]
    [PartCreationPolicy(CreationPolicy.Shared)]
    public partial class View4 : UserControl
    {
        public View4()
        {
            InitializeComponent();
        }
    }
}
