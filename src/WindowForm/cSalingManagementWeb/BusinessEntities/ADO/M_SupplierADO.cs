using System;
using System.Collections.Generic;
using System.Data.Objects;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities.ADO
{
    public class M_SupplierADO
    {
        cSalingManagementEntities entities = new cSalingManagementEntities();
        public ObjectResult<M_Supplier> SelectAll_M_SupplierInfo()
        {
            ObjectResult<M_Supplier> resultReturn = null;
            try
            {
                resultReturn = entities.SelectAll_M_Supplier();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return resultReturn;
        }
    }
}
