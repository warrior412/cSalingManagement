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

        public delegate void FinishCompleted(string tag,object data);
        public delegate void FinishFail(string tag, string data);

        public FinishCompleted CallBackComplete;
        public FinishFail CallBackFail;

        public static DAOProvider _instance = null;
        public static DAOProvider GetInstance()
        {
            if (_instance == null)
                return new DAOProvider();
            return _instance;
        }

        async public void GetALL_M_ProductInfoWithImportData()
        {
            string url = ConfigurationManager.AppSettings["WSURL"];
            await Task.Run(() =>
            {
                WebClient wc = new WebClient();
                wc.Encoding = Encoding.UTF8;
                wc.Headers[HttpRequestHeader.ContentType] = "application/json";
                wc.Headers.Add(SalingManagement_WebServiceTag.SERVICE_TAG, SalingManagement_WebServiceTag.TAG_GETALL_M_PRODUCTINFO);
                wc.DownloadStringCompleted += wc_DownloadStringCompleted;
                wc.DownloadStringAsync(new Uri(url + "Product/SelectAll_M_ProductInfoWithImportInfo"));
            });
        }

        async public void GetALL_M_CategoryInfo()
        {
            string url = ConfigurationManager.AppSettings["WSURL"];
            await Task.Run(() =>
            {
                WebClient wc = new WebClient();
                wc.Encoding = Encoding.UTF8;
                wc.Headers[HttpRequestHeader.ContentType] = "application/json";
                wc.Headers.Add(SalingManagement_WebServiceTag.SERVICE_TAG, SalingManagement_WebServiceTag.TAG_GETALL_M_CATEGORYINFO);
                wc.DownloadStringCompleted += wc_DownloadStringCompleted;
                wc.DownloadStringAsync(new Uri(url + "Category/SelectAll_M_CategoryInfo"));
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
                wc.Headers.Add(SalingManagement_WebServiceTag.SERVICE_TAG,SalingManagement_WebServiceTag.TAG_INSERT_M_PRODUCTINFO);
                wc.Encoding = Encoding.UTF8;
                wc.UploadStringCompleted += wc_UploadStringCompleted;
                wc.UploadStringAsync(new Uri(url + "Product/Insert_M_ProductInfo"), json);
            });
        }







        private void wc_UploadStringCompleted(object sender, UploadStringCompletedEventArgs e)
        {
            WebClient wc = (WebClient)sender;
            string tag = wc.Headers[SalingManagement_WebServiceTag.SERVICE_TAG];

            if(e.Error!=null)
            {
                this.CallBackFail( tag ,"");
                return;
            }

            string s = e.Result;
            var result = JsonConvert.DeserializeObject(e.Result);
            JObject ob = JObject.Parse(result.ToString());
            var status = ob["Status"];
            var data = ob["Data"];

           
            switch (tag)
            {
                case SalingManagement_WebServiceTag.TAG_INSERT_M_PRODUCTINFO:
                    this.CallBackComplete(tag,data);

                    break;
                default:
                    break;
            }
        }


        private void wc_DownloadStringCompleted(object sender, DownloadStringCompletedEventArgs e)
        {
            WebClient wc = (WebClient)sender;
            string tag = wc.Headers[SalingManagement_WebServiceTag.SERVICE_TAG];

            if (e.Error != null)
            {
                this.CallBackFail(tag,e.Error.Message.ToString());
                return;
            }
            
            string s = e.Result;
            var result = JsonConvert.DeserializeObject(e.Result);
            JObject ob = JObject.Parse(result.ToString());
            var status = ob["Status"];
            var data = ob["Data"];

            
            switch (tag)
            {
                case SalingManagement_WebServiceTag.TAG_GETALL_M_CATEGORYINFO:
                    this.CallBackComplete(tag,data);
                    break;
                case SalingManagement_WebServiceTag.TAG_GETALL_M_PRODUCTINFO:
                    this.CallBackComplete(tag, data);
                    break;
                default:
                    break;
            }

        }
    }
}
