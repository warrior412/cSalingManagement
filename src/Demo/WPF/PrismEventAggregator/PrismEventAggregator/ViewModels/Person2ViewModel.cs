using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Prism.PubSubEvents;
using PrismEventAggregator.Models;

namespace PrismEventAggregator.ViewModels
{

	public class Person2ViewModel : INotifyPropertyChanged
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
				if (this.personDetails != value)
				{
					this.personDetails = value;
					this.NotifyPropertyChanged("PersonDetails");
				}
			}
		}

		public Person SelectedPerson
		{
			get
			{
				return this.selectedPerson;
			}
			set
			{
				if (this.selectedPerson != value)
				{
					this.selectedPerson = value;
					this.NotifyPropertyChanged("SelectedPerson");
					this
						.iEventAggregator
						.GetEvent<PubSubEvent<Person>>()
						.Publish(this.SelectedPerson);
				}
			}
		}

		#endregion

		#region Constructors

		public Person2ViewModel(IEventAggregator iEventAggregator)
		{
			this.iEventAggregator = iEventAggregator;
			this.PersonDetails = new List<Person>();
			this.PersonDetails.Add(new Person() { Address = "Vizag", Name = "Pavan", Id = 1, Photo = "/PrismEventAggregator;component/Resources/Images/img1.jpg" });
			this.PersonDetails.Add(new Person() { Address = "Vijayawada", Name = "Mahesh", Id = 2, Photo = "/PrismEventAggregator;component/Resources/Images/img2.jpg" });
			this.PersonDetails.Add(new Person() { Address = "Nellore", Name = "Srinivas", Id = 3, Photo = "/PrismEventAggregator;component/Resources/Images/img3.jpg" });
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
