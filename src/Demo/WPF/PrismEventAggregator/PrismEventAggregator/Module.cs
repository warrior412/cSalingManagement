using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.Prism.Regions;
using PrismEventAggregator.Views;

namespace PrismEventAggregator
{
	public class Module : IModule
	{

		#region Constructors
		
		public Module(IRegionManager iRegionManager)
		{ 
			this.iRegionManager = iRegionManager;
		}

		#endregion

		#region IModule Implementation

		public void Initialize()
		{ 
		
			this.iRegionManager.RegisterViewWithRegion("Person1",typeof(Person1));
			this.iRegionManager.RegisterViewWithRegion("Person1Details", typeof(PersonDetails1));
			this.iRegionManager.RegisterViewWithRegion("Person2", typeof(Person2));
			this.iRegionManager.RegisterViewWithRegion("Person2Details", typeof(PersonDetails2));

		}

		#endregion

		#region Instance Fields

		private IRegionManager iRegionManager;

		#endregion

	}
}
