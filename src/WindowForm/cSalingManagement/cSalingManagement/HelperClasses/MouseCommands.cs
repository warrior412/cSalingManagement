using System;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Input;

namespace ExpandingMenu.HelperClasses
{
    /// <summary>
    /// Provides support for binding mouse events to commands.
    /// </summary>
    public static class MouseCommands
    {
        public static readonly DependencyProperty ControlMouseCommandParameterProperty =
            DependencyProperty.RegisterAttached("ControlMouseCommandParameter", typeof(object), typeof(MouseCommands), new FrameworkPropertyMetadata(new PropertyChangedCallback(OnMouseCommandChanged)));

        public static readonly DependencyProperty ControlMouseCommandProperty =
            DependencyProperty.RegisterAttached("ControlMouseCommand", typeof(ICommand), typeof(MouseCommands), new FrameworkPropertyMetadata(new PropertyChangedCallback(OnMouseCommandChanged)));

        public static readonly DependencyProperty MouseCommandActionProperty =
            DependencyProperty.RegisterAttached("MouseCommandAction", typeof(MouseAction), typeof(MouseCommands), new FrameworkPropertyMetadata(MouseAction.LeftClick, new PropertyChangedCallback(OnMouseCommandChanged)));

        public static readonly DependencyProperty MouseCommandParameterProperty =
            DependencyProperty.RegisterAttached("MouseCommandParameter", typeof(object), typeof(MouseCommands), new FrameworkPropertyMetadata(new PropertyChangedCallback(OnMouseCommandChanged)));

        public static readonly DependencyProperty MouseCommandProperty =
            DependencyProperty.RegisterAttached("MouseCommand", typeof(ICommand), typeof(MouseCommands), new FrameworkPropertyMetadata(new PropertyChangedCallback(OnMouseCommandChanged)));

        public static readonly DependencyProperty ShiftMouseCommandParameterProperty =
            DependencyProperty.RegisterAttached("ShiftMouseCommandParameter", typeof(object), typeof(MouseCommands), new FrameworkPropertyMetadata(new PropertyChangedCallback(OnMouseCommandChanged)));

        public static readonly DependencyProperty ShiftMouseCommandProperty =
            DependencyProperty.RegisterAttached("ShiftMouseCommand", typeof(ICommand), typeof(MouseCommands), new FrameworkPropertyMetadata(new PropertyChangedCallback(OnMouseCommandChanged)));

        /// <summary>
        /// Gets the control mouse command.
        /// </summary>
        /// <param name="element">The element.</param>
        /// <returns>A mouse command.</returns>
        public static ICommand GetControlMouseCommand(UIElement element)
        {
            if (element == null)
            {
                throw new ArgumentNullException("element");
            }

            return (ICommand)element.GetValue(ControlMouseCommandProperty);
        }

        /// <summary>
        /// Gets the control mouse command parameter.
        /// </summary>
        /// <param name="element">The element.</param>
        /// <returns>A mouse command parameter.</returns>
        public static object GetControlMouseCommandParameter(UIElement element)
        {
            if (element == null)
            {
                throw new ArgumentNullException("element");
            }

            return element.GetValue(ControlMouseCommandParameterProperty);
        }

        /// <summary>
        /// Gets the mouse command.
        /// </summary>
        /// <param name="element">The element.</param>
        /// <returns>A mouse command.</returns>
        public static ICommand GetMouseCommand(UIElement element)
        {
            if (element == null)
            {
                throw new ArgumentNullException("element");
            }

            return (ICommand)element.GetValue(MouseCommandProperty);
        }

        /// <summary>
        /// Gets the mouse command action.
        /// </summary>
        /// <param name="element">The element.</param>
        /// <returns>A mouse command action.</returns>
        public static MouseAction GetMouseCommandAction(UIElement element)
        {
            if (element == null)
            {
                throw new ArgumentNullException("element");
            }

            return (MouseAction)element.GetValue(MouseCommandActionProperty);
        }

        /// <summary>
        /// Gets the mouse command parameter.
        /// </summary>
        /// <param name="element">The element.</param>
        /// <returns>The mouse command parameter.</returns>
        public static object GetMouseCommandParameter(UIElement element)
        {
            if (element == null)
            {
                throw new ArgumentNullException("element");
            }

            return element.GetValue(MouseCommandParameterProperty);
        }

        /// <summary>
        /// Gets the shift mouse command.
        /// </summary>
        /// <param name="element">The element.</param>
        /// <returns>The mouse command.</returns>
        public static ICommand GetShiftMouseCommand(UIElement element)
        {
            if (element == null)
            {
                throw new ArgumentNullException("element");
            }

            return (ICommand)element.GetValue(ShiftMouseCommandProperty);
        }

