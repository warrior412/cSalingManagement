﻿using System;
using System.Collections.Generic;
using System.Data.Objects;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities.ADO
{
    public class M_ProductInfoADO
    {
        cSalingManagementEntities entities = new cSalingManagementEntities();
        public int Insert_M_ProductInfo(M_ProductInfo m_productinfo)
        {
            int resultReturn;
            try
            {
                resultReturn = int.Parse(entities.InsertM_ProductInfo(m_productinfo.ProductName,
                                            m_productinfo.Category,
                                            m_productinfo.Pro_InStock,
                                            m_productinfo.Pro_Image,
                                            m_productinfo.Pro_Price,
                                            m_productinfo.Pro_Desciptions,
                                            m_productinfo.Pro_Preservation,
                                            m_productinfo.Pro_HowToUse,
                                            m_productinfo.Pro_Origin,
                                            m_productinfo.Pro_Status).ToString());
            }catch(Exception ex)
            {
                throw ex;
            }
            return resultReturn;
        }
        public int UpdateM_ProductInfo(M_ProductInfo m_productinfo)
        {
            int resultReturn;
            try
            {
                resultReturn = int.Parse(entities.UpdateM_ProductInfo(m_productinfo.ProductID,m_productinfo.ProductName,
                                            m_productinfo.Category,
                                            m_productinfo.Pro_InStock,
                                            m_productinfo.Pro_Image,
                                            m_productinfo.Pro_Price,
                                            m_productinfo.Pro_Desciptions,
                                            m_productinfo.Pro_Preservation,
                                            m_productinfo.Pro_HowToUse,
                                            m_productinfo.Pro_Origin,
                                            m_productinfo.Pro_Status).ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return resultReturn;
        }
        public ObjectResult<SelectAll_M_ProductInfoWithImportInfo_Result> SelectAll_M_ProductInfoWithImportInfo()
        {
            ObjectResult<SelectAll_M_ProductInfoWithImportInfo_Result> resultReturn = null;
            try
            {
                resultReturn = entities.SelectAll_M_ProductInfoWithImportInfo();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return resultReturn;
        }
        public ObjectResult<M_ProductInfo> SelectAll_M_ProductInfo()
        {
            ObjectResult<M_ProductInfo> resultReturn = null;
            try
            {
                resultReturn = entities.SelectAll_M_ProductInfo();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return resultReturn;
        }
        public SelectAll_M_ProductInfoWithImportInfo_Result SelectAll_M_ProductInfoWithImportInfo_ByProductID(string productID)
        {
            SelectAll_M_ProductInfoWithImportInfo_Result resultReturn = null;
            try
            {
                resultReturn = entities.SelectAll_M_ProductInfoWithImportInfo_ByProductID(productID).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return resultReturn;
        }
    }
}
