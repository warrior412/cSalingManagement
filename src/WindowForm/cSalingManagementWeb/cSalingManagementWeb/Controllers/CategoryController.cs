using BusinessEntities;
using BusinessEntities.ADO;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.Objects;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace cSalingManagementWeb.Models
{
    public class CategoryController : ApiController
    {

        // POST api/Category/Insert_M_CategoryInfo
        [HttpPost]
        public string Insert_M_CategoryInfo(M_Category m_categoryinfo)
        {
            JsonObjectData returnData = new JsonObjectData();
            Status status = new Status();
            int resultReturn = -1;
            status.StatusCode = StatusCodes.NO_DATA;
            try
            {
                resultReturn = new M_CategoryInfoDAO().Insert_M_CategoryInfo(m_categoryinfo);
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

        // GET api/Category/SelectAll_M_CategoryInfo
        [HttpGet]
        public string SelectAll_M_CategoryInfo()
        {
            JsonObjectData returnData = new JsonObjectData();
            Status status = new Status();
            List<M_Category> resultReturn = null;
            status.StatusCode = StatusCodes.NO_DATA;
            try
            {
                resultReturn = new M_CategoryInfoDAO().SelectAll_M_CategoryInfo().ToList();
                status.StatusCode = StatusCodes.CREATED;
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
