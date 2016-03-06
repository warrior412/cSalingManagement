using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace TestMyWebService
{
    public class Employee
    {
        private string id;
        public string Id
        {
            get { return id; }
            set { id = value; }
        }
        private string name;
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        private string age;

        public string Age
        {
            get { return age; }
            set { age = value; }
        }
        private string gender;

        public string Gender
        {
            get { return gender; }
            set { gender = value; }
        }

    }
    class Program
    {
        static void Main(string[] args)
        {
            Program obj = new Program();
            //string json = obj.GET("http://localhost:51677/Rest.svc/GetEmployee?id=" + 1);
            //List<Employee> emp = JsonConvert.DeserializeObject<List<Employee>>(json);
        }
        string GET(string url)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            try
            {
                WebResponse response = request.GetResponse();
                using (Stream responseStream = response.GetResponseStream())
                {
                    StreamReader reader = new StreamReader(responseStream, Encoding.UTF8);
                    return reader.ReadToEnd();
                }
            }
            catch (WebException ex)
            {
                WebResponse errorResponse = ex.Response;
                using (Stream responseStream = errorResponse.GetResponseStream())
                {
                    StreamReader reader = new StreamReader(responseStream, Encoding.GetEncoding("utf-8"));
                    String errorText = reader.ReadToEnd();
                    // log errorText
                }
                throw;
            }
        }
    }
}
