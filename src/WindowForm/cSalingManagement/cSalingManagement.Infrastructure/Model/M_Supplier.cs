using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cSalingManagement.Infrastructure.Model
{
    public class M_Supplier
    {
        public string SupplierID { get; set; }
        public string SupplierName { get; set; }
        public string Supp_Address { get; set; }
        public string Supp_Phone { get; set; }
        public string Supp_Sub_Phone { get; set; }
        public string Supp_Email { get; set; }
        public string Supp_Website { get; set; }
        public string Supp_Image { get; set; }
        public Nullable<int> Supplier_Status { get; set; }
    }
}
