using LayoutLesson.Class;
using LayoutLesson.XML;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Windows.Shapes;
using System.Xml.Linq;

namespace LayoutLesson
{
    /// <summary>
    /// Interaction logic for TbaleList.xaml
    /// </summary>
    public partial class TbaleList : Window
    {
        public TbaleList()
        {
            InitializeComponent();
           record= XMLTool.loadDataFromXMLFile();
            this.DataContext = record;
            this.gvCheckInfo.ItemsSource = record.CheckInfos;
            //Sort CheckInfos by IsCheck
            ICollectionView dataView = CollectionViewSource.GetDefaultView(this.gvCheckInfo.ItemsSource);
            dataView.SortDescriptions.Clear();
            dataView.SortDescriptions.Add(new SortDescription("IsCheck", ListSortDirection.Descending));
            dataView.Refresh();
        }
        public Record record { get; set; }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            record.CheckInfos[0].IsCheck = true;
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            CheckInfo info = ((FrameworkElement)sender).DataContext as CheckInfo;
            record.CheckInfos[record.CheckInfos.IndexOf(info)].IsCheck = false;
        }

        private void CheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            CheckInfo info = ((FrameworkElement)sender).DataContext as CheckInfo;
            record.CheckInfos[record.CheckInfos.IndexOf(info)].IsCheck = true;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            //まだ終わりません。
            if (this.gvCheckInfo.SelectedIndex > -1)
            {
                CheckInfo info = (CheckInfo)this.gvCheckInfo.SelectedItem;
                record.CheckInfos[record.CheckInfos.IndexOf(info)].Resolved = true;
            }
        }
       
       
    }
    
}
