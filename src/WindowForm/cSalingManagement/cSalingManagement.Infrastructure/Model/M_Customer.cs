using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cSalingManagement.Infrastructure.Model
{
    public partial class M_Customer
    {
        public string Customer_ID { get; set; }
        public string Customer_Name { get; set; }
        public Nullable<System.DateTime> Customer_BirthDay { get; set; }
        public string Customer_Phone { get; set; }
        public string Customer_Mobile { get; set; }
        public string Customer_Address { get; set; }
        public string Customer_Ward { get; set; }
        public string Customer_District { get; set; }
        public string Customer_City { get; set; }
        public string Customer_Description { get; set; }
        public string Customer_Type { get; set; }
        public Nullable<int> Customer_Point { get; set; }
        public Nullable<int> Customer_Status { get; set; }
    }
}
