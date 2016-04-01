using NewRequestModule.ViewModel;
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

namespace NewRequestModule.View
{
    /// <summary>
    /// Interaction logic for NewRequestView.xaml
    /// </summary>
    public partial class NewRequestView : UserControl
    {
        public NewRequestView()
        {
            InitializeComponent();
            DataContext = new NewRequestViewModel();
        }
    }
}
