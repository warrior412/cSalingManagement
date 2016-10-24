using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAPITestAPP
{
    public class DAOProvider
    {
        public static DAOProvider _instance = null;

        public DAOProvider GetInstance()
        {
            if (_instance == null)
                return new DAOProvider();
            return _instance;
        }

        public void DestroyInstance ()
        {
            if(_instance!=null)
                _instance = null;
        }
    }
}
