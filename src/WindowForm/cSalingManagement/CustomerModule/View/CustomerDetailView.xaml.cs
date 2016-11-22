using cSalingManagement.Infrastructure.Model;
using CustomerModule.ViewModel;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace CustomerModule.View
{
    /// <summary>
    /// Interaction logic for CustomerDetailView.xaml
    /// </summary>
    public partial class CustomerDetailView : UserControl, INavigationAware
    {
        #region Navigation Region
        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return false;
        }

        public void OnNavigatedFrom(NavigationContext navigationContext)
        {
        }

        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            var param = navigationContext.Parameters;
            if (param["CustomerID"] == null)
            {
                Vm.IsEditing = true;
                return;
            }
            string customerID = param["CustomerID"].ToString();
            Vm.GetCustomerInfoByID(customerID);
            Vm.IsEditing = false;
        }
        #endregion


        private CustomerDetailViewModel _vm = null;

        public CustomerDetailViewModel Vm
        {
            get { return _vm; }
            set
            {
                _vm = value;
            }
        }

        public CustomerDetailView(CustomerDetailViewModel vm)
        {
            InitializeComponent();
            vm.GetInitData();
            vm.view = this;
            _vm = vm;
            DataContext = _vm;
        }

        public void ShowMessage(string message)
        {
            MessageBox.Show(message);
        }

        #region Control Event Raise
        private void cbCity_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cbCity.SelectedValue == null)
                return;
            string selectedCity = cbCity.SelectedValue.ToString();
            ObservableCollection<M_District> lstDistrictByCity = new ObservableCollection<M_District>();
            foreach (M_District district in Vm.LstDistrictInfo)
            {
                if (selectedCity.Equals(district.City))
                    lstDistrictByCity.Add(district);
            }
            this.cbDistrict.ItemsSource = lstDistrictByCity;
            this.cbDistrict.DisplayMemberPath = "District_Name";
            this.cbDistrict.SelectedValuePath = "DistrictID";
        }

        private void cbWard_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cbWard.SelectedValue == null)
                return;
        }

        private void cbDistrict_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cbDistrict.SelectedValue == null)
            {
                cbWard.ItemsSource = null;
                return;
            }

            string selectedDistrict = cbDistrict.SelectedValue.ToString();
            ObservableCollection<M_Ward> lstWardByDistrict = new ObservableCollection<M_Ward>();
            foreach (M_Ward ward in Vm.LstWardInfo)
            {
                if (selectedDistrict.Equals(ward.District))
                    lstWardByDistrict.Add(ward);
            }
            this.cbWard.ItemsSource = lstWardByDistrict;
            this.cbWard.DisplayMemberPath = "Ward_Name";
            this.cbWard.SelectedValuePath = "WardID";
        } 
        #endregion
    }
}
