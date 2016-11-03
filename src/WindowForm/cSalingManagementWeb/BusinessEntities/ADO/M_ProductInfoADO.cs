using System;
using System.Collections.Generic;
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
                resultReturn = entities.InsertM_ProductInfo(m_productinfo.ProductName,
                                            m_productinfo.Category,
                                            m_productinfo.Supplier,
                                            m_productinfo.Pro_InStock,
                                            m_productinfo.Pro_Image,
                                            m_productinfo.Pro_Price,
                                            m_productinfo.Pro_Desciptions,
                                            m_productinfo.Pro_Preservation,
                                            m_productinfo.Pro_HowToUse,
                                            m_productinfo.Pro_Origin,
                                            m_productinfo.Pro_Status);
            }catch(Exception ex)
            {
                throw new Exception();
            }
            return resultReturn;
        }
    }
}
