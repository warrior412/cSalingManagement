using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PenguinVoiceApp.Model
{
    public class PatientInfo
    {
        #region Properties

        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        private string name;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        private bool gender;

        public bool Gender
        {
            get { return gender; }
            set { gender = value; }
        }
        private int age;

        public int Age
        {
            get { return age; }
            set { age = value; }
        }
        private int moth;

        public int Moth
        {
            get { return moth; }
            set { moth = value; }
        }
        private string disease;

        public string Disease
        {
            get { return disease; }
            set { disease = value; }
        }
        private string treatment;

        public string Treatment
        {
            get { return treatment; }
            set { treatment = value; }
        }
        private bool usingHearingAid;

        public bool UsingHearingAid
        {
            get { return usingHearingAid; }
            set { usingHearingAid = value; }
        }
        private bool isHandicapped;

        public bool IsHandicapped
        {
            get { return isHandicapped; }
            set { isHandicapped = value; }
        }
        private string handicappedDegree;

        public string HandicappedDegree
        {
            get { return handicappedDegree; }
            set { handicappedDegree = value; }
        }
        private string _MMSE;

        public string MMSE
        {
            get { return _MMSE; }
            set { _MMSE = value; }
        }
        private bool isCheckedPatientInfo;

        public bool IsCheckedPatientInfo
        {
            get { return isCheckedPatientInfo; }
            set { isCheckedPatientInfo = value; }
        }
        private bool isHavingAgree;

        public bool IsHavingAgree
        {
            get { return isHavingAgree; }
            set { isHavingAgree = value; }
        }
        private string dBRight35;

        public string DBRight35
        {
            get { return dBRight35; }
            set { dBRight35 = value; }
        }
        private string dBLeft35;

        public string DBLeft35
        {
            get { return dBLeft35; }
            set { dBLeft35 = value; }
        }
        private string dBRight45;

        public string DBRight45
        {
            get { return dBRight45; }
            set { dBRight45 = value; }
        }
        private string dBLeft45;

        public string DBLeft45
        {
            get { return dBLeft45; }
            set { dBLeft45 = value; }
        }
        private string no1;

        public string No1
        {
            get { return no1; }
            set { no1 = value; }
        }
        private string no2;

        public string No2
        {
            get { return no2; }
            set { no2 = value; }
        }
        private string no3;

        public string No3
        {
            get { return no3; }
            set { no3 = value; }
        }
        private string no4;

        public string No4
        {
            get { return no4; }
            set { no4 = value; }
        }
        private string no5;

        public string No5
        {
            get { return no5; }
            set { no5 = value; }
        }
        private string no6;

        public string No6
        {
            get { return no6; }
            set { no6 = value; }
        }
        private string no7;

        public string No7
        {
            get { return no7; }
            set { no7 = value; }
        }
        private string no8;

        public string No8
        {
            get { return no8; }
            set { no8 = value; }
        }
        private string no9;

        public string No9
        {
            get { return no9; }
            set { no9 = value; }
        }
        private string no10;

        public string No10
        {
            get { return no10; }
            set { no10 = value; }
        }
        private string no12;

        public string No12
        {
            get { return no12; }
            set { no12 = value; }
        }
        private string no13;

        public string No13
        {
            get { return no13; }
            set { no13 = value; }
        }
        private string no14;

        public string No14
        {
            get { return no14; }
            set { no14 = value; }
        }
        private string no15;

        public string No15
        {
            get { return no15; }
            set { no15 = value; }
        }
        private string no16_1;

        public string No16_1
        {
            get { return no16_1; }
            set { no16_1 = value; }
        }
        private string no16_2;

        public string No16_2
        {
            get { return no16_2; }
            set { no16_2 = value; }
        }
        private string no16_3;

        public string No16_3
        {
            get { return no16_3; }
            set { no16_3 = value; }
        }

        private string others;

        public string Others
        {
            get { return others; }
            set { others = value; }
        }

      

        public string GenderByText
        {
            get {
                if (this.Gender)
                    return "男性";
                return "女性";
            }
        }


        public string AgeByText
        {
            get {
                if (this.Age == -1 && this.Moth == -1)
                    return "";
                return (this.Age==-1?0:this.Age)+"歳"+(this.Moth==-1?0:this.Moth)+"ヶ月";
            }
        }


        public string IsCheckedPatientInfoByText
        {
            get {
                if (this.IsCheckedPatientInfo)
                    return "確認";
                return "未確認";
            }
        }


        public string IsHavingAgreeByText
        {
            get {
                if (this.IsHavingAgree)
                    return "ある";
                return "なし";
            }
        }
        #endregion




        public List<PatientInfo> createTestData()
        {
            List<PatientInfo> lstPatient = new List<PatientInfo>();
            for(int i=0;i<10;i++)
            {
                PatientInfo info = new PatientInfo();
                info.id = i + 1;
                info.Name = "Hieu Huynh";
                info.Gender = true;
                info.Age = 26;
                info.Moth = 3;
                info.IsCheckedPatientInfo = true;
                info.IsHavingAgree = true;
                lstPatient.Add(info);
            }
            return lstPatient;
        }
    }
}
