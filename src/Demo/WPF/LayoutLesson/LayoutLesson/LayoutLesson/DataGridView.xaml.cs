using LayoutLesson.Class;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public ObservableCollection<CheckInfo> CheckInfos { get; set; }
        public Window1()
        {
            InitializeComponent();
            
            createCheckInfoList();
            this.DataContext = CheckInfos;
        }
        private void createCheckInfoList()
        {
            this.CheckInfos = new ObservableCollection<CheckInfo>();
            string[] arrName = { "Eyes", "Heart", "Blood", "Measures", "Lung", "Hearing", "X-Ray", "CT" };
            Random random = new Random();
            for (int i = 0; i < arrName.Length; i++)
            {
                CheckInfo info = new CheckInfo();
                info.CheckName = arrName[i];
                info.IsCheck = true;
                info.OldResult = randomFloatValue(random);
                info.NewResult = randomFloatValue(random);
                info.Average = (info.OldResult + info.NewResult) / 2;
                this.CheckInfos.Add(info);
            }
        }
        private float randomFloatValue(Random random)
        {
            double mantissa = (random.NextDouble() * 2.0) - 1.0;
            double exponent = Math.Pow(2.0, random.Next(-126, 128));
            return (float)(mantissa * exponent);
            
        }
    }
}
