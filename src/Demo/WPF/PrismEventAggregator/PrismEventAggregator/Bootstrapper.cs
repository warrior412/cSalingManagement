using System.Windows;
using Microsoft.Practices.Prism.UnityExtensions;
using Microsoft.Practices.Prism.Modularity;
namespace PrismEventAggregator
{
	public class Bootstrapper : UnityBootstrapper
	{

		#region UnityBootstrapper Implementation

		protected override DependencyObject CreateShell()
		{
 			return new Shell();
		}

		protected override void InitializeShell()
		{ 
			App.Current.MainWindow = (Window)this.Shell;
			App.Current.MainWindow.Show();
		}

		protected override void ConfigureModuleCatalog()
		{ 
			ModuleCatalog moduleCatalog = (ModuleCatalog)this.ModuleCatalog;
 			moduleCatalog.AddModule(typeof(Module));
		}

		#endregion

	}
}
