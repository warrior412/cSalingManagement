using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace cSalingmanagement.Webservice
{
    public class DAOProvider
    {

        public delegate void FinishCompleted(string rs);
        public FinishCompleted CallBackComplete;
        public delegate void FinishFail(string rs);
        public FinishFail CallBackFail;


        public static DAOProvider _instance = null;
        public static DAOProvider GetInstance()
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
                wc.Encoding = Encoding.UTF8;
                wc.DownloadStringCompleted += wc_DownloadStringCompleted;
                wc.DownloadStringAsync(new Uri("http://localhost/myWebAPIService/api/Product/GetM_ProductAll"));

            });
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
