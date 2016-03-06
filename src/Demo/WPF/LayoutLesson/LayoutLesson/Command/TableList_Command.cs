using LayoutLesson.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace LayoutLesson.Command
{
    /// <summary>
    /// Implement all Command of TableList form
    /// </summary>
    /// 

    public class Finish_Command : ICommand
    {
        /// <summary>
        /// Method to check if Finish button will be enabled or not
        /// //If there is any InfoStatus with Warning value, return false
        /// </summary>
        /// <param name="parameter">Record object</param>
        /// <returns>true(allowed)/False(not allowed)</returns>
        public bool CanExecute(object parameter)
        {
            if (parameter == null)
                return false;
            var record = parameter as Record;
            foreach (var checkInfo in record.CheckInfos)
            {
                if((checkInfo.InfoStatus==Class.InfoStatus.WARNING))
                {
                    return false;
                }
            }
            return  true ;
        }
        /// <summary>
        /// Event will be raised if CanExecute status changes
        /// </summary>
        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        /// <summary>
        /// Executing tasks when CanExecute is true
        /// </summary>
        /// <param name="parameter"></param>
        public void Execute(object parameter)
        {
            MessageBox.Show("Finished !!");   
        }
    }

    public class itemButton_Command : ICommand
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public bool CanExecute(object parameter)
        {
            return true;
        }

        public event EventHandler CanExecuteChanged;
        /// <summary>
        /// Showing dialog to get input value
        /// </summary>
        /// <param name="parameter">DataGrid</param>
        public void Execute(object parameter)
        {
            var gvCheckInfo = parameter as DataGrid;
            frmInputValue dialog = new frmInputValue();
            dialog.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            dialog.txtResult.Text = ((CheckInfo)gvCheckInfo.SelectedItem).NewResult.ToString();
            dialog.ShowDialog();
            if (dialog.DialogResult.HasValue && dialog.DialogResult.Value)
            {
                ((CheckInfo)gvCheckInfo.SelectedItem).NewResult = int.Parse( dialog.txtResult.Text);
            }
            else
            {

            }
        }
    }
}
