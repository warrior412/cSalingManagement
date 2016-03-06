//  --------------------------------
//  Copyright (c) Huy Pham. All rights reserved.
//  This source code is made available under the terms of the Microsoft Public License (Ms-PL)
//  http://www.opensource.org/licenses/ms-pl.html
//  ---------------------------------

using System.Collections.Generic;
using System.Windows.Input;
using ExpandingMenu.HelperClasses;
using ExpandingMenu.Models;

namespace ExpandingMenu
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MainWindow"/> class.
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;

            Categories = Data.Data.LoadData();
        }

        /// <summary>
        /// Gets or sets the categories.
        /// </summary>
        /// <value>The categories.</value>
        public List<Category> Categories { get; set; }

        /// <summary>
        /// Gets the open imdb link command.
        /// </summary>
        public ICommand OpenImdbLinkCommand
        {
            get
            {
                return new DelegateCommand<object>(OpenImdbLink);
            }
        }

        /// <summary>
        /// Opens the imdb link.
        /// </summary>
        /// <param name="obj">The imdb link.</param>
        private static void OpenImdbLink(object obj)
        {
            var navigateUri = obj as string;

            if (!string.IsNullOrEmpty(navigateUri))
            {
                System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo(navigateUri));
            }
        }
    }
}