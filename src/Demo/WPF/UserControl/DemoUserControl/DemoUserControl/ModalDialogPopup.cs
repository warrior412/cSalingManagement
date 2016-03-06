using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;


namespace DemoUserControl
{
    /// <summary>
    /// Mapping controls to properties
    /// </summary>
    [TemplatePart(Name = "content", Type = typeof(Grid))]
    [TemplatePart(Name = "contentHost", Type = typeof(ContentPresenter))]
    [TemplatePart(Name = "dialog", Type = typeof(Popup))]


    public class ModalDialogPopup:ContentControl
    {
        /// <summary>
        /// Register DependencyProperty named IsOpen
        /// </summary>
        public static readonly DependencyProperty IsOpenProperty =
         DependencyProperty.Register("IsOpen", typeof(bool), typeof(ModalDialogPopup),
         new PropertyMetadata(false, new PropertyChangedCallback(OnOpenChanged)));


        #region Properties

        static FrameworkElement rootElement;


        Button buttonCancel;
        Button buttonOK;
        Grid content;
        ContentPresenter contentHost;
        TextBlock titleTextBlock;
        
       
        Popup dialog;
        PopupAnimation _popupAnimation = PopupAnimation.Slide;

        bool flagIsLoaded;
        bool _showCancelButton = false;
        bool _showOKButton = true;
        
        


        #region Getter/Setter
        public bool ShowCancelButton
        {
            get { return _showCancelButton; }
            set { _showCancelButton = value; }
        }


        public bool ShowOKButton
        {
            get { return _showOKButton; }
            set { _showOKButton = value; }
        }
        /// <summary>
        /// Get,Set value for Dependency property IsOpen 
        /// </summary>
        public bool IsOpen
        {
            get { return (bool)this.GetValue(IsOpenProperty); }
            set { this.SetValue(IsOpenProperty, value); }
        }
        public ContentPresenter ContentHost
        {
            get { return contentHost; }
            set { contentHost = value; }
        }
        public PopupAnimation PopupAnimation
        {
            get { return _popupAnimation; }
            set { _popupAnimation = value; }
        }

        public Control HostedContent
        {
            get;
            set;
        }

        #endregion

        #region Declaration Events

        public event EventHandler Cancel;
        public event EventHandler Ok;

        #endregion Events
        #endregion

