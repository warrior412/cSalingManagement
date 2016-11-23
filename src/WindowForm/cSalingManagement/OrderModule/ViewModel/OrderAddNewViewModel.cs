﻿using cSalingmanagement.Webservice;
using cSalingManagement.Infrastructure.Common;
using cSalingManagement.Infrastructure.Model;
using Microsoft.Practices.Unity;
using Newtonsoft.Json;
using OrderModule.View;
using Prism.Modularity;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderModule.ViewModel
{
    public class OrderAddNewViewModel : BindableBase
    {
        #region Properties

        private int CallServiceCount = 0;
        public OrderAddNewView view = null;
        private bool isEditing;

        public bool IsEditing
        {
            get { return isEditing; }
            set { SetProperty(ref this.isEditing, value); }
        }
        private M_Customer customerInfo = new M_Customer();

        public M_Customer CustomerInfo
        {
            get { return customerInfo; }
            set { SetProperty(ref this.customerInfo, value); }
        }

        private ObservableCollection<M_ProductInfoWithImportInfo_Row> lstOrder = new ObservableCollection<M_ProductInfoWithImportInfo_Row>();

        public ObservableCollection<M_ProductInfoWithImportInfo_Row> LstOrder
        {
            get { return lstOrder; }
            set { SetProperty(ref this.lstOrder, value); }
        }

        private ObservableCollection<M_CustomerTypeInfo> lstCustomerType = new ObservableCollection<M_CustomerTypeInfo>();

        public ObservableCollection<M_CustomerTypeInfo> LstCustomerType
        {
            get { return lstCustomerType; }
            set { SetProperty(ref this.lstCustomerType, value); }
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
        #endregion

        #region Public Properties
        public IRegionManager RegionManager { get; set; }
        public IUnityContainer UnityContainer { get; set; }
        public IModuleManager ModuleManager { get; set; }
        #endregion
        public OrderAddNewViewModel(IRegionManager regionManager, IModuleManager moduleManager, IUnityContainer container)
        {
            this.RegionManager = regionManager;
            this.ModuleManager = moduleManager;
            this.UnityContainer = container;
        }

        #region Process Method
        public void GetInitData()
        {
            GetALLCity();
            GetALLDistrict();
            GetALLWard();
            GetALLCustomerType();
        }
        public void GetCustomerInfoByID(string customerID)
        {
            CallServiceCount++;
            IsBusy = true;
            DAOProvider dao = DAOProvider.GetInstance();
            dao.CallBackComplete = new DAOProvider.FinishCompleted(Completed);
            dao.CallBackFail = new DAOProvider.FinishFail(Failed);
            dao.Get_M_CustomerInfo_ByCustomerID(customerID);
        }

        private void GetALLCustomerType()
        {
            CallServiceCount++;
            IsBusy = true;
            DAOProvider dao = DAOProvider.GetInstance();
            dao.CallBackComplete = new DAOProvider.FinishCompleted(Completed);
            dao.CallBackFail = new DAOProvider.FinishFail(Failed);
            dao.GetALL_M_CustomerTypetInfo();
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
        private void InsertCustomerInfo()
        {
            CallServiceCount++;
            IsBusy = true;
            DAOProvider dao = DAOProvider.GetInstance();
            dao.CallBackComplete = new DAOProvider.FinishCompleted(Completed);
            dao.CallBackFail = new DAOProvider.FinishFail(Failed);
            dao.InsertM_CustomerInfo(this.CustomerInfo);
        }
        #endregion

        #region Delegate CallBack Method
        void Completed(string tag, object data)
        {
            if (tag == SalingManagement_WebServiceTag.TAG_GET_M_CUSTOMERINFO_BYID)
            {
                CallServiceCount--;
                this.CustomerInfo = JsonConvert.DeserializeObject<M_Customer>(data.ToString());
            }
            if (tag == SalingManagement_WebServiceTag.TAG_GETALL_M_CUSTOMERTYPEINFO)
            {
                CallServiceCount--;
                this.LstCustomerType = JsonConvert.DeserializeObject<ObservableCollection<M_CustomerTypeInfo>>(data.ToString());
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
            if (tag == SalingManagement_WebServiceTag.TAG_INSERT_M_CUSTOMERINFO)
            {
                CallServiceCount--;
                this.CustomerInfo.Customer_ID = data.ToString();
                this.IsEditing = false;
                this.view.Dispatcher.Invoke((Action)(() =>
                {
                    this.view.DataContext = null;
                    this.view.DataContext = this.view.Vm;
                }));
                this.view.ShowMessage("Success");
            }
            if (CallServiceCount <= 0)
                IsBusy = false;
        }

        void Failed(string tag, string data)
        {
            this.view.ShowMessage(data);
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
