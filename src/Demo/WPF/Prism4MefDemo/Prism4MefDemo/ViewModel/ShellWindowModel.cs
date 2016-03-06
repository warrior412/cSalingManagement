using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Input;
using Microsoft.Practices.Prism.Commands;

namespace Prism4MefDemo.ViewModel
{
    [Export(typeof(ShellWindowModel))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class ShellWindowModel
    {
        [ImportingConstructor]
        public ShellWindowModel()
        {
            ExitCommand = new DelegateCommand(OnExited);
        }

        public ICommand ExitCommand { get; private set; }

        private void OnExited()
        {
            Application.Current.Shutdown();
        }
    }
}
