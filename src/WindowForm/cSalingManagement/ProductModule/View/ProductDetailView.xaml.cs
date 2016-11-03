using cSalingmanagement.Webservice;
using cSalingManagement.Infrastructure.Model;
using System;
using System.Collections.Generic;
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
        public ProductDetailView()
        {
            InitializeComponent();
            DAOProvider dao = DAOProvider.GetInstance();
            M_ProductInfo product = new M_ProductInfo();
            product.ProductName = "Test 2";
            dao.InsertM_ProductInfo(product);
            dao.CallBackComplete = new DAOProvider.FinishCompleted(Completed);
            dao.CallBackFail = new DAOProvider.FinishFail(Failed);
        }
        void Completed(string rs)
        {
            this.Dispatcher.Invoke((Action)(() =>
            {
                MessageBox.Show("Success");
            }));
        }

        void Failed(string rs)
        {
            this.Dispatcher.Invoke((Action)(() =>
            {
                MessageBox.Show(rs);
            }));
        }
    }
}
