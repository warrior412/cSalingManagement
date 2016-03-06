
using LayoutLesson.Command;
using System.ComponentModel;
using System.Linq.Expressions;
namespace LayoutLesson.Class
{
    public enum InfoStatus
	{
        NORMAL, //normal
        NOTCHECK,//will not check
        WARNING,//result is over range
        RESOVLED//Warning resolved
	}
    public class CheckInfo:INotifyPropertyChanged
    {
        /// <summary>
        /// Check Item Name
        /// </summary>
        private string checkName;
        public string CheckName
        {
            get { return checkName; }
            set { checkName = value; }
        }
        
        /// <summary>
        /// Will Check = True ; Not Check = False
        /// </summary>
        private bool isCheck;
        public bool IsCheck
        {
            get { return isCheck; }
            set { 
                isCheck = value;
                if (!value)
                    InfoStatus = Class.InfoStatus.NOTCHECK;
                else
                {
                    if ((newResult < 50 || newResult > 150))
                    {
                        InfoStatus = Class.InfoStatus.WARNING;
                    }
                    else
                    {
                        InfoStatus = Class.InfoStatus.NORMAL;
                    }
                }
                
                OnPropertyChanged(new PropertyChangedEventArgs("IsCheck"));
            }
        }
        
        /// <summary>
        /// New result
        /// </summary>
        private float newResult;
        public float NewResult
        {
            get { return newResult; }
            set { 
                newResult = value;
                if (InfoStatus != Class.InfoStatus.NOTCHECK && InfoStatus != Class.InfoStatus.RESOVLED) {
                    if ((newResult < 50 || newResult > 150))
                    {
                        infoStatus = Class.InfoStatus.WARNING;
                    }
                    else
                    {
                        infoStatus = Class.InfoStatus.NORMAL;
                    }
                }
                //Set OnPropertyChanged Delegate
                OnPropertyChanged(new PropertyChangedEventArgs("NewResult"));
            }
        }

        /// <summary>
        /// Old result cannot be changed
        /// </summary>
        private float oldResult;
        public float OldResult
        {
            get { return oldResult; }
            set { oldResult = value; }
        }

        /// <summary>
        /// Older Result cannot be changed
        /// </summary>
        private float average;
        public float Average
        {
            get { return average; }
            set { average = value; }
        }

        /// <summary>
        /// Check item's status
        /// </summary>
        private InfoStatus infoStatus;
        public InfoStatus InfoStatus
        {
            get { return infoStatus; }
            set {
                infoStatus = value;
                // Set OnPropertyChanged Delegate
                OnPropertyChanged(new PropertyChangedEventArgs("InfoStatus"));
            }
        }

        /// <summary>
        /// Implement OnPropertyChanged Delegate
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this,e);
            }
        }

        /// <summary>
        /// Init Command for Result button's click event
        /// </summary>
        itemButton_Command itemCommand = new itemButton_Command();

        public itemButton_Command ItemCommand
        {
            get { return itemCommand; }
        }
    }
}
