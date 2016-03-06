using System.ComponentModel;
using System.Runtime.CompilerServices;
using Microsoft.Practices.Prism.PubSubEvents;
using PrismEventAggregator.Models;

namespace PrismEventAggregator.ViewModels
{

	public class PersonDetails2ViewModel : INotifyPropertyChanged
	{

		#region Instance Properties

		public Person Person
		{

			get
			{
				return this.persionDetails;
			}
			set
			{
				if (this.persionDetails != value)
				{
					this.persionDetails = value;
					this.NotifyPropertyChanged("Person");
				}
			}

		}

		#endregion

		#region Constructors

		public PersonDetails2ViewModel(IEventAggregator iEventAggregator)
		{
			this.iEventAggregator = iEventAggregator;
			this
				.iEventAggregator
				.GetEvent<PubSubEvent<Person>>()
				.Subscribe((details) =>
				{
					this.Person = details;
				});
		}

		#endregion

		#region INotifyPropertyChanged Implementation

		public event PropertyChangedEventHandler PropertyChanged;

		protected void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
		{
			if (PropertyChanged != null)
			{
				PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}

		#endregion

		#region Instance Fields

		private Person persionDetails;

		private IEventAggregator iEventAggregator;

		#endregion
	}

}
