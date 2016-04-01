using cSalingManagement.Resources;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using cSalingManagement.Infrastructure;
using cSalingManagement.Common;
using cSalingManagement.Infrastructure.Common;
using cSalingManagement.Properties;

namespace cSalingManagement
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            initialApplication();
            base.OnStartup(e);
            //Bootstrapper bootStrapper = new Bootstrapper();
            //bootStrapper.Run();
        }

        private void initialApplication()
        {
            SalingManagementCommonFunction.GetInstance().CurrentLanguage = Settings.Default.Display_Language;
            SalingManagementCommonFunction.GetInstance().BindingLanguageResourceFile();
        }
    }
}
