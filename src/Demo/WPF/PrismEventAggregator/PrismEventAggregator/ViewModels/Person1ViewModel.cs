using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using PrismEventAggregator.Models;
using Microsoft.Practices.Prism.PubSubEvents;
namespace PrismEventAggregator.ViewModels
{
	public class Person1ViewModel : INotifyPropertyChanged
	{

		#region Instance Properties

		public List<Person> PersonDetails 
		{   
			get
			{ 
				return this.personDetails;
			}
			set
			{ 
				if(this.personDetails != value)
				{ 
					this.personDetails = value;
					this.NotifyPropertyChanged("PersonDetails");
				}
			}
		}

		public Person SelectedPerson { 
			get
			{ 
				return this.selectedPerson; 
			}
			set
			{ 
				if(this.selectedPerson!=value)
				{ 
					this.selectedPerson = value;
					this.NotifyPropertyChanged("SelectedPerson");

					// Publish event.
					this
						.iEventAggregator
						.GetEvent<PubSubEvent<Person>>()
						.Publish(this.SelectedPerson);
				}
			}
		}

		#endregion

		#region Constructors

		public Person1ViewModel(IEventAggregator iEventAggregator)
		{ 
			this.iEventAggregator = iEventAggregator;
			this.PersonDetails = new List<Person>();
			this.PersonDetails.Add(new Person() { Address = "Hyderabad", Name = "Hari", Id = 1, Photo = "/PrismEventAggregator;component/Resources/Images/img_chania.jpg" });
			this.PersonDetails.Add(new Person() { Address = "Guntur", Name = "Murali", Id = 2, Photo = "/PrismEventAggregator;component/Resources/Images/img_chania2.jpg" });
			this.PersonDetails.Add(new Person() { Address = "Ongole", Name = "Varun", Id = 3, Photo = "/PrismEventAggregator;component/Resources/Images/img_flower2.jpg" });
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

		private List<Person> personDetails;

		private Person selectedPerson;

		private IEventAggregator iEventAggregator;

		#endregion

	}
}
