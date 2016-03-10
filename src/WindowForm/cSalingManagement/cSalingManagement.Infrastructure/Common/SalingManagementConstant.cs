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


        #region Menu Items
        public static List<MenuItem> MenuItems = new List<MenuItem>
        {
            new MenuItem{
                Name = "Product Management",
                Action = "1",
                SubMenuItems = new List<SubMenuItem>{
                    new SubMenuItem{
                        Name = "Product List",
                        Action = new Model.Action{
                            ModuleName= STRING_MODULE_PRODUCT,
                            RegionName= STRING_REGION_CONTENT,
                            ViewName = STRING_VIEW_PRODUCT_LIST
                        }
                    },
                    new SubMenuItem{
                        Name = "Add Product",
                        Action = new Model.Action{
                            ModuleName= STRING_MODULE_PRODUCT,
                            RegionName= STRING_REGION_CONTENT,
                            ViewName = STRING_VIEW_PRODUCT_DETAIL
                        }
                    }
                }
            },
            new MenuItem{
                Name = "Order Management",
                Action = "2",
                SubMenuItems = new List<SubMenuItem>{
                    new SubMenuItem{
                        Name = "Order Detail",
                        Action = new Model.Action{
                            ModuleName= STRING_MODULE_ORDER,
                            RegionName= STRING_REGION_CONTENT,
                            ViewName = STRING_VIEW_ORDER_DETAIL
                        }
                    },
                     new SubMenuItem{
                        Name = "Create Order",
                        Action = new Model.Action{
                            ModuleName= STRING_MODULE_ORDER,
                            RegionName= STRING_REGION_CONTENT,
                            ViewName = STRING_VIEW_ORDER_ADD
                        }
                    }
                }
            }
        }; 
        #endregion


        
    }
}
