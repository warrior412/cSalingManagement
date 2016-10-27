using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WebAPITestAPP
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            btnGetData.Click += btnGetData_Click;
            grdData.AutoGeneratingColumn += grdData_AutoGeneratingColumn;
        }



        //this will make sure that the "ExtentionData" column added as part of Serialization is prevented from showing up on the grid.
        void grdData_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            if (e.Column.Header.ToString() == "ExtensionData")
            {
                e.Cancel = true;
            }
        }


        ////If the request is still being executed, this gives a chance to abort it.
        //void btnAbort_Click(object sender, RoutedEventArgs e)
        //{
        //    if (client != null)
        //    {
        //        if (client.State == System.ServiceModel.CommunicationState.Opened)
        //        {
        //            client.Abort();
        //        }

        //    }
        //}


        void Completed (List<tblTemp> list)
        {
            this.Dispatcher.Invoke((Action)(() =>
            {
                grdData.ItemsSource = list;
                busyIndicator.IsBusy = false;
            }));
        }
        //Async method to get the data from web service.
        void btnGetData_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                busyIndicator.IsBusy = true;
                DAOProvider dao = DAOProvider.GetInstance();
                dao.GetAllData();
                //dao.CallBackComplete=new DAOProvider.FinishCompleted(Completed);

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


            this.UpdateLayout();
        }

        //void wc_DownloadStringCompleted(object sender, DownloadStringCompletedEventArgs e)
        //{
        //    string s = e.Result;
        //    var result = JsonConvert.DeserializeObject(e.Result);
        //    JObject ob = JObject.Parse(result.ToString());
        //    var status = ob["Status"];
        //    var data = ob["Data"];
        //    var list = JsonConvert.DeserializeObject<List<tblTemp>>(data.ToString());

            
        //    this.Dispatcher.Invoke((Action)(() =>
        //    {
        //        grdData.ItemsSource = list;
        //        busyIndicator.IsBusy = false;
        //     }));
            
        //}

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Stream requestStream = null;
            Stream responseStream = null;
            StreamReader responseReader = null;

            try
            {
                Book b = new Book();
                b.Id = "10";
                b.Name = "New Book";
                var json = new JavaScriptSerializer().Serialize(b);
                string uri = "http://localhost:50541/aaa/Book2";

                UTF8Encoding encoding = new UTF8Encoding();
                Byte[] buffer = encoding.GetBytes(json);

                HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(uri);
                httpWebRequest.Method = "POST";
                httpWebRequest.ContentLength = buffer.Length;
                httpWebRequest.ContentType = @"application/json; charset=utf-8";
                httpWebRequest.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,*/*;q=0.8";

                requestStream = httpWebRequest.GetRequestStream();
                requestStream.Write(buffer, 0, buffer.Length);

                HttpWebResponse httpWebresponse = (HttpWebResponse)httpWebRequest.GetResponse();
                responseStream = httpWebresponse.GetResponseStream();

                responseReader = new StreamReader(responseStream);

                //JavaScriptSerializer jss = new JavaScriptSerializer();
                //object returnValue = jss.Deserialize(reader.ReadToEnd(), typeof(object));
                dynamic response = JObject.Parse(responseReader.ReadToEnd());

                //return Tuple.Create(response.result, true);
            }
            catch (Exception ex)
            {
                //return Tuple.Create(false, false);
            }
            finally
            {
                if (requestStream != null) { requestStream.Close(); requestStream.Dispose(); }
                if (responseStream != null) { responseStream.Close(); responseStream.Dispose(); }
                if (responseReader != null) { responseReader.Close(); responseReader.Dispose(); }
            }
        }
    }
}
