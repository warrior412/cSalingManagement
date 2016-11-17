using cSalingManagement.Infrastructure.Model;
using Microsoft.Practices.Unity;
using Prism.Commands;
using Prism.Modularity;
using Prism.Mvvm;
using Prism.Regions;
using ProductModule.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace ProductModule.ViewModel
{
    public class ProductImportRequestViewModel : BindableBase
    {
        public ProductImportRequestView view = null;
        private ObservableCollection<M_ProductInfo> lstProductInfo = new ObservableCollection<M_ProductInfo>();

        public ObservableCollection<M_ProductInfo> LstProductInfo
        {
            get { return lstProductInfo; }
            set { SetProperty(ref this.lstProductInfo, value); }
        }

        private ObservableCollection<M_Supplier> lstSupplierInfo = new ObservableCollection<M_Supplier>();

        public ObservableCollection<M_Supplier> LstSupplierInfo
        {
            get { return lstSupplierInfo; }
            set { SetProperty(ref this.lstSupplierInfo, value); }
        }

        private ObservableCollection<M_ProductInfoWithImportInfo> lstProductInfoWithImportInfo = new ObservableCollection<M_ProductInfoWithImportInfo>();

        public ObservableCollection<M_ProductInfoWithImportInfo> LstProductInfoWithImportInfo
        {
            get { return lstProductInfoWithImportInfo; }
            set { SetProperty(ref this.lstProductInfoWithImportInfo, value); }
        }

        #region Public Properties
        public IRegionManager RegionManager { get; set; }
        public IUnityContainer UnityContainer { get; set; }
        public IModuleManager ModuleManager { get; set; }
        #endregion
        public ProductImportRequestViewModel(IRegionManager regionManager, IModuleManager moduleManager, IUnityContainer container)
        {
            this.RegionManager = regionManager;
            this.ModuleManager = moduleManager;
            this.UnityContainer = container;
        }

        #region Command Declarations
        public ICommand TransferCommand
        {
            get
            {
                return new DelegateCommand<object>(doTransfer);
            }
        }

        public ICommand RemoveCommand
        {
            get
            {
                return new DelegateCommand<object>(doRemove);
            }
        }
        public ICommand EditCommand
        {
            get
            {
                return new DelegateCommand<object>(doEdit);
            }
        }
        public ICommand FinishImportCommand
        {
            get
            {
                return new DelegateCommand<object>(doFinishImport);
            }
        }
        #endregion

        private void doTransfer(object productID)
        {
            M_ProductInfo seletedItem= this.LstProductInfo.Where(x => x.ProductID == productID.ToString()).FirstOrDefault();
            M_ProductInfoWithImportInfo transferItem = new M_ProductInfoWithImportInfo();
            transferItem.ProductID = seletedItem.ProductID;
            transferItem.ProductName = seletedItem.ProductName;
            this.LstProductInfoWithImportInfo.Add(transferItem);
        }
        private void doRemove(object param)
        {
            DataGrid dataGrid = param as DataGrid;
            M_ProductInfoWithImportInfo selectedItem = dataGrid.SelectedItem as M_ProductInfoWithImportInfo;
            this.LstProductInfoWithImportInfo.Remove(selectedItem);
        }
        private void doEdit(object param)
        {
            //Convert param to Datagrid
            DataGrid dataGrid = param as DataGrid;
            M_ProductInfoWithImportInfo selectedItem = dataGrid.SelectedItem as M_ProductInfoWithImportInfo;

            //
            M_ProductInfo addItem = this.LstProductInfo.Where(x => x.ProductID == selectedItem.ProductID.ToString()).FirstOrDefault();
            
            //Create a transfer object
            M_ProductInfoWithImportInfo transferItem = new M_ProductInfoWithImportInfo();
            transferItem.ProductID = addItem.ProductID;
            transferItem.ProductName = addItem.ProductName;

            //Remove selectedItem
            //Add new item
            this.LstProductInfoWithImportInfo.Remove(selectedItem);
            this.LstProductInfoWithImportInfo.Add(transferItem);
        }
        private void doFinishImport(object param)
        {
           // Validation

           // Do Finish
            view.Insert_T_ImportProductInfo(this.LstProductInfoWithImportInfo);
        }

    }
}
