using System.Windows;
using ConfigurationDialogExample.ViewModel;

namespace ConfigurationDialogExample
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();

            this.DataContext = new ConfigurationDialogViewModel();
        }
    }
}
