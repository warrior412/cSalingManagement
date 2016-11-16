using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        public Nullable<int> Pro_InStock { get; set; }
        public string Pro_Image { get; set; }
        public Nullable<double> Pro_Price { get; set; }
        public string Pro_Desciptions { get; set; }
        public string Pro_Preservation { get; set; }
        public string Pro_HowToUse { get; set; }
        public string Pro_Origin { get; set; }
        public Nullable<int> Pro_Status { get; set; }
    }
    public partial class M_ProductInfoWithImportInfo:M_ProductInfo
    {
        public string ProductID1 { get; set; }
        public Nullable<System.DateTime> ImportDate { get; set; }
        public string Supplier { get; set; }
        public Nullable<int> Import_Quantity { get; set; }
        public Nullable<int> Import_InStock { get; set; }
        public Nullable<int> Import_OnOrder { get; set; }
        public Nullable<double> UnitPrice { get; set; }
        public Nullable<System.DateTime> ExpirionDate { get; set; }
        public string Import_User { get; set; }
        public Nullable<int> Import_Vote { get; set; }
        public Nullable<int> Import_Status { get; set; }

        public ObservableCollection<M_ProductInfoWithImportInfo> JSonToListProductInfoWithImportInfo(object json)
        {
            return JsonConvert.DeserializeObject<ObservableCollection<M_ProductInfoWithImportInfo>>(json.ToString());
        }
        public M_ProductInfoWithImportInfo JSonToProductInfoWithImportInfo(object json)
        {
            return JsonConvert.DeserializeObject<M_ProductInfoWithImportInfo>(json.ToString());
        }
    }
}
