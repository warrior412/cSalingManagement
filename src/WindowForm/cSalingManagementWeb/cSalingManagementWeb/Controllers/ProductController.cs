using BusinessEntities;
using BusinessEntities.ADO;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace cSalingManagementWeb.Models
{
    public class ProductController : Controller
    {

        cSalingManagementEntities entites = new cSalingManagementEntities();

        //
        // GET: /Product/

        public ActionResult Index()
        {
            return View();
        }

        // POST api/Product/Insert_M_ProductInfo
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

    }
}
