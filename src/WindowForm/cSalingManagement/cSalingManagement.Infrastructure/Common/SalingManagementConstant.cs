using cSalingManagement.Infrastructure.Common;
using cSalingManagement.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cSalingManagement.Common
{
    public static class SalingManagementConstant
    {
        public static string STRING_REGION_CONTENT = "ContentRegion";
        public static string STRING_REGION_MENU = "MenuRegion";
        public static string STRING_REGION_TITLE = "TitleRegion";


        public static string STRING_MODULE_MENU = "MenuModule";
        public static string STRING_MODULE_TITLE = "TitleModule";
        public static string STRING_MODULE_ORDER = "OrderModule";
        public static string STRING_MODULE_PRODUCT = "ProductModule";

        public static string STRING_VIEW_MENU = "MenuView";
        public static string STRING_VIEW_TITLE = "TitleView";

        public static string STRING_VIEW_ORDER_DETAIL = "OrderDetailView";
        public static string STRING_VIEW_ORDER_ADD = "OrderAddNewView";
        public static string STRING_VIEW_ORDER_LIST = "OrderListView";


        public static string STRING_VIEW_PRODUCT_DETAIL = "ProductDetailView";
        public static string STRING_VIEW_PRODUCT_LIST = "ProductListView";
        public static string STRING_VIEW_PRODUCT_IMPORT_REQUEST = "ProductImportRequestView";
        public static string STRING_VIEW_PRODUCT_ADD = "ProductAddView";

        public static string STRING_VIEW_NEW_REQUEST = "NewRequestView";


        public static double Applicaton_Width = 1024;
        public static double Application_Height = 768;


        public static int STATUS_DELETED = -1;
        public static int STATUS_ONWAITING = 0;
        public static int STATUS_READY = 1;
        
        
    }
}
