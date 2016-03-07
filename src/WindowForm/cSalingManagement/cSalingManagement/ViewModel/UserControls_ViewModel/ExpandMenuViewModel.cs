
using cSalingManagement.Common;
using cSalingManagement.Model;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cSalingManagement.ViewModel.UserControls_ViewModel
{
    public class ExpandMenuViewModel : BindableBase
    {
        public List<MenuItem> MenuItems { get; set; }
        public ExpandMenuViewModel()
        {
            this.MenuItems = SalingManagementConstant.MenuItems;
        }
    }
}
