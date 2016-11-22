using System;
using System.Collections.Generic;
using System.Data.Objects;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities.ADO
{
    public class M_CustomerInfoADO
    {
        cSalingManagementEntities entities = new cSalingManagementEntities();
        public ObjectResult<M_CustomerType> SelectAll_M_CustomerTypeInfo()
        {
            ObjectResult<M_CustomerType> resultReturn = null;
            try
            {
                resultReturn = entities.SelectAll_M_CustomerType();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return resultReturn;
        }
        public ObjectResult<M_Customer> SelectAll_M_CustomerInfo()
        {
            ObjectResult<M_Customer> resultReturn = null;
            try
            {
                resultReturn = entities.SelectAll_M_CustomerInfo();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return resultReturn;
        }

        public string Insert_M_CustomerInfo(M_Customer m_customerinfo)
        {
            string resultReturn="";
            try
            {
                ObjectResult<string> rs = entities.InsertM_CustomerInfo(m_customerinfo.Customer_Name,
                                                                        m_customerinfo.Customer_BirthDay,
                                                                        m_customerinfo.Customer_Phone,
                                                                        m_customerinfo.Customer_Mobile,
                                                                        m_customerinfo.Customer_Address,
                                                                        m_customerinfo.Customer_Ward,
                                                                        m_customerinfo.Customer_District,
                                                                        m_customerinfo.Customer_City,
                                                                        m_customerinfo.Customer_Description,
                                                                        m_customerinfo.Customer_Type,
                                                                        m_customerinfo.Customer_Status,
                                                                        m_customerinfo.Customer_Point);
                resultReturn = rs.FirstOrDefault().ToString();
       
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return resultReturn;
        }

        public M_Customer Select_M_CustomerInfo_ByCustomerID(string customeID)
        {
            M_Customer resultReturn = null;
            try
            {
                resultReturn = entities.Select_M_CustomerInfo_ByCustomerID(customeID).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return resultReturn;
        }
    }
}
