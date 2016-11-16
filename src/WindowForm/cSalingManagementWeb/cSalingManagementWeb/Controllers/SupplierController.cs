using BusinessEntities;
using BusinessEntities.ADO;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace cSalingManagementWeb.Controllers
{
    public class SupplierController:ApiController
    {
        // GET api/Supplier/SelectAll_M_Supplier
        [HttpGet]
        public string SelectAll_M_Supplier()
        {
            JsonObjectData returnData = new JsonObjectData();
            Status status = new Status();
            List<M_Supplier> resultReturn = null;
            status.StatusCode = StatusCodes.NO_DATA;
            try
            {
                resultReturn = new M_SupplierADO().SelectAll_M_SupplierInfo().ToList();
                status.StatusCode = StatusCodes.OK;
                status.Count = resultReturn.Count().ToString();
            }
            catch (Exception ex)
            {
                status.StatusMsg = ex.Message;
                status.StatusCode = StatusCodes.UNKNOW_ERROR;
            }
            returnData.Status = status;
            returnData.Data = resultReturn;
            JsonSerializerSettings st = new JsonSerializerSettings();
            return JsonConvert.SerializeObject(returnData, Formatting.None, st);
        }
    }
}