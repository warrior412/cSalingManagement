using cSalingManagement.Infrastructure.Common;
using cSalingManagement.Infrastructure.Model;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

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

        async public void GetALL_M_ProductInfo()
        {
            await Task.Run(() =>
            {
                WebClient wc = new WebClient();
                wc.Encoding = Encoding.UTF8;
                wc.DownloadStringCompleted += wc_DownloadStringCompleted;
                wc.DownloadStringAsync(new Uri("http://localhost/myWebAPIService/api/Product/GetM_ProductAll"));
            });
        }

        async public void InsertM_ProductInfo(M_ProductInfo m_productinfo)
        {
            string url = ConfigurationManager.AppSettings["WSURL"];
            await Task.Run(() =>
            {
                WebClient wc = new WebClient();
                string json = JsonConvert.SerializeObject(m_productinfo);
                wc.Headers[HttpRequestHeader.ContentType] = "application/json";
                wc.Headers.Add(SalingManagement_WebServiceTag.SERVICE_TAG,SalingManagement_WebServiceTag.TAG_INSERT_MPRODUCTINFO);
                wc.Encoding = Encoding.UTF8;
                wc.UploadStringCompleted += wc_UploadStringCompleted;
                wc.UploadStringAsync(new Uri(url + "Product/Insert_M_ProductInfo"), json);
            });
        }

        private void wc_UploadStringCompleted(object sender, UploadStringCompletedEventArgs e)
        {
            if(e.Error!=null)
            {
                this.CallBackFail(e.Error.Message.ToString());
                return;
            }
            WebClient wc = (WebClient)sender;
            string s = e.Result;
            var result = JsonConvert.DeserializeObject(e.Result);
            JObject ob = JObject.Parse(result.ToString());
            var status = ob["Status"];
            var data = ob["Data"];

            string tag = wc.Headers[SalingManagement_WebServiceTag.SERVICE_TAG];
            switch (tag)
            {
                case SalingManagement_WebServiceTag.TAG_INSERT_MPRODUCTINFO:
                    this.CallBackComplete(data.ToString());
                    break;
                default:
                    break;
            }
        }


        private void wc_DownloadStringCompleted(object sender, DownloadStringCompletedEventArgs e)
        {
            WebClient wc = (WebClient)sender;
            string s = e.Result;
            var result = JsonConvert.DeserializeObject(e.Result);
            JObject ob = JObject.Parse(result.ToString());
            var status = ob["Status"];
            var data = ob["Data"];
            this.CallBackComplete(data.ToString());
        }
    }
}
