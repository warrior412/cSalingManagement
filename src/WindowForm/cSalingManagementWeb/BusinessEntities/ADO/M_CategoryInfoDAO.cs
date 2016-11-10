using System;
using System.Collections.Generic;
using System.Data.Objects;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities.ADO
{
    public class M_CategoryInfoDAO
    {
        cSalingManagementEntities entities = new cSalingManagementEntities();
        public int Insert_M_CategoryInfo(M_Category m_categoryinfo)
        {
            int resultReturn;
            try
            {
                resultReturn = int.Parse(entities.InsertM_CategoryInfo(m_categoryinfo.CategoryName
                                                            ,m_categoryinfo.Cate_Description
                                                            ,m_categoryinfo.Cate_Image
                                                            ,m_categoryinfo.Cate_Status).ToString());
            }
            catch (Exception ex)
            {
                throw new Exception();
            }
            return resultReturn;
        }
        public ObjectResult<M_Category> SelectAll_M_CategoryInfo()
        {
            ObjectResult<M_Category> resultReturn = null;
            try
            {
                resultReturn = entities.SelectAll_M_Category();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return resultReturn;
        }
        
    }
}
