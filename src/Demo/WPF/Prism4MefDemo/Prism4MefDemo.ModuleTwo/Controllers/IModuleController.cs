using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.Prism.Commands;
using Prism4MefDemo.Infrastructure.Data;
using Prism4MefDemo.Infrastructure.Models;

namespace Prism4MefDemo.ModuleTwo.Controllers
{
    public interface IModuleController
    {
        DelegateCommand<ViewObject> ShowViewCommand { get; }
        ViewObjects ViewObjects { get; }
    }
}
