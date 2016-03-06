using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LayoutLesson.Class
{
    public class Record
    {
        private ObservableCollection<CheckInfo> checkInfos = null;

        public ObservableCollection<CheckInfo> CheckInfos
        {
            get { return checkInfos; }
            set { checkInfos = value; }
        }
        private string recordID;

        public string RecordID
        {
            get { return recordID; }
            set { recordID = value; }
        }
        private string customername;

        public string Customername
        {
            get { return customername; }
            set { customername = value; }
        }
        private string memo;

        public string Memo
        {
            get { return memo; }
            set { memo = value; }
        }
        private bool gender;

        public bool Gender
        {
            get { return gender; }
            set { gender = value; }
        }
        private int type;

        public int Type
        {
            get { return type; }
            set { type = value; }
        }
        private string comment;

        public string Comment
        {
            get { return comment; }
            set { comment = value; }
        }

        
    }
}
