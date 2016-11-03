﻿using cSalingmanagement.Webservice;
using cSalingManagement.Infrastructure.Model;
using Newtonsoft.Json;
using Prism.Commands;
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
    /// Interaction logic for ProductListView.xaml
    /// </summary>
    public partial class ProductListView : UserControl
    {
        private ProductListViewModel _vm = null;

        public ProductListViewModel Vm
        {
            get { return _vm; }
            set
            {
                _vm = value;
            }
        }
        
        public ProductListView(ProductListViewModel vm)
        {
            InitializeComponent();
            _vm = vm;
            GetProductData();
        }
        
        public void GetProductData()
        {
            try
            {
                busyIndicator.IsBusy = true;
                DAOProvider dao = DAOProvider.GetInstance();
                //dao.GetAllData();
                //dao.CallBackComplete = new DAOProvider.FinishCompleted(Completed);

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

        void Completed(string rs)
        {
            this.Dispatcher.Invoke((Action)(() =>
            {
               _vm.LstProductInfo = JsonConvert.DeserializeObject<ObservableCollection<M_ProductInfo>>(rs.ToString());
               _vm.Text = "text";
                DataContext = _vm;
                ListCollectionView collectionView = new ListCollectionView(_vm.LstProductInfo);
                collectionView.GroupDescriptions.Add(new PropertyGroupDescription("ProductID"));
                this.gvCheckInfo.ItemsSource = collectionView;
                this.UpdateLayout();
                busyIndicator.IsBusy = false;
            }));
        }

        


    }
}
