using Newtonsoft.Json;
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
using System.Windows.Shapes;

namespace WebAPITestAPP
{
    /// <summary>
    /// Interaction logic for ProductList.xaml
    /// </summary>
    public partial class ProductList : Window
    {
        private ObservableCollection<sp_SelectMProductAll_Result> products = null;

        public ObservableCollection<sp_SelectMProductAll_Result> Products
        {
            get { return products; }
            set { products = value; }
        }
        public ProductList()
        {
            InitializeComponent();
            GetProductData();
        }
        void Completed (string rs)
        {
            this.Dispatcher.Invoke((Action)(() =>
            {
                products = JsonConvert.DeserializeObject<ObservableCollection<sp_SelectMProductAll_Result>>(rs.ToString());

                ListCollectionView collectionView = new ListCollectionView(products);
                collectionView.GroupDescriptions.Add(new PropertyGroupDescription("ProductID"));
                this.gvCheckInfo.ItemsSource = collectionView;
                this.UpdateLayout();
                busyIndicator.IsBusy = false;
            }));
        }
        public void GetProductData()
        {
             try
            {
                busyIndicator.IsBusy = true;
                DAOProvider dao = DAOProvider.GetInstance();
                dao.GetAllData();
                dao.CallBackComplete=new DAOProvider.FinishCompleted(Completed);

            }
            catch (Exception ex)
            {
                busyIndicator.IsBusy = false;

                if (!ex.Message.Contains("The request was aborted: The request was canceled."))
                {
                    MessageBox.Show("Unexpected error: " + ex.Message,
                        "Async Await Demo", MessageBoxButton.OK, MessageBoxImage.Error);

                }
            }
        }
    }
}
