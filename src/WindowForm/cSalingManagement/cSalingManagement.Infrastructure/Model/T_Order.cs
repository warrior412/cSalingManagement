using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cSalingManagement.Infrastructure.Model
{
    public partial class T_Order
    {
        public string OrderID { get; set; }
        public string Order_CustomerID { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public string CreatedUser { get; set; }
        public string Order_Memo { get; set; }
        public Nullable<System.DateTime> Order_ShipTime { get; set; }
        public Nullable<int> Order_Status { get; set; }
    }
}
