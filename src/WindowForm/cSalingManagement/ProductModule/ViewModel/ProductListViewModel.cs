using cSalingManagement.Infrastructure.Model;
using Microsoft.Practices.Unity;
using Prism.Modularity;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductModule.ViewModel
{
    public class ProductListViewModel:BindableBase
    {
        private ObservableCollection<MProductInfo> lstProductInfo= new ObservableCollection<MProductInfo>();

        public ObservableCollection<MProductInfo> LstProductInfo
        {
            get { return lstProductInfo; }
            set { lstProductInfo = value; }
        }
        
        public string test = "aa";
        public ProductListViewModel(IRegionManager regionManager, IModuleManager moduleManager, IUnityContainer container)
        {
            this.RegionManager = regionManager;
            this.ModuleManager = moduleManager;
            this.UnityContainer = container;
            this.LstProductInfo.Add(new MProductInfo { ProductID = "MP001", ProductName = "Product 1", Quantity = "3" });
            this.LstProductInfo.Add(new MProductInfo { ProductID = "MP002", ProductName = "Product 2", Quantity = "6" });
            this.LstProductInfo.Add(new MProductInfo { ProductID = "MP003", ProductName = "Product 3", Quantity = "1" });
        }

        #region Public Properties
        public IRegionManager RegionManager { get; set; }
        public IUnityContainer UnityContainer { get; set; }
        public IModuleManager ModuleManager { get; set; }
        #endregion
    }
}
