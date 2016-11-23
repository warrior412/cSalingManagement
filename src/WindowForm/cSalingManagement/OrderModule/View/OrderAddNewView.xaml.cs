using cSalingManagement.Infrastructure.Model;
using OrderModule.ViewModel;
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

namespace OrderModule.View
{
    /// <summary>
    /// Interaction logic for OrderAddNewView.xaml
    /// </summary>
    public partial class OrderAddNewView : UserControl, INavigationAware
    {

        #region Navigation Region
        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return true;
        }

        public void OnNavigatedFrom(NavigationContext navigationContext)
        {
        }

        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            NavigationParameters param = navigationContext.Parameters;

            if(param["ListOrder"]!=null)
            {
                Vm.LstOrder = param["ListOrder"] as ObservableCollection<M_ProductInfoWithImportInfo_Row>;
            }
            if (param["CustomerID"] != null)
            {
                string customerID = param["CustomerID"].ToString();
                Vm.GetCustomerInfoByID(customerID);
                Vm.IsEditing = false;
            }
            else
            {
                Vm.IsEditing = true;
            }
            
        }
        #endregion



        private OrderAddNewViewModel _vm = null;

        public OrderAddNewViewModel Vm
        {
            get { return _vm; }
            set { _vm = value; }
        }

        public OrderAddNewView(OrderAddNewViewModel vm)
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

        private void cbWard_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cbWard.SelectedValue == null)
                return;
        }
    }
}
