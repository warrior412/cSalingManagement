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

namespace ProductModule.View
{
    /// <summary>
    /// Interaction logic for InputDialogView.xaml
    /// </summary>
    public partial class InputDialogView : Window
    {
        public string result = "";
        public InputDialogView()
        {
            InitializeComponent();
            this.txtInput.Focus();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if(this.txtInput.Text.Length<=0)
            {
                this.DialogResult = false;
                return;
            }
            result = this.txtInput.Text;
            this.DialogResult = true;
        }

        private void txtInput_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                int temp = int.Parse(this.txtInput.Text);
            }catch (Exception ex)
            {
                TextChange change = e.Changes.ElementAt(0);
                String s = new String(txtInput.Text.ToCharArray(), 0, txtInput.Text.Length == 0 ? 0 : txtInput.Text.Length - 1);
                txtInput.Text = s.ToString();
                txtInput.SelectAll();
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }
    }
}
