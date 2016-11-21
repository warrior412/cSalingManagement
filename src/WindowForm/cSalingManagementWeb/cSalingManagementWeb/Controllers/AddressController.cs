using BusinessEntities;
using BusinessEntities.ADO;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace cSalingManagementWeb.Controllers
{
    public class AddressController : ApiController
    {
        // GET api/Address/SelectAll_M_CityInfo
        [HttpGet]
        public string SelectAll_M_CityInfo()
        {
            JsonObjectData returnData = new JsonObjectData();
            Status status = new Status();
            List<M_City> resultReturn = null;
            status.StatusCode = StatusCodes.NO_DATA;
            try
            {
                resultReturn = new M_AddressInfoADO().SelectAll_M_CityInfo().ToList();
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

        // GET api/Address/SelectAll_M_DistrictInfo
        [HttpGet]
        public string SelectAll_M_DistrictInfo()
        {
            JsonObjectData returnData = new JsonObjectData();
            Status status = new Status();
            List<M_District> resultReturn = null;
            status.StatusCode = StatusCodes.NO_DATA;
            try
            {
                resultReturn = new M_AddressInfoADO().SelectAll_M_DistrictInfo().ToList();
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

        // GET api/Address/SelectAll_M_WardInfo
        [HttpGet]
        public string SelectAll_M_WardInfo()
        {
            JsonObjectData returnData = new JsonObjectData();
            Status status = new Status();
            List<M_Ward> resultReturn = null;
            status.StatusCode = StatusCodes.NO_DATA;
            try
            {
                resultReturn = new M_AddressInfoADO().SelectAll_M_WardInfo().ToList();
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
