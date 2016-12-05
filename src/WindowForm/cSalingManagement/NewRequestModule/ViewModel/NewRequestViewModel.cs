using cSalingManagement.Common;
using cSalingManagement.Infrastructure.Model;
using Microsoft.Practices.Unity;
using NewRequestModule.View;
using Prism.Commands;
using Prism.Modularity;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;

namespace NewRequestModule.ViewModel
{
    public class NewRequestViewModel:BindableBase
    {
        #region Properties
        private ObservableCollection<NewRequestView_ImportList_Row> lstProductInfo =
            new ObservableCollection<NewRequestView_ImportList_Row>();

        public ObservableCollection<NewRequestView_ImportList_Row> LstProductInfo
        {
            get { return lstProductInfo; }
            set
            {
                SetProperty(ref this.lstProductInfo, value);
                if(this.LstProductInfo!=null)
                {
                    ListCollectionView cv = new ListCollectionView(this.lstProductInfo);
                    cv.GroupDescriptions.Add(new PropertyGroupDescription("Supplier"));
                    this.LstCollectionView = cv;
                }
            }
        }

        private ListCollectionView lstCollectionView;

        public ListCollectionView LstCollectionView
        {
            get { return lstCollectionView; }
            set { SetProperty(ref this.lstCollectionView, value); }
        }

        private ObservableCollection<M_Supplier> lstSupplierInfo = new ObservableCollection<M_Supplier>();

        public ObservableCollection<M_Supplier> LstSupplierInfo
        {
            get { return lstSupplierInfo; }
            set { SetProperty(ref this.lstSupplierInfo, value); }
        }

        public NewRequestView view = null;  
        #endregion

        public NewRequestViewModel(IRegionManager regionManager, IModuleManager moduleManager, IUnityContainer container)
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

        #region Command and Command Method

        public ICommand ConfirmImportRowCommand
        {
            get
            {
                return new DelegateCommand<object>(doCofirmImport);
            }
        }
        public ICommand SaveRowCommand
        {
            get
            {
                return new DelegateCommand<object>(doRowReady);
            }
        }
        public ICommand DeleteRowCommand
        {
            get
            {
                return new DelegateCommand<object>(doDeleteRow);
            }
        }
        

        public ICommand CheckRowCommand
        {
            get
            {
                return new DelegateCommand<object>(doRowEdit);
            }
        }


        private void doDeleteRow(object dataGrid)
        {
            if (dataGrid == null)
                return;
            if(view.ShowMessageBoxConfirm("Bạn có chắc muốn hủy yêu cầu nhập hàng này không?"))
            {
                ObservableCollection<NewRequestView_ImportList_Row> lstConfirmImportList =
                new ObservableCollection<NewRequestView_ImportList_Row>();

                NewRequestView_ImportList_Row rowData = ((DataGrid)dataGrid).SelectedItem as NewRequestView_ImportList_Row;
                this.LstProductInfo.Remove(rowData);
                this.LstProductInfo = this.LstProductInfo;

                rowData.Import_Status = SalingManagementConstant.STATUS_DELETED;
                lstConfirmImportList.Add(rowData);
                
                view.UpdateImportList(lstConfirmImportList);
            }
            
        }
        private void doRowReady(object dataGrid)
        {
            if (dataGrid == null)
                return;
            NewRequestView_ImportList_Row rowData = ((DataGrid)dataGrid).SelectedItem as NewRequestView_ImportList_Row;
            //validation
            if (!this.checkValidation(rowData))
                return;
            this.LstProductInfo[this.LstProductInfo.IndexOf(rowData)].IsReady = true;
            this.LstProductInfo = this.LstProductInfo;
        }
        private void doRowEdit(object dataGrid)
        {
            if (dataGrid == null)
                return;
            NewRequestView_ImportList_Row rowData = ((DataGrid)dataGrid).SelectedItem as NewRequestView_ImportList_Row;
            this.LstProductInfo[this.LstProductInfo.IndexOf(rowData)].IsReady = false;
            this.LstProductInfo = this.LstProductInfo;
        } 

        private void doCofirmImport(object param)
        {
            ObservableCollection<NewRequestView_ImportList_Row> lstConfirmImportList = 
                new ObservableCollection<NewRequestView_ImportList_Row>();
            foreach(NewRequestView_ImportList_Row row in this.LstProductInfo.ToList())
            {
                if(row.IsReady)
                {
                    this.LstProductInfo.Remove(row);
                    row.Import_Status = SalingManagementConstant.STATUS_READY; //State Ready
                    row.Import_OnOrder = 0;
                    row.Import_InStock = row.Import_Quantity;
                    lstConfirmImportList.Add(row);
                }
            }
            this.LstProductInfo = this.LstProductInfo;
            view.UpdateImportList(lstConfirmImportList);
            
        }
        #endregion

        #region Process Method
        private bool checkValidation(NewRequestView_ImportList_Row rowData)
        {
            if (rowData.Import_Quantity == null || rowData.Import_Quantity.ToString().Equals("") || rowData.Import_Quantity <= 0)
            {
                view.ShowMessageBox("Vui lòng nhập số lượng hàng");
                return false;
            }
            if (rowData.UnitPrice == null || rowData.UnitPrice.ToString().Equals("") || rowData.UnitPrice <= 0)
            {
                view.ShowMessageBox("Vui lòng nhập đơn giá");
                return false;
            }
            if (rowData.ExpirionDate == null || rowData.ExpirionDate.ToString().Equals(""))
            {
                view.ShowMessageBox("Vui lòng nhập hạn sử dụng");
                return false;
            }
            return true;
        } 
        #endregion
    }
}
