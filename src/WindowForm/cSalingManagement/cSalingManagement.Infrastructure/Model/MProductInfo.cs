using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cSalingManagement.Infrastructure.Model
{
    public partial class M_ProductInfo
    {
        public string ProductID { get; set; }
        public string ProductName { get; set; }
        public string Category { get; set; }
        public string Supplier { get; set; }
        public Nullable<int> Pro_InStock { get; set; }
        public string Pro_Image { get; set; }
        public Nullable<double> Pro_Price { get; set; }
        public string Pro_Desciptions { get; set; }
        public string Pro_Preservation { get; set; }
        public string Pro_HowToUse { get; set; }
        public string Pro_Origin { get; set; }
        public Nullable<int> Pro_Status { get; set; }
    }
}
