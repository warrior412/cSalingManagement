using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cSalingManagement.Infrastructure.Model
{
    public partial class M_City
    {
        public string CityID { get; set; }
        public string City_Name { get; set; }
        public Nullable<int> City_Status { get; set; }
    }

    public partial class M_District
    {
        public string DistrictID { get; set; }
        public string District_Name { get; set; }
        public string City { get; set; }
        public Nullable<int> District_Status { get; set; }
    }
    public partial class M_Ward
    {
        public string WardID { get; set; }
        public string Ward_Name { get; set; }
        public string District { get; set; }
        public Nullable<int> Ward_Status { get; set; }
    }
}
