using myWebAPIService.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace myWebAPIService.Controllers
{
    public class ProductController : ApiController
    {
        private myWebAPIServiceContext db = new myWebAPIServiceContext();
        private DBSampleEntities2 entities = new DBSampleEntities2();
        // GET api/Product
        public string GetM_ProductAll()
        {
            JsonObjectData returnData = new JsonObjectData();
            Status status = new Status();
            List<sp_SelectMProductAll_Result> _tblProduct = null;
            status.StatusCode = StatusCodes.NO_DATA;
            try
            {


                _tblProduct = entities.sp_SelectMProductAll().ToList<sp_SelectMProductAll_Result>();
                if (_tblProduct != null)
                {
                    status.StatusCode = StatusCodes.OK;
                }
            }
            catch (Exception ex)
            {
                status.StatusMsg = ex.Message;
                status.StatusCode = StatusCodes.UNKNOW_ERROR;
            }
            returnData.Status = status;
            returnData.Data = _tblProduct;
            JsonSerializerSettings st = new JsonSerializerSettings();
            return JsonConvert.SerializeObject(returnData, Formatting.None, st);
        }
    }
}
