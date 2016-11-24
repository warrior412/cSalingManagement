using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cSalingManagement.Infrastructure.Common
{
    public enum StatusCodes : int
    {
        BAD_REQUEST = -1,//URL webservice not found
        NO_DATA = 0,
        OK = 1, //Select
        CREATED = 2, // Inserted
        UPDATED = 3, // Updated
        DELETED = 4, //Deleted
        FILE_FORMAT_ERROR = -2,
        UNKNOW_ERROR = -999
    }
    public  static class SalingManagement_WebServiceTag
    {

        public static string SERVICE_TAG = "SERVICE_TAG";

        public const string TAG_UPLOAD_IMAGES = "0";

        #region Insert TAG
        public  const string TAG_INSERT_M_PRODUCTINFO = "1";
        public  const string TAG_INSERT_M_ACCOUNTINFO = "2";
        public  const string TAG_INSERT_M_CATEGORYINFO = "3";
        public const string TAG_INSERT_T_IMPORTPRODUCTINFO = "4";
        public const string TAG_INSERT_M_CUSTOMERINFO = "5";
        public const string TAG_INSERT_T_ORDERINFO = "6"; 
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
        public const string TAG_GETALL_M_CUSTOMERTYPEINFO = "110";
        public const string TAG_GETALL_M_CUSTOMERINFO = "111";

        public const string TAG_GETALL_M_PRODUCTINFO_BYID = "150";
        public const string TAG_GET_M_CUSTOMERINFO_BYID = "151";
        #endregion

        #region Update TAG
        public const string TAG_UPDATE_M_PRODUCTINFO = "201";
        public const string TAG_UPDATE_T_IMPORTPRODUCT = "202";

        #endregion
    }
}
