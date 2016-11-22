using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cSalingManagement.Infrastructure.Model
{
    public class M_CustomerTypeInfo
    {
        public string CustomerTypeID { get; set; }
        public string CustomerType_Name { get; set; }
        public Nullable<int> CustomerType_Status { get; set; }
    }
}
