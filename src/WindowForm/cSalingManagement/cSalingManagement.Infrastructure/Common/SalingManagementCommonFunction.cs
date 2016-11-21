using cSalingManagement.Common;
using cSalingManagement.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace cSalingManagement.Infrastructure.Common
{
    public class SalingManagementCommonFunction
    {
        private static SalingManagementCommonFunction _instance = null;
        private string _currentLanguage = "";

        public string CurrentLanguage
        {
            get { return _currentLanguage; }
            set {
                _currentLanguage = value;
                //Reload language
                BindingLanguageResourceFile();
            }
        }


        public static SalingManagementCommonFunction GetInstance()
        {
            if (_instance == null)
            {
                _instance = new SalingManagementCommonFunction();
            }
            return _instance;
        }

        public void BindingLanguageResourceFile()
        {
            ResourceDictionary rs = new ResourceDictionary();
            rs.Source = new Uri("pack://application:,,,/cSalingManagement.Resources;component/Resources/" + CurrentLanguage + ".xaml");
            Application.Current.Resources.MergedDictionaries.Add(rs);
        }
        public string GetResourceLanguageStringByKey(string key)
        {
            ResourceDictionary rs = new ResourceDictionary();
            rs.Source = new Uri("pack://application:,,,/cSalingManagement.Resources;component/Resources/" + CurrentLanguage + ".xaml");
            return rs[key] == null ? rs["KeyNotFound"].ToString() : rs[key].ToString();
        }
        #region Menu Items
        public List<MenuItem> GetListMenuItem()
        {
            return new List<MenuItem>{
            new MenuItem{
                Name = SalingManagementCommonFunction.GetInstance().GetResourceLanguageStringByKey("ProductManagement"),
                Action = null,
                SubMenuItems = new List<SubMenuItem>{
                    new SubMenuItem{
                        Name = SalingManagementCommonFunction.GetInstance().GetResourceLanguageStringByKey("ProductList"),
                        Action = new cSalingManagement.Model.Action{
                            ModuleName= SalingManagementConstant.STRING_MODULE_PRODUCT,
                            RegionName= SalingManagementConstant.STRING_REGION_CONTENT,
                            ViewName = SalingManagementConstant.STRING_VIEW_PRODUCT_LIST
                        }
                    },
                    new SubMenuItem{
                        Name = SalingManagementCommonFunction.GetInstance().GetResourceLanguageStringByKey("ProductAdd"),
                        Action = new cSalingManagement.Model.Action{
                            ModuleName= SalingManagementConstant.STRING_MODULE_PRODUCT,
                            RegionName= SalingManagementConstant.STRING_REGION_CONTENT,
                            ViewName = SalingManagementConstant.STRING_VIEW_PRODUCT_DETAIL
                        }
                    },
                    new SubMenuItem{
                        Name = SalingManagementCommonFunction.GetInstance().GetResourceLanguageStringByKey("ProductImportRequest"),
                        Action = new cSalingManagement.Model.Action{
                            ModuleName= SalingManagementConstant.STRING_MODULE_PRODUCT,
                            RegionName= SalingManagementConstant.STRING_REGION_CONTENT,
                            ViewName = SalingManagementConstant.STRING_VIEW_PRODUCT_IMPORT_REQUEST
                        }
                    }
                }
            },
            new MenuItem{
                Name = SalingManagementCommonFunction.GetInstance().GetResourceLanguageStringByKey("OrderManagement"),
                Action = null,
                SubMenuItems = new List<SubMenuItem>{
                     new SubMenuItem{
                        Name = SalingManagementCommonFunction.GetInstance().GetResourceLanguageStringByKey("OrderAddNew"),
                        Action = new cSalingManagement.Model.Action{
                            ModuleName= SalingManagementConstant.STRING_MODULE_ORDER,
                            RegionName= SalingManagementConstant.STRING_REGION_CONTENT,
                            ViewName = SalingManagementConstant.STRING_VIEW_ORDER_ADD
                        }
                    }
                    ,
                     new SubMenuItem{
                        Name = SalingManagementCommonFunction.GetInstance().GetResourceLanguageStringByKey("OrderList"),
                        Action = new cSalingManagement.Model.Action{
                            ModuleName= SalingManagementConstant.STRING_MODULE_ORDER,
                            RegionName= SalingManagementConstant.STRING_REGION_CONTENT,
                            ViewName = SalingManagementConstant.STRING_VIEW_ORDER_LIST
                        }
                    }
                }
            },
            new MenuItem{
                Name = SalingManagementCommonFunction.GetInstance().GetResourceLanguageStringByKey("CustomerManagement"),
                Action = null,
                SubMenuItems = new List<SubMenuItem>{
                     new SubMenuItem{
                        Name = SalingManagementCommonFunction.GetInstance().GetResourceLanguageStringByKey("CustomerList"),
                        Action = new cSalingManagement.Model.Action{
                            ModuleName= SalingManagementConstant.STRING_MODULE_CUSTOMER,
                            RegionName= SalingManagementConstant.STRING_REGION_CONTENT,
                            ViewName = SalingManagementConstant.STRING_VIEW_CUSTOMER_LIST
                        }
                    }
                    ,
                     new SubMenuItem{
                        Name = SalingManagementCommonFunction.GetInstance().GetResourceLanguageStringByKey("CustomerDetail"),
                        Action = new cSalingManagement.Model.Action{
                            ModuleName= SalingManagementConstant.STRING_MODULE_CUSTOMER,
                            RegionName= SalingManagementConstant.STRING_REGION_CONTENT,
                            ViewName = SalingManagementConstant.STRING_VIEW_CUSTOMER_DETAIL
                        }
                    }

                }
            }
            };
        }
        #endregion
    }
}
