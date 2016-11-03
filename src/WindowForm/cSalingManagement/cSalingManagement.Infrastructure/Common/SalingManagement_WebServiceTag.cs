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
        public  const string TAG_INSERT_MPRODUCTINFO = "1";
        public  const string TAG_INSERT_MACCOUNTINFO = "2";
        public  const string TAG_INSERT_MCATEGORYINFO = "3"; 
        #endregion


        #region Select TAG
        public  const string TAG_GETALL_MPRODUCTINFO = "101";
        public  const string TAG_GETALL_MACCOUNTINFO = "102";
        public  const string TAG_GETALL_MCATEGORYINFO = "103"; 
        #endregion
    }
}
