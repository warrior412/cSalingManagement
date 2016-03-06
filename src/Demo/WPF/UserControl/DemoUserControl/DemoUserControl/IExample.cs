using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace DemoUserControl
{


    public interface IExample
    {
        #region Properties

        /// <summary>
        /// Gets or sets the content to host
        /// </summary>
        Control HostedContent
        {
            get; set;
        }

        /// <summary>
        /// Shows the dialog
        /// </summary>
        bool IsOpen2
        {
            get; set;
        }

        /// <summary>
        /// Gets the dialog title
        /// </summary>
        string Title
        {
            get;
            set;
        }

        #endregion Properties
    }
}
