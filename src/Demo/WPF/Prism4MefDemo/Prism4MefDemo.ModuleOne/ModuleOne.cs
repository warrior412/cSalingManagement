using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.Prism.MefExtensions.Modularity;
using Microsoft.Practices.Prism.Modularity;

namespace Prism4MefDemo.ModuleOne
{
    [ModuleExport(typeof(ModuleOne))]
    public class ModuleOne : IModule
    {
        public void Initialize()
        {
        }
    }
}
