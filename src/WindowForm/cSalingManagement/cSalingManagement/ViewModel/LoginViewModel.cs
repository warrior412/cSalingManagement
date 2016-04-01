using cSalingManagement.View;
using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace cSalingManagement.ViewModel
{
    public class LoginViewModel : BindableBase
    {

        private string _userName;

        public string UserName
        {
            get { return _userName; }
            set {
                _userName = value;
                SetProperty(ref this._userName, value);
            }
        }

        #region Command
        public ICommand LoginCommand
        {
            get
            {
                return new DelegateCommand<object>(LoginCommandExecute);
            }
        }
        public ICommand ExitCommand
        {
            get
            {
                return new DelegateCommand(ExitCommandExecute);
            }
        }
        public ICommand ClearCommand
        {
            get
            {
                return new DelegateCommand(ClearCommandExecute);
            }
        } 
        #endregion

        #region Delegate Method
        private void LoginCommandExecute(object param)
        {
            Window loginView = param as Window;
            loginView.Hide();
            Bootstrapper bootStrapper = new Bootstrapper();
            bootStrapper.Run();
        }
        public void ExitCommandExecute()
        {
            Application.Current.Shutdown();
        }
        private void ClearCommandExecute()
        {
        } 
        #endregion
    }
}
