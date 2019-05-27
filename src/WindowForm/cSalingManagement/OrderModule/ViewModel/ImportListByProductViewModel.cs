using cSalingmanagement.Webservice;
using cSalingManagement.Infrastructure.Common;
using cSalingManagement.Infrastructure.Model;
using OrderModule.View;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderModule.ViewModel
{
    public class ImportListByProductViewModel : BindableBase
    {
        private int CallServiceCount = 0;
        public ImportListByProductView view = null;
        private bool isBusy;

        public bool IsBusy
        {
            get { return isBusy; }
            set { SetProperty(ref this.isBusy, value); }
        }

        private ObservableCollection<M_ProductInfoWithImportInfo> lstProductWithImport = new ObservableCollection<M_ProductInfoWithImportInfo>();

        public ObservableCollection<M_ProductInfoWithImportInfo> LstProductWithImport
        {
            get { return lstProductWithImport; }
            set { SetProperty(ref this.lstProductWithImport, value); }
        }

        private M_ProductInfoWithImportInfo productDetail = new M_ProductInfoWithImportInfo();

        public M_ProductInfoWithImportInfo ProductDetail
        {
            get { return productDetail; }
            set { SetProperty(ref this.productDetail, value); }
        }




        public void GetProductDetailByID(string productID)
        {
            IsBusy = true;
            CallServiceCount++;
            DAOProvider dao = DAOProvider.GetInstance();
            dao.CallBackComplete = new DAOProvider.FinishCompleted(Completed);
            dao.CallBackFail = new DAOProvider.FinishFail(Failed);
            dao.GetALL_M_ProductInfoWithImportData_ByProductID(productID);
        }



        #region Delegate CallBack Method
        void Completed(string tag, object data)
        {
            if (tag == SalingManagement_WebServiceTag.TAG_GETALL_M_PRODUCTINFO_BYID)
            {
                CallServiceCount--;
                LstProductWithImport = new M_ProductInfoWithImportInfo()
                    .JSonToListProductInfoWithImportInfo(data.ToString());
                ProductDetail = LstProductWithImport.FirstOrDefault();
                //if (LstCategoryInfo != null && LstCategoryInfo.Count > 0)
                //{
                //    SelectedCategoryInfo = LstCategoryInfo.Where(x => x.CategoryID.Equals(ProductDetail.Category)).FirstOrDefault();
                //}
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
