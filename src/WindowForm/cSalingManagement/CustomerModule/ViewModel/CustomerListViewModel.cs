using cSalingmanagement.Webservice;
using cSalingManagement.Common;
using cSalingManagement.Infrastructure.Common;
using cSalingManagement.Infrastructure.Model;
using CustomerModule.View;
using Microsoft.Practices.Unity;
using Newtonsoft.Json;
using Prism.Commands;
using Prism.Modularity;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CustomerModule.ViewModel
{
    public class CustomerListViewModel : BindableBase
    {
        private int CallServiceCount = 0;
        public CustomerListView view = null;

        private ObservableCollection<M_Customer> lstCustomer = new ObservableCollection<M_Customer>();

        public ObservableCollection<M_Customer> LstCustomer
        {
            get { return lstCustomer; }
            set { SetProperty(ref this.lstCustomer, value); }
        }

        private ObservableCollection<M_City> lstCityInfo = new ObservableCollection<M_City>();

        public ObservableCollection<M_City> LstCityInfo
        {
            get { return lstCityInfo; }
            set { SetProperty(ref this.lstCityInfo, value); }
        }
        private ObservableCollection<M_District> lstDistrictInfo = new ObservableCollection<M_District>();

        public ObservableCollection<M_District> LstDistrictInfo
        {
            get { return lstDistrictInfo; }
            set { SetProperty(ref this.lstDistrictInfo, value); }
        }
        private ObservableCollection<M_Ward> lstWardInfo = new ObservableCollection<M_Ward>();

        public ObservableCollection<M_Ward> LstWardInfo
        {
            get { return lstWardInfo; }
            set { SetProperty(ref this.lstWardInfo, value); }
        }

        private bool isBusy;

        public bool IsBusy
        {
            get { return isBusy; }
            set { SetProperty(ref this.isBusy, value); }
        } 

        public CustomerListViewModel(IRegionManager regionManager, IModuleManager moduleManager, IUnityContainer container)
        {
            this.RegionManager = regionManager;
            this.ModuleManager = moduleManager;
            this.UnityContainer = container;
        }

        public ICommand CustomerDetailCommand
        {
            get
            {
                return new DelegateCommand<object>(doEditCustomer);
            }
        }
        
        private void doEditCustomer(object param)
        {
            if (param == null)
                return;
            string customerID = param.ToString();
            var navigationParameters = new NavigationParameters();
            navigationParameters.Add("CustomerID", customerID);
            RegionManager.RequestNavigate(SalingManagementConstant.STRING_REGION_CONTENT,
                 new Uri(SalingManagementConstant.STRING_VIEW_CUSTOMER_DETAIL + navigationParameters.ToString(), UriKind.Relative));
        }

        #region Process Method

        public void GetInitData()
        {
            GetALLCustomerInfo();
            GetALLCity();
            GetALLDistrict();
            GetALLWard();
        }
        private void GetALLCustomerInfo()
        {
            CallServiceCount++;
            IsBusy = true;
            DAOProvider dao = DAOProvider.GetInstance();
            dao.CallBackComplete = new DAOProvider.FinishCompleted(Completed);
            dao.CallBackFail = new DAOProvider.FinishFail(Failed);
            dao.GetAll_M_CustomerInfo();
        }
        private void GetALLCity()
        {
            CallServiceCount++;
            IsBusy = true;
            DAOProvider dao = DAOProvider.GetInstance();
            dao.CallBackComplete = new DAOProvider.FinishCompleted(Completed);
            dao.CallBackFail = new DAOProvider.FinishFail(Failed);
            dao.GetALL_M_CityInfo();
        }
        private void GetALLDistrict()
        {
            CallServiceCount++;
            IsBusy = true;
            DAOProvider dao = DAOProvider.GetInstance();
            dao.CallBackComplete = new DAOProvider.FinishCompleted(Completed);
            dao.CallBackFail = new DAOProvider.FinishFail(Failed);
            dao.GetALL_M_DistrictInfo();
        }
        private void GetALLWard()
        {
            CallServiceCount++;
            IsBusy = true;
            DAOProvider dao = DAOProvider.GetInstance();
            dao.CallBackComplete = new DAOProvider.FinishCompleted(Completed);
            dao.CallBackFail = new DAOProvider.FinishFail(Failed);
            dao.GetALL_M_WardInfo();
        } 
        #endregion

        #region Public Properties
        public IRegionManager RegionManager { get; set; }
        public IUnityContainer UnityContainer { get; set; }
        public IModuleManager ModuleManager { get; set; }
        #endregion

        #region Delegate CallBack Method
        void Completed(string tag, object data)
        {
            if (tag == SalingManagement_WebServiceTag.TAG_GETALL_M_CUSTOMERINFO)
            {
                CallServiceCount--;
                this.LstCustomer = JsonConvert.DeserializeObject<ObservableCollection<M_Customer>>(data.ToString());
            }
            if (tag == SalingManagement_WebServiceTag.TAG_GETALL_M_CITYINFO)
            {
                CallServiceCount--;
                this.LstCityInfo = JsonConvert.DeserializeObject<ObservableCollection<M_City>>(data.ToString());
            }
            if (tag == SalingManagement_WebServiceTag.TAG_GETALL_M_DISTRICTINFO)
            {
                CallServiceCount--;
                this.LstDistrictInfo = JsonConvert.DeserializeObject<ObservableCollection<M_District>>(data.ToString());
            }
            if (tag == SalingManagement_WebServiceTag.TAG_GETALL_M_WARDINFO)
            {
                CallServiceCount--;
                this.LstWardInfo = JsonConvert.DeserializeObject<ObservableCollection<M_Ward>>(data.ToString());
            }
            if (CallServiceCount <= 0)
                IsBusy = false;
        }

        void Failed(string tag, string data)
        {
            this.view.ShowMessage(data);
            CallServiceCount--;
            if (CallServiceCount <= 0)
                IsBusy = false;
        }
        #endregion
    }
}
