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
        public static List<MenuItem> MenuItems = new List<MenuItem>
        {
            new MenuItem{
                Name = "Item 1",
                Action = "Action 1",
                SubMenuItems = new List<SubMenuItem>{
                    new SubMenuItem{
                        Name = "Subitem 1",
                        Action = "Action 1_1"
                    }
                }
            },
            new MenuItem{
                Name = "Item 2",
                Action = "Action 2",
                SubMenuItems = new List<SubMenuItem>{
                    new SubMenuItem{
                        Name = "Subitem 2",
                        Action = "Action 2_1"
                    }
                }
            }
        };
    }
}
