using System;
using System.Collections.Generic;
using System.ComponentModel;
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

namespace DemoUserControl
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        MyPopup pop = new MyPopup();
        public MainWindow()
        {
            InitializeComponent();

            DataContext =pop;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            pop.IsOpen = true;
        }
    }
    public class MyPopup:INotifyPropertyChanged
    {
        private bool isOpen;

        public bool IsOpen
        {
            get { return isOpen; }
            set 
            { 
                isOpen = value;
                OnPropertyChanged("IsOpen");
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string propertyname)
        {
            if(this.PropertyChanged!=null)
            {
                this.PropertyChanged(this,new PropertyChangedEventArgs(propertyname));
            }
        }

    }
}