        /// <summary>
        /// Gets the shift mouse command parameter.
        /// </summary>
        /// <param name="element">The element.</param>
        /// <returns>The mouse command.</returns>
        public static object GetShiftMouseCommandParameter(UIElement element)
        {
            if (element == null)
            {
                throw new ArgumentNullException("element");
            }

            return element.GetValue(ShiftMouseCommandParameterProperty);
        }

        /// <summary>
        /// Sets the control mouse command.
        /// </summary>
        /// <param name="element">The element.</param>
        /// <param name="value">The value.</param>
        public static void SetControlMouseCommand(UIElement element, ICommand value)
        {
            if (element == null)
            {
                throw new ArgumentNullException("element");
            }

            element.SetValue(ControlMouseCommandProperty, value);
        }

        /// <summary>
        /// Sets the control mouse command parameter.
        /// </summary>
        /// <param name="element">The element.</param>
        /// <param name="value">The value.</param>
        public static void SetControlMouseCommandParameter(UIElement element, object value)
        {
            if (element == null)
            {
                throw new ArgumentNullException("element");
            }

            element.SetValue(ControlMouseCommandParameterProperty, value);
        }

        /// <summary>
        /// Sets the mouse command.
        /// </summary>
        /// <param name="element">The element.</param>
        /// <param name="value">The value.</param>
        public static void SetMouseCommand(UIElement element, ICommand value)
        {
            if (element == null)
            {
                throw new ArgumentNullException("element");
            }

            element.SetValue(MouseCommandProperty, value);
        }

        /// <summary>
        /// Sets the mouse command action.
        /// </summary>
        /// <param name="element">The element.</param>
        /// <param name="value">The value.</param>
        public static void SetMouseCommandAction(UIElement element, MouseAction value)
        {
            if (element == null)
            {
                throw new ArgumentNullException("element");
            }

            element.SetValue(MouseCommandActionProperty, value);
        }

        /// <summary>
        /// Sets the mouse command parameter.
        /// </summary>
        /// <param name="element">The element.</param>
        /// <param name="value">The value.</param>
        public static void SetMouseCommandParameter(UIElement element, object value)
        {
            if (element == null)
            {
                throw new ArgumentNullException("element");
            }

            element.SetValue(MouseCommandParameterProperty, value);
        }

        /// <summary>
        /// Sets the shift mouse command.
        /// </summary>
        /// <param name="element">The element.</param>
        /// <param name="value">The value.</param>
        public static void SetShiftMouseCommand(UIElement element, object value)
        {
            if (element == null)
            {
                throw new ArgumentNullException("element");
            }

            element.SetValue(ShiftMouseCommandProperty, value);
        }

        /// <summary>
        /// Sets the shift mouse command parameter.
        /// </summary>
        /// <param name="element">The element.</param>
        /// <param name="value">The value.</param>
        public static void SetShiftMouseCommandParameter(UIElement element, object value)
        {
            if (element == null)
            {
                throw new ArgumentNullException("element");
            }

            element.SetValue(ShiftMouseCommandParameterProperty, value);
        }

        /// <summary>
        /// Adds the mouse bindings.
        /// </summary>
        /// <param name="element">The element.</param>
        private static void AddMouseBindings(UIElement element)
        {
            var mouseCommandAction = GetMouseCommandAction(element);

            var binding1 = new MouseBinding
            {
                Gesture = new MouseGesture(mouseCommandAction, ModifierKeys.None),
                Command = KeyboardModifierChain.Instance,
                CommandParameter = element
            };

            var binding2 = new MouseBinding
            {
                Gesture = new MouseGesture(mouseCommandAction, ModifierKeys.Control),
                Command = KeyboardModifierChain.Instance,
                CommandParameter = element
            };

            var binding3 = new MouseBinding
            {
                Gesture = new MouseGesture(mouseCommandAction, ModifierKeys.Shift),
                Command = KeyboardModifierChain.Instance,
                CommandParameter = element
            };

            element.InputBindings.Add(binding1);
            element.InputBindings.Add(binding2);
            element.InputBindings.Add(binding3);
        }

        /// <summary>
        /// Called when [mouse command changed].
        /// </summary>
        /// <param name="obj">The dependency object.</param>
        /// <param name="args">The <see cref="System.Windows.DependencyPropertyChangedEventArgs"/> instance containing the event data.</param>
        private static void OnMouseCommandChanged(DependencyObject obj, DependencyPropertyChangedEventArgs args)
        {
            RefreshMouseBinding((UIElement)obj);
        }

        /// <summary>
        /// Refreshes the mouse binding.
        /// </summary>
        /// <param name="element">The element.</param>
        private static void RefreshMouseBinding(UIElement element)
        {
            if (GetMouseCommand(element) != null)
            {
                var flag = false;

                foreach (var binding in element.InputBindings)
                {
                    var mouseBinding = binding as MouseBinding;

                    if (mouseBinding != null)
                    {
                        UpdateMouseBinding(element, mouseBinding);
                        flag = true;
                    }
                }

                if (!flag)
                {
                    AddMouseBindings(element);
                }
            }
        }

