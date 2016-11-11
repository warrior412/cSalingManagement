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

        #region Insert TAG
        public  const string TAG_INSERT_M_PRODUCTINFO = "1";
        public  const string TAG_INSERT_M_ACCOUNTINFO = "2";
        public  const string TAG_INSERT_M_CATEGORYINFO = "3"; 
        #endregion


        #region Select TAG
        public  const string TAG_GETALL_M_PRODUCTINFO = "101";
        public  const string TAG_GETALL_M_ACCOUNTINFO = "102";
        public  const string TAG_GETALL_M_CATEGORYINFO = "103";

        public const string TAG_GETALL_M_PRODUCTINFO_BYID = "104";
        #endregion
    }
}
