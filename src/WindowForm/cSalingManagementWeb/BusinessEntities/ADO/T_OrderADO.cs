using System;
using System.Collections.Generic;
using System.Data.Objects;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace BusinessEntities.ADO
{
    public class T_OrderADO
    {
        cSalingManagementEntities entities = new cSalingManagementEntities();
        public string Insert_T_OrderInfo(T_Order t_order,List<T_OrderDetail> lstOrderDetail)
        {
            string resultReturn = "";
            try
            {
                using (var trans = new TransactionScope())
                {
                    ObjectResult<string> rs = entities.InsertT_OrderInfo(t_order.Order_CustomerID,
                                                                        DateTime.Now,
                                                                        t_order.CreatedUser,
                                                                        t_order.Order_Memo,
                                                                        t_order.Order_ShipTime,
                                                                        t_order.Order_Status);
                    string id = rs.FirstOrDefault().ToString();

                    foreach(T_OrderDetail detail in lstOrderDetail)
                    {
                        entities.InsertT_OrderDetailInfo(id,
                                                        detail.OD_ProductID,
                                                        detail.OD_ImportDate,
                                                        detail.OD_Quantity,
                                                        detail.OD_SellingPrice,
                                                        detail.OD_TotalAmount,
                                                        detail.OD_Status);
                    }
                    trans.Complete();

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return resultReturn;
        }

        public ObjectResult<SelectAll_T_OrderInfo_Result> SelectAll_T_OrderInfo()
        {
            ObjectResult<SelectAll_T_OrderInfo_Result> resultReturn = null;
            try
            {
                resultReturn = entities.SelectAll_T_OrderInfo();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return resultReturn;
        }

        public ObjectResult<SelectAll_T_OrderInfo_Result> SelectAll_T_OrderInfo_OnWaiting()
        {
            ObjectResult<SelectAll_T_OrderInfo_Result> resultReturn = null;
            try
            {
                resultReturn = entities.SelectAll_T_OrderInfo_OnWaiting();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return resultReturn;
        }
    }
}