        /// <summary>
        /// Updates the mouse binding.
        /// </summary>
        /// <param name="element">The element.</param>
        /// <param name="mouseBinding">The mouse binding.</param>
        private static void UpdateMouseBinding(UIElement element, MouseBinding mouseBinding)
        {
            var gesture = (MouseGesture)mouseBinding.Gesture;
            gesture.MouseAction = GetMouseCommandAction(element);
            mouseBinding.Command = KeyboardModifierChain.Instance;
            mouseBinding.CommandParameter = element;
        }

        /// <summary>
        /// Provides command support for keyboard.
        /// </summary>
        private class KeyboardModifierChain : ICommand
        {
            private static KeyboardModifierChain _instance;

            /// <summary>
            /// Occurs when changes occur that affect whether or not the command should execute.
            /// </summary>
            event EventHandler ICommand.CanExecuteChanged
            {
                add { }
                remove { }
            }

            /// <summary>
            /// Gets the instance.
            /// </summary>
            public static KeyboardModifierChain Instance
            {
                get
                {
                    return _instance ?? (_instance = new KeyboardModifierChain());
                }
            }

            /// <summary>
            /// Gets the state of the keyboard.
            /// </summary>
            /// <param name="lpKeyState">The 256-byte array that receives the status data for each virtual key.</param>
            /// <returns>If the function succeeds, the return value is nonzero. If the function fails, the return value is zero.</returns>
            [return: MarshalAs(UnmanagedType.Bool)]
            [DllImport("user32.dll")]
            private static extern bool GetKeyboardState(byte[] lpKeyState);

            /// <summary>
            /// Gets the modifier keys.
            /// </summary>
            private static ModifierKeys ModifierKeys
            {
                get
                {
                    var lpKeyState = new byte[0x100];

                    GetKeyboardState(lpKeyState);

                    var none = ModifierKeys.None;

                    if ((lpKeyState[0x10] & 0x80) == 0x80)
                    {
                        none |= ModifierKeys.Shift;
                    }

                    if ((lpKeyState[0x11] & 0x80) == 0x80)
                    {
                        none |= ModifierKeys.Control;
                    }

                    if ((lpKeyState[0x12] & 0x80) == 0x80)
                    {
                        none |= ModifierKeys.Alt;
                    }

                    if (((lpKeyState[0x5b] & 0x80) != 0x80) && ((lpKeyState[0x5c] & 0x80) != 0x80))
                    {
                        return none;
                    }

                    return none | ModifierKeys.Windows;
                }
            }

            /// <summary>
            /// Defines the method that determines whether the command can execute in its current state.
            /// </summary>
            /// <param name="parameter">Data used by the command.  If the command does not require data to be passed, this object can be set to null.</param>
            /// <returns>
            /// true if this command can be executed; otherwise, false.
            /// </returns>
            public bool CanExecute(object parameter)
            {
                return true;
            }

            /// <summary>
            /// Defines the method to be called when the command is invoked.
            /// </summary>
            /// <param name="parameter">Data used by the command.  If the command does not require data to be passed, this object can be set to null.</param>
            public void Execute(object parameter)
            {
                var element = parameter as UIElement;

                if (element != null)
                {
                    var modifierKeys = ModifierKeys;

                    if (((modifierKeys != ModifierKeys.Control) || !ExecuteCommand(element, GetControlMouseCommand, GetControlMouseCommandParameter)) &&
                        ((modifierKeys != ModifierKeys.Shift) || !ExecuteCommand(element, GetShiftMouseCommand, GetShiftMouseCommandParameter)))
                    {
                        ExecuteCommand(element, GetMouseCommand, GetMouseCommandParameter);
                    }
                }
            }

            /// <summary>
            /// Executes the command.
            /// </summary>
            /// <param name="element">The element.</param>
            /// <param name="commandAccessor">The command accessor.</param>
            /// <param name="commandParameterAccessor">The command parameter accessor.</param>
            /// <returns>A boolean value indicatin if command has executed.</returns>
            private static bool ExecuteCommand(UIElement element, Func<UIElement, ICommand> commandAccessor, Func<UIElement, object> commandParameterAccessor)
            {
                var command = commandAccessor(element);

                if (command == null)
                {
                    return false;
                }

                var parameter = commandParameterAccessor(element);
                var command2 = command as RoutedCommand;

                if (command2 != null)
                {
                    command2.Execute(parameter, element);
                }
                else
                {
                    command.Execute(parameter);
                }

                return true;
            }
        }
    }
}