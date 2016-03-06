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

namespace LayoutLesson
{
    /// <summary>
    /// Interaction logic for frmInputValue.xaml
    /// </summary>
    public partial class frmInputValue : Window
    {
        public frmInputValue()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int temp = int.Parse(txtResult.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Invalid value!");
                return;
            }
            DialogResult = true;
        }
    }
}
