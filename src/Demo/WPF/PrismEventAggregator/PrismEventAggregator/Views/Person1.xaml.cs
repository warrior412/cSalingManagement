using System.Windows.Controls;
using PrismEventAggregator.Models;
using PrismEventAggregator.ViewModels;

namespace PrismEventAggregator.Views
{
	/// <summary>
	/// Interaction logic for Person1.xaml
	/// </summary>
	public partial class Person1 : UserControl
	{
		public Person1()
		{
			InitializeComponent();
			this.DataContext = new Person1ViewModel(Event.EventInstance.EventAggregator);
		}
	}
}
