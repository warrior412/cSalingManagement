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
    public class CustomerController : ApiController
    {
        // GET api/Customer/SelectAll_M_CustomerTypeInfo
        [HttpGet]
        public string SelectAll_M_CustomerTypeInfo()
        {
            JsonObjectData returnData = new JsonObjectData();
            Status status = new Status();
            List<M_CustomerType> resultReturn = null;
            status.StatusCode = StatusCodes.NO_DATA;
            try
            {
                resultReturn = new M_CustomerInfoADO().SelectAll_M_CustomerTypeInfo().ToList();
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
        // GET api/Customer/SelectAll_M_CustomerInfo
        [HttpGet]
        public string SelectAll_M_CustomerInfo()
        {
            JsonObjectData returnData = new JsonObjectData();
            Status status = new Status();
            List<M_Customer> resultReturn = null;
            status.StatusCode = StatusCodes.NO_DATA;
            try
            {
                resultReturn = new M_CustomerInfoADO().SelectAll_M_CustomerInfo().ToList();
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

        // POST api/Customer/Insert_M_CustomerInfo
        [HttpPost]
        public string Insert_M_CustomerInfo(M_Customer m_customerinfo)
        {
            JsonObjectData returnData = new JsonObjectData();
            Status status = new Status();
            string resultReturn = "";
            status.StatusCode = StatusCodes.NO_DATA;
            try
            {
                resultReturn = new M_CustomerInfoADO().Insert_M_CustomerInfo(m_customerinfo);
                status.StatusCode = StatusCodes.CREATED;
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

        // POST api/Customer/Select_M_CustomerInfo_ByCustomerID
        [HttpPost]
        public string Select_M_CustomerInfo_ByCustomerID(M_Customer m_customer)
        {
            JsonObjectData returnData = new JsonObjectData();
            Status status = new Status();
            M_Customer resultReturn = null;
            status.StatusCode = StatusCodes.NO_DATA;
            try
            {
                resultReturn = new M_CustomerInfoADO().Select_M_CustomerInfo_ByCustomerID(m_customer.Customer_ID);
                status.StatusCode = StatusCodes.OK;
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
