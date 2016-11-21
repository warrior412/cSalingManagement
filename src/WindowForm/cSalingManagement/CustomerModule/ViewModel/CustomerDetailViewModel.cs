using cSalingmanagement.Webservice;
using cSalingManagement.Infrastructure.Common;
using cSalingManagement.Infrastructure.Model;
using Microsoft.Practices.Unity;
using Newtonsoft.Json;
using Prism.Modularity;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerModule.ViewModel
{
    public class CustomerDetailViewModel : BindableBase
    {
        private int CallServiceCount = 0;

        private ObservableCollection<M_City> lstCityInfo = new ObservableCollection<M_City>();

        public ObservableCollection<M_City> LstCityInfo
        {
            get { return lstCityInfo; }
            set { lstCityInfo = value; }
        }
        private ObservableCollection<M_District> lstDistrictInfo = new ObservableCollection<M_District>();

        public ObservableCollection<M_District> LstDistrictInfo
        {
            get { return lstDistrictInfo; }
            set { lstDistrictInfo = value; }
        }
        private ObservableCollection<M_Ward> lstWardInfo = new ObservableCollection<M_Ward>();

        public ObservableCollection<M_Ward> LstWardInfo
        {
            get { return lstWardInfo; }
            set { lstWardInfo = value; }
        }

        private bool isBusy;

        public bool IsBusy
        {
            get { return isBusy; }
            set { isBusy = value; }
        }
        public CustomerDetailViewModel(IRegionManager regionManager, IModuleManager moduleManager, IUnityContainer container)
        {
            this.RegionManager = regionManager;
            this.ModuleManager = moduleManager;
            this.UnityContainer = container;
        }



        #region Public Properties
        public IRegionManager RegionManager { get; set; }
        public IUnityContainer UnityContainer { get; set; }
        public IModuleManager ModuleManager { get; set; }
        #endregion

        public void GetInitData()
        {
            GetALLCity();
            GetALLDistrict();
            GetALLWard();
        }
        private void GetALLCity()
        {
            CallServiceCount++;
            DAOProvider dao = DAOProvider.GetInstance();
            dao.CallBackComplete = new DAOProvider.FinishCompleted(Completed);
            dao.CallBackFail = new DAOProvider.FinishFail(Failed);
            dao.GetALL_M_CityInfo();
        }
        private void GetALLDistrict()
        {
            CallServiceCount++;
            DAOProvider dao = DAOProvider.GetInstance();
            dao.CallBackComplete = new DAOProvider.FinishCompleted(Completed);
            dao.CallBackFail = new DAOProvider.FinishFail(Failed);
            dao.GetALL_M_DistrictInfo();
        }
        private void GetALLWard()
        {
            CallServiceCount++;
            DAOProvider dao = DAOProvider.GetInstance();
            dao.CallBackComplete = new DAOProvider.FinishCompleted(Completed);
            dao.CallBackFail = new DAOProvider.FinishFail(Failed);
            dao.GetALL_M_WardInfo();
        }

        #region Delegate CallBack Method
        void Completed(string tag, object data)
        {
            if (tag == SalingManagement_WebServiceTag.TAG_GETALL_M_CITYINFO)
            {
                this.LstCityInfo = JsonConvert.DeserializeObject<ObservableCollection<M_City>>(data.ToString());
            }
            if (tag == SalingManagement_WebServiceTag.TAG_GETALL_M_DISTRICTINFO)
            {
                this.LstDistrictInfo = JsonConvert.DeserializeObject<ObservableCollection<M_District>>(data.ToString());
            }
            if (tag == SalingManagement_WebServiceTag.TAG_GETALL_M_WARDINFO)
            {
                this.LstWardInfo = JsonConvert.DeserializeObject<ObservableCollection<M_Ward>>(data.ToString());
            }
            if (CallServiceCount <= 0)
                IsBusy = false;
        }

        void Failed(string tag, string data)
        {
            if (tag == SalingManagement_WebServiceTag.TAG_UPLOAD_IMAGES)
            {
                CallServiceCount--;
            }
            if (CallServiceCount <= 0)
                IsBusy = false;
        }
        #endregion
    }
}
