using System;
using System.Collections.Generic;
using System.Data.Objects;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities.ADO
{
    public class M_AddressInfoADO
    {
        cSalingManagementEntities entities = new cSalingManagementEntities();
        public ObjectResult<M_City> SelectAll_M_CityInfo()
        {
            ObjectResult<M_City> resultReturn = null;
            try
            {
                resultReturn = entities.SelectAll_M_City();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return resultReturn;
        }

        public ObjectResult<M_District> SelectAll_M_DistrictInfo()
        {
            ObjectResult<M_District> resultReturn = null;
            try
            {
                resultReturn = entities.SelectAll_M_District();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return resultReturn;
        }
        public ObjectResult<M_Ward> SelectAll_M_WardInfo()
        {
            ObjectResult<M_Ward> resultReturn = null;
            try
            {
                resultReturn = entities.SelectAll_M_Ward();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return resultReturn;
        }

        
    }
}
