
using System.ComponentModel;
using System.Linq.Expressions;
namespace LayoutLesson.Class
{
    public class CheckInfo:INotifyPropertyChanged
    {
        private string checkName;

        public string CheckName
        {
            get { return checkName; }
            set { checkName = value; }
        }
        private bool isCheck;

        public bool IsCheck
        {
            get { return isCheck; }
            set { isCheck = value; OnPropertyChanged(new PropertyChangedEventArgs("IsCheck")); }
        }
        private float newResult;

        public float NewResult
        {
            get { return newResult; }
            set { 
                newResult = value;
                if (newResult < 50 || newResult > 150)
                    resolved = false;
            }
        }
        private float oldResult;

        public float OldResult
        {
            get { return oldResult; }
            set { oldResult = value; }
        }
        private float average;

        public float Average
        {
            get { return average; }
            set { average = value; }
        }
        private bool resolved;

        public bool Resolved
        {
            get { return resolved; }
            set { resolved = value; OnPropertyChanged(new PropertyChangedEventArgs("Resolved")); }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this,e);
            }
        }
        
    }
}
