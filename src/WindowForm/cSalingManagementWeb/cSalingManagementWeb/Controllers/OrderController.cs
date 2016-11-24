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
    public class OrderController : ApiController
    {
        // POST api/Order/Insert_T_OrderInfo
        [HttpPost]
        public string Insert_T_OrderInfo(List<object> lstOrderInfo)
        {
            JsonObjectData returnData = new JsonObjectData();
            Status status = new Status();
            string resultReturn = "";
            status.StatusCode = StatusCodes.NO_DATA;
            try
            {
                T_Order order = JsonConvert.DeserializeObject<T_Order>(lstOrderInfo[0].ToString());
                List<T_OrderDetail> lstOrderDetail = JsonConvert.DeserializeObject<List<T_OrderDetail>>(lstOrderInfo[1].ToString());
                resultReturn = new T_OrderADO().Insert_T_OrderInfo(order, lstOrderDetail);
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
