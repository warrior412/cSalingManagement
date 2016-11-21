using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cSalingManagement.Infrastructure.Common
{
    public  static class SalingManagement_WebServiceTag
    {
        public static string SERVICE_TAG = "SERVICE_TAG";

        public const string TAG_UPLOAD_IMAGES = "0";

        #region Insert TAG
        public  const string TAG_INSERT_M_PRODUCTINFO = "1";
        public  const string TAG_INSERT_M_ACCOUNTINFO = "2";
        public  const string TAG_INSERT_M_CATEGORYINFO = "3";
        public const string TAG_INSERT_T_IMPORTPRODUCTINFO = "4"; 
        #endregion

        

        #region Select TAG
        public  const string TAG_GETALL_M_PRODUCTINFO = "101";
        public  const string TAG_GETALL_M_ACCOUNTINFO = "102";
        public  const string TAG_GETALL_M_CATEGORYINFO = "103";
        public  const string TAG_GETALL_M_PRODUCTINFOWITHIMPORTDATA = "104";
        public const string TAG_GETALL_M_SUPPLIERINFO = "105";
        public const string TAG_GETALL_M_PRODUCTINFOWITHIMPORTDATA_ONWAITING = "106";
        public const string TAG_GETALL_M_CITYINFO = "107";
        public const string TAG_GETALL_M_DISTRICTINFO = "108";
        public const string TAG_GETALL_M_WARDINFO = "109";

        public const string TAG_GETALL_M_PRODUCTINFO_BYID = "150";
        #endregion

        #region Update TAG
        public const string TAG_UPDATE_M_PRODUCTINFO = "201";
        public const string TAG_UPDATE_T_IMPORTPRODUCT = "202";

        #endregion
    }
}
