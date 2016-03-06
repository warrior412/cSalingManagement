using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace MultiLanguageDemo
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static void BindingResourceFile  (string lang)
        {
            ResourceDictionary rs = new ResourceDictionary();
            rs.Source = new Uri("..\\Resources\\" + lang + ".xaml", UriKind.Relative);
            App.Current.Resources.MergedDictionaries.Add(rs);
        }
    }
}
