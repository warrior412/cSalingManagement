using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace WebAPITestAPP
{
    public class DAOProvider
    {

        public delegate void FinishCompleted(string rs);
        public FinishCompleted CallBackComplete;
        public delegate void FinishFail(string rs);
        public FinishFail CallBackFail;


        public static DAOProvider _instance = null;
        public static DAOProvider GetInstance ()
        {
            if (_instance == null)
                return new DAOProvider();
            return _instance;
        }

        async public void GetAllData()
        {
            await Task.Run(() =>
            {
                WebClient wc = new WebClient();
                // UTF-8 として取得
                M_ProductInfo product = new M_ProductInfo();
                product.ProductName = "Test";
                string json = JsonConvert.SerializeObject(product);
                wc.Headers[HttpRequestHeader.ContentType] = "application/json";
                wc.Headers.Add("TAG", "GETALL");
                wc.Encoding = Encoding.UTF8;
                wc.UploadStringCompleted +=wc_UploadStringCompleted;
                wc.UploadStringAsync(new Uri("http://localhost:50290/Product/Insert_M_ProductInfo"), json);

            });
        }

        private void wc_UploadStringCompleted(object sender, UploadStringCompletedEventArgs e)
        {
            WebClient wc = (WebClient)sender;
            string s = e.Result;
            var result = JsonConvert.DeserializeObject(e.Result);
            JObject ob = JObject.Parse(result.ToString());
            var status = ob["Status"];
            var data = ob["Data"];
        }

        void wc_DownloadStringCompleted(object sender, DownloadStringCompletedEventArgs e)
        {
            string s = e.Result;
            var result = JsonConvert.DeserializeObject(e.Result);
            JObject ob = JObject.Parse(result.ToString());
            var status = ob["Status"];
            var data = ob["Data"];
            this.CallBackComplete(data.ToString());
        }
    }
}
