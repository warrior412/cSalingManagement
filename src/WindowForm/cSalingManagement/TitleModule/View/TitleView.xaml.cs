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
using System.Windows.Navigation;
using System.Windows.Shapes;
using TitleModule.ViewModel;

namespace TitleModule.View
{
    /// <summary>
    /// Interaction logic for TitleView.xaml
    /// </summary>
    public partial class TitleView : UserControl
    {
        public TitleView(TitleViewModel vm)
        {
            InitializeComponent();
            DataContext = vm;
        }

        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if(e.ChangedButton== MouseButton.Left)
            {
                Window parentWindow = Application.Current.MainWindow;
                parentWindow.DragMove();
            }
        }
    }
}
