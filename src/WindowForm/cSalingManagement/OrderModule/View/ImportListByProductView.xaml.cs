using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace OrderModule.View
{
    /// <summary>
    /// Interaction logic for ImportListByProductView.xaml
    /// </summary>
    public partial class ImportListByProductView : Window
    {
        private string productID;

        public string ProductID
        {
            get { return productID; }
            set { productID = value; }
        }
        public ImportListByProductView()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }
    }
}
