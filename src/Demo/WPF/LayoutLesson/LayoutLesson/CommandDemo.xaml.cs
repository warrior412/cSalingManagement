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
    /// Interaction logic for CommandDemo.xaml
    /// </summary>
    public partial class CommandDemo : Window
    {
        public CommandDemo()
        {
            InitializeComponent();
            Clipboard.Clear();
        }

        private void CutCommand_CanExcute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = (txtBox != null) && (txtBox.SelectionLength > 0);
        }

        private void CutCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            txtBox.Cut();
        }

        private void PasteCommand_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = Clipboard.ContainsText();
        }

        private void PasteCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            txtBox.Paste();
        }

        
    }
}
