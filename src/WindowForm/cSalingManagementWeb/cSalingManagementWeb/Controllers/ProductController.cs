using BusinessEntities;
using BusinessEntities.ADO;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace cSalingManagementWeb.Models
{
    public class ProductController : ApiController
    {
        //
        // GET: /Product/


        // POST api/Product/Insert_M_ProductInfo
        [HttpPost]
        public string Insert_M_ProductInfo(M_ProductInfo m_productinfo)
        {
            JsonObjectData returnData = new JsonObjectData();
            Status status = new Status();
            int resultReturn = -1;
            status.StatusCode = StatusCodes.NO_DATA;
            try
            {
                resultReturn = new M_ProductInfoADO().Insert_M_ProductInfo(m_productinfo);
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

        // POST api/Product/SelectAll_M_ProductInfoWithImportInfo_ByProductID
        [HttpPost]
        public string SelectAll_M_ProductInfoWithImportInfo_ByProductID(M_ProductInfo m_productinfo)
        {
            JsonObjectData returnData = new JsonObjectData();
            Status status = new Status();
            SelectAll_M_ProductInfoWithImportInfo_Result resultReturn = null;
            status.StatusCode = StatusCodes.NO_DATA;
            try
            {
                resultReturn = new M_ProductInfoADO().SelectAll_M_ProductInfoWithImportInfo_ByProductID(m_productinfo.ProductID);
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


        // GET api/Product/SelectAll_M_ProductInfoWithImportInfo
        [HttpGet]
        public string SelectAll_M_ProductInfoWithImportInfo()
        {
            JsonObjectData returnData = new JsonObjectData();
            Status status = new Status();
            List<SelectAll_M_ProductInfoWithImportInfo_Result> resultReturn = null;
            status.StatusCode = StatusCodes.NO_DATA;
            try
            {
                resultReturn = new M_ProductInfoADO().SelectAll_M_ProductInfoWithImportInfo().ToList();
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
