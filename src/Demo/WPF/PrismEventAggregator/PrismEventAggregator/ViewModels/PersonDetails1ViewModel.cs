using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Microsoft.Practices.Prism.PubSubEvents;
using PrismEventAggregator.Models;
using Microsoft.Practices.Prism.Commands;
namespace PrismEventAggregator.ViewModels
{
	public class PersonDetails1ViewModel: INotifyPropertyChanged
	{

		#region Instance Properties

		public Person Person {
			
			get
			{ 
				return this.persionDetails;
			}	
			set
			{ 
				if(this.persionDetails!=value)
				{ 
					this.persionDetails = value;
					this.NotifyPropertyChanged("Person");
				}
			}
		
		}

		public ICommand Unsubscribe { get; set; }

		public ICommand Subscribe { get; set; }

		#endregion

		#region Constructors

		public PersonDetails1ViewModel(IEventAggregator iEventAggregator)
		{ 
			this.iEventAggregator = iEventAggregator;
			SubscriptionToken subscriptionToken =
									this
										.iEventAggregator
										.GetEvent<PubSubEvent<Person>>()
										.Subscribe((details) =>
										{
											this.Person = details;
										});

			this.Subscribe = new DelegateCommand(
			() =>
			{
				subscriptionToken =
					this
						.iEventAggregator
						.GetEvent<PubSubEvent<Person>>()
						.Subscribe((details) =>
						{
							this.Person = details;
						});
			});

			this.Unsubscribe = new DelegateCommand(
				() => {

					this
						.iEventAggregator
						.GetEvent<PubSubEvent<Person>>()
						.Unsubscribe(subscriptionToken);		
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
