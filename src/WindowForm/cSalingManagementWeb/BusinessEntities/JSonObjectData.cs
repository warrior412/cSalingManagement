using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities
{
    public class JsonObjectData
    {
        public Object Status;
        public Object Data;

    }
    public class Status
    {
        private StatusCodes _StatusCode;
        private string _StatusMsg;
        private string _Count;
        public StatusCodes StatusCode
        {
            get { return _StatusCode; }
            set { _StatusCode = value; }

        }
        public string StatusMsg
        {
            get { return _StatusMsg; }
            set { _StatusMsg = value; }

        }

        public string Count
        {
            get { return _Count; }
            set { _Count = value; }

        }
    }


    public enum StatusCodes :int
    {
        BAD_REQUEST = -1,//URL webservice not found
        NO_DATA = 0,
        OK = 1, //Select
        CREATED = 2, // Inserted
        UPDATED = 3, // Updated
        DELETED = 4, //Deleted
        UNKNOW_ERROR = -999
    }
}
