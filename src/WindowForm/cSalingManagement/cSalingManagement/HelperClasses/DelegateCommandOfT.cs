using System;
using System.Collections.Generic;
using System.Windows.Input;

namespace ExpandingMenu.HelperClasses
{
    /// <summary>
    /// This class allows delegating the commanding logic to methods passed as parameters,
    /// and enables a View to bind commands to objects that are not part of the element tree.
    /// </summary>
    /// <typeparam name="T">Type of the parameter passed to the delegates</typeparam>
    public class DelegateCommand<T> : ICommand
    {
        #region Fields

        private readonly Action<T> _executeMethod;
        private readonly Func<T, bool> _canExecuteMethod;
        private List<WeakReference> _canExecuteChangedHandlers;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="DelegateCommand&lt;T&gt;"/> class.
        /// </summary>
        /// <param name="executeMethod">The execute method.</param>
        public DelegateCommand(Action<T> executeMethod) : this(executeMethod, null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DelegateCommand&lt;T&gt;"/> class.
        /// </summary>
        /// <param name="executeMethod">The execute method.</param>
        /// <param name="canExecuteMethod">The can execute method.</param>
        public DelegateCommand(Action<T> executeMethod, Func<T, bool> canExecuteMethod)
        {
            if (executeMethod == null)
            {
                throw new ArgumentNullException("executeMethod");
            }

            _executeMethod = executeMethod;
            _canExecuteMethod = canExecuteMethod;
        }

        #endregion

        #region Public Events

        /// <summary>
        ///     ICommand.CanExecuteChanged implementation
        /// </summary>
        public event EventHandler CanExecuteChanged
        {
            add
            {
                CommandManagerHelper.AddWeakReferenceHandler(ref _canExecuteChangedHandlers, value);
            }
            remove
            {
                CommandManagerHelper.RemoveWeakReferenceHandler(_canExecuteChangedHandlers, value);
            }
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Defines the method that determines whether the command can execute in its current state.
        /// </summary>
        /// <param name="parameter">Data used by the command.  If the command does not require data to be passed, this object can be set to null.</param>
        /// <returns>
        /// true if this command can be executed; otherwise, false.
        /// </returns>
        bool ICommand.CanExecute(object parameter)
        {
            // if T is of value type and the parameter is not
            // set yet, then return false if CanExecute delegate
            // exists, else return true
            if (parameter == null && typeof(T).IsValueType)
            {
                return _canExecuteMethod == null;
            }

            return CanExecute((T)parameter);
        }

        /// <summary>
        /// Defines the method to be called when the command is invoked.
        /// </summary>
        /// <param name="parameter">Data used by the command.  If the command does not require data to be passed, this object can be set to null.</param>
        void ICommand.Execute(object parameter)
        {
            Execute((T)parameter);
        }

        /// <summary>
        /// Determines whether this instance can execute the specified parameter.
        /// </summary>
        /// <param name="parameter">The parameter.</param>
        /// <returns>
        /// <c>true</c> if this instance can execute the specified parameter; otherwise, <c>false</c>.
        /// </returns>
        public bool CanExecute(T parameter)
        {
            if (_canExecuteMethod != null)
            {
                return _canExecuteMethod(parameter);
            }

            return true;
        }

        /// <summary>
        /// Executes the specified parameter.
        /// </summary>
        /// <param name="parameter">The parameter.</param>
        public void Execute(T parameter)
        {
            if (_executeMethod != null)
            {
                _executeMethod(parameter);
            }
        }

        /// <summary>
        /// Raises the can execute changed.
        /// </summary>
        public void RaiseCanExecuteChanged()
        {
            OnCanExecuteChanged();
        }

        /// <summary>
        ///     Protected virtual method to raise CanExecuteChanged event
        /// </summary>
        protected virtual void OnCanExecuteChanged()
        {
            CommandManagerHelper.CallWeakReferenceHandlers(_canExecuteChangedHandlers);
        }

        #endregion
    }
}