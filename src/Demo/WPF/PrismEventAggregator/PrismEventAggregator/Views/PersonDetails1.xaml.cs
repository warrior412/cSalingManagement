using System;
using System.Collections.Generic;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using PrismEventAggregator.Models;
using PrismEventAggregator.ViewModels;

namespace PrismEventAggregator.Views
{
	/// <summary>
	/// Interaction logic for PersonDetails1.xaml
	/// </summary>
	public partial class PersonDetails1 : UserControl
	{
		public PersonDetails1()
		{
			InitializeComponent();
			this.DataContext = new  PersonDetails1ViewModel(Event.EventInstance.EventAggregator);
		}
	}
}
