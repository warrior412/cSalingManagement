using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cSalingManagement.Infrastructure.Model
{
    public partial class T_OrderDetail
    {
        public string OD_OrderID { get; set; }
        public string OD_ProductID { get; set; }
        public System.DateTime OD_ImportDate { get; set; }
        public Nullable<int> OD_Quantity { get; set; }
        public Nullable<double> OD_SellingPrice { get; set; }
        public Nullable<double> OD_TotalAmount { get; set; }
        public Nullable<int> OD_Status { get; set; }
    }
}
