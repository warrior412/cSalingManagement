using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.Prism.MefExtensions.Modularity;
using Microsoft.Practices.Prism.Modularity;
using Prism4MefDemo.Infrastructure.Data;
using Prism4MefDemo.Infrastructure.Models;

namespace Prism4MefDemo.ModuleTwo
{
     [ModuleExport(typeof(ModuleTwo))]
    public class ModuleTwo : IModule
    {

         public void Initialize()
         {

         }
    }
}
