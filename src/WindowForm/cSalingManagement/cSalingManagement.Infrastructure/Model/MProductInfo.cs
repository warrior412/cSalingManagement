using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cSalingManagement.Infrastructure.Model
{
    public class MProductInfo
    {
        public string ProductID{get;  set;}
        public string CategoryID { get; set; }
        public string ProductName { get; set; }
        public string ProductName2 { get; set; }
        public string Description { get; set; }
        public string DetailDescription { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public string CreatedUser { get; set; }
        public Nullable<System.DateTime> UpdateDate { get; set; }
        public string UpdateUser { get; set; }
        public Nullable<int> Status { get; set; }
        public System.DateTime ArrivalDate { get; set; }
        public Nullable<int> Quantity { get; set; }
        public Nullable<double> Price { get; set; }
        public Nullable<double> SellingPrice { get; set; }
        public string DetailProductID { get; set; }
        public string ArrivalUser { get; set; }
    }
}