        static ModalDialogPopup()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(ModalDialogPopup),
            new FrameworkPropertyMetadata(typeof(ModalDialogPopup)));
        }


        #region Method
        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            //Binding Controls from Control template (*.xaml)
            dialog = GetTemplateChild("dialog") as Popup;
            content = GetTemplateChild("content") as Grid;
            contentHost = GetTemplateChild("contentHost") as ContentPresenter;
            buttonOK = GetTemplateChild("buttonOK") as Button;
            buttonCancel = GetTemplateChild("buttonCancel") as Button;
            titleTextBlock = GetTemplateChild("textBlockTitle") as TextBlock;

            if (dialog != null)
            {
                dialog.PopupAnimation = this.PopupAnimation;
                dialog.Closed += new System.EventHandler(dialog_Closed);
                Loaded += new RoutedEventHandler(ModalDialogHost_Loaded);
                Unloaded += new RoutedEventHandler(ModalDialogHost_Unloaded);
            }
            if (content != null)
            {
                content.Background = this.Background;
            }
            if (buttonOK != null)
            {
                if (ShowOKButton)
                {
                    buttonOK.Click += new RoutedEventHandler(buttonOK_Click);
                    buttonOK.Content = "OK";
                }
                buttonOK.Visibility = ConvertBoolToVisibility(ShowOKButton);
            }
            if (buttonCancel != null)
            {
                if (ShowCancelButton)
                {
                    buttonCancel.Click += new RoutedEventHandler(buttonCancel_Click);
                    buttonCancel.Content = "Cancel";
                }
                buttonCancel.Visibility = ConvertBoolToVisibility(ShowCancelButton);
            }
            if (contentHost != null)
            {
                contentHost.Content = HostedContent;
            }
            if (titleTextBlock != null)
            {
                titleTextBlock.Text = "Title";
            }
        }
       
        void Show()
        {
            dialog.IsOpen = true;
            //myAdorner.Visibility = Visibility.Visible;
            Reposition();
        }
        void Close()
        {
            dialog.IsOpen = false;
            //if (!IsDesignMode)
            //{
            //    myAdorner.Visibility = Visibility.Hidden;
            //}
        }
        
        void Deque()
        {
            IsOpen = false;
            //popupList.Remove(this);
            //int count = popupList.Count;
            //if (count == 0)
            //{
            //    myAdorner.Visibility = Visibility.Hidden;
            //    return;
            //}
            //ModalDialogPopup top = popupList[count - 1];
            //top.IsOpen = true;
        }


        /// <summary>
        /// Calculates popup's position
        /// </summary>
        void Reposition()
        {
            EnsureRootElement();
            if (rootElement == null)
            {
                throw new Exception("ModalDialogPopup was unable to locate the root element.");
            }
            FrameworkElement elem = (FrameworkElement)dialog.Child;
            double actualX = (rootElement.ActualWidth / 2) - (elem.ActualWidth / 2);
            double actualY = (rootElement.ActualHeight / 2) - (elem.ActualHeight / 2);

            dialog.HorizontalOffset = Math.Abs(actualX);
            dialog.VerticalOffset = Math.Abs(actualY);
        }
        void EnsureRootElement()
        {
            if (rootElement != null) return;

            rootElement = this.Parent as FrameworkElement;
            while (rootElement != null)
            {
                if (rootElement.Parent is Window)
                {
                    //we just want the direct child element of our window
                    //this is our root element.
                    break;
                }
                rootElement = rootElement.Parent as FrameworkElement;
            }
        }
        static Visibility ConvertBoolToVisibility(bool value)
        {
            return value ? Visibility.Visible : Visibility.Collapsed;
        }


        #endregion


        #region Event
        void ModalDialogHost_Loaded(object sender, RoutedEventArgs e)
        {
            flagIsLoaded = true;
            dialog.Opened += new EventHandler(dialog_Opened);
            dialog.Closed += new EventHandler(dialog_Closed);

            EnsureRootElement();
            //if (!IsDesignMode)
            //{
            //    if (shell == null)
            //    {
            //        shell = ((Window)rootElement.Parent);
            //        shell.LocationChanged += new System.EventHandler(Shell_LocationChanged);
            //        shell.SizeChanged += new SizeChangedEventHandler(shell_SizeChanged);
            //        shell.StateChanged += new EventHandler(shell_StateChanged);
            //        shell.Deactivated += new EventHandler(shell_Deactivated);
            //        shell.Activated += new EventHandler(shell_Activated);
            //        oldLeft = shell.Left;
            //        oldTop = shell.Top;
            //    }

            //    if (myAdorner == null)
            //    {
            //        myAdorner = AdornerLayer.GetAdornerLayer(rootElement);
            //        myAdorner.Visibility = Visibility.Hidden;
            //        myAdorner.Add(this.Shader);
            //    }
            //}
            //first set PlacementTarget and Placement
            if (rootElement != null)
            {
                dialog.PlacementTarget = rootElement;
                dialog.Placement = PlacementMode.Relative;
            }

            //and then only attempt to open and reposition, otherwise
            //only a portion of the dialog is rendered
            //IsOpen = isOpenCache;
            if (IsOpen)
            {
                Show();
            }
        }

        void ModalDialogHost_Unloaded(object sender, RoutedEventArgs e)
        {
            Close();
        }
        void dialog_Closed(object sender, EventArgs e)
        {
        }

        void dialog_Opened(object sender, EventArgs e)
        {
            //foreach (ModalDialogPopup p in popupList)
            //{
            //    if (p != this && p.IsOpen)
            //    {
            //        p.IsOpen = false;
            //    }
            //}
        }
        void buttonCancel_Click(object sender, RoutedEventArgs e)
        {
            Deque();
            OnCancel(EventArgs.Empty);
        }

        void buttonOK_Click(object sender, RoutedEventArgs e)
        {
            Deque();
            OnOk(EventArgs.Empty);
        }
        protected virtual void OnCancel(EventArgs e)
        {
            if (Cancel != null)
            {
                Cancel(this, e);
            }
        }

        protected virtual void OnOk(EventArgs e)
        {
            if (Ok != null)
            {
                Ok(this, e);
            }
        }
        /// <summary>
        /// OnOpenChanged Event
        /// </summary>
        /// <param name="d"> ModelDialogPopup</param>
        /// <param name="e"></param>
        private static void OnOpenChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var context = (ModalDialogPopup)d;
            //if (context.IsDesignMode)
            //{
            //    //we don't want the popup to display above all windows
            //    //in vs.net designer when in designview
            //    return;
            //}
            var isOpen = (bool)e.NewValue;

            //depdendency property changed callback fires
            //too soon, before OnApplyTemplate. so workaround :|
            if (context.flagIsLoaded == true)
            {
                if (isOpen)
                {
                    context.Show();
                }
                else
                {
                    context.Close();
                }
            }
            else if (isOpen)
            {
                //context.isOpenCache = isOpen;
                context.IsOpen = !isOpen;
            }
        } 
        #endregion
    }
}
