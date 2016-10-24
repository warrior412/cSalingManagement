using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAPITestAPP
{
    public class tblTemp
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Age { get; set; }
        public string PictureURI { get; set; }
    }
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


    public enum StatusCodes : int
    {
        OK = 0,
        NO_DATA = 1,
        DUPLICATE_EMAIL = 2,
        DUPLICATE_TEL = 3,
        TABLE_READY = 101,
        TABLE_WAIT = 102,
        TABLE_EMPTY = 103,
        TABLE_CHANGED_ISEMPTY = 104,

        DOUBLE_ORDER = 201,

        UNKNOW_ERROR = 999,

        MAIL_SERVER_NOTFOUND = 202,
        MAIL_NOT_VALID = 203,
        MAIL_GREYLIST = 204,
        MAIL_NOT_EMAIL = 205,
        MAIL_DOMAIN_NOTFOUND = 201,

        DO_ORDER_FAILED = 210,
        ISEXITS = 211

    }
}
