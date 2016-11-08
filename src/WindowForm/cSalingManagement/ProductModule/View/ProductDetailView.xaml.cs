using cSalingmanagement.Webservice;
using cSalingManagement.Infrastructure.Common;
using cSalingManagement.Infrastructure.Model;
using ProductModule.ViewModel;
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

namespace ProductModule.View
{
    /// <summary>
    /// Interaction logic for ProductDetailView.xaml
    /// </summary>
    public partial class ProductDetailView : UserControl
    {
        private ProductDetailViewModel _vm = null;

        public ProductDetailViewModel Vm
        {
            get { return _vm; }
            set
            {
                _vm = value;
            }
        }
        public ProductDetailView(ProductDetailViewModel vm)
        {
            InitializeComponent();
            //DAOProvider dao = DAOProvider.GetInstance();
            //M_ProductInfo product = new M_ProductInfo();
            //product.ProductName = "Test 2";
            //dao.InsertM_ProductInfo(product);
            //dao.CallBackComplete = new DAOProvider.FinishCompleted(Completed);
            //dao.CallBackFail = new DAOProvider.FinishFail(Failed);
            _vm = vm;
            GetInitData();
        }
        private void GetInitData()
        {
            busyIndicator.IsBusy = true;
            DAOProvider dao = DAOProvider.GetInstance();
            dao.GetALL_M_CategoryInfo();
            dao.CallBackComplete = new DAOProvider.FinishCompleted(Completed);
            dao.CallBackFail = new DAOProvider.FinishFail(Failed);
        }
        void Completed(string tag,object data)
        {
            
            this.Dispatcher.Invoke((Action)(() =>
            {
                MessageBox.Show("Success");
                if (tag == SalingManagement_WebServiceTag.TAG_GETALL_M_CATEGORYINFO)
                {
                    _vm.LstCategoryInfo = new M_CategoryInfo().JSonToListCategory(data);
                    //DataContext = _vm;
                    this.cbCategory.ItemsSource = _vm.LstCategoryInfo;
                    this.cbCategory.DisplayMemberPath = "CategoryName";
                    this.UpdateLayout();
                    busyIndicator.IsBusy = false;
                }
            }));
        }

        void Failed(string tag, string data)
        {
            this.Dispatcher.Invoke((Action)(() =>
            {
                MessageBox.Show(data);
                busyIndicator.IsBusy = false;
            }));
        }
    }
}
