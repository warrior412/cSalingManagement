﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cSalingManagement.Model
{
    public class MenuItem
    {
        public string Name { get; set; }
        public string Action { get; set; }
        public List<SubMenuItem> SubMenuItems { get; set; }
    }

    public class SubMenuItem 
    {
        public string Name { get; set; }
        public Action Action { get; set; }
    }
    public class Action
    {
        public string RegionName { get; set; }
        public string ModuleName { get; set; }
        public string ViewName { get; set; }
    }
}
