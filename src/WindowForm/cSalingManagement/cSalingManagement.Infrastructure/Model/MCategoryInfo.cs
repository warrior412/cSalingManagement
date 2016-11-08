using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cSalingManagement.Infrastructure.Model
{
    public partial class M_CategoryInfo
    {
        public string CategoryID { get; set; }
        public string CategoryName { get; set; }
        public string Cate_Description { get; set; }
        public string Cate_Image { get; set; }
        public Nullable<int> Cate_Status { get; set; }

        public ObservableCollection<M_CategoryInfo> JSonToListCategory(object json)
        {
            return JsonConvert.DeserializeObject<ObservableCollection<M_CategoryInfo>>(json.ToString());
        }
    }
}
