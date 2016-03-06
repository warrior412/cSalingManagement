using PenguinVoiceApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PenguinVoiceApp.Common
{
    public static class Constant
    {
        public static string[] arrTreament = {"要支援1", "要支援2", "要介護1", "要介護2", "要介護3", "要介護4", "要介護5" };
        public static string[] arrTempt = {"O", "X"};
        public static string MsgConfirmDelete = "削除してもよろしいですか？";
        public static int getNextID(List<PatientInfo> lstInfo)
        {
            int maxValue = 0;
            if(lstInfo!=null&&lstInfo.Count>0)
                maxValue = lstInfo.Max(x => x.Id);
            return maxValue+1;
        }
    }
}
