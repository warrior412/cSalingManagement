using PenguinVoiceApp.Common;
using PenguinVoiceApp.Interface;
using PenguinVoiceApp.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PenguinVoiceApp
{
    public partial class Register : Form
    {
        public int _selectedIndex;
        public PatientInfo _selectedInfo = null;
        public PatientList _parent = null;
        public Register(Form sender)
        {
            InitializeComponent();
            InitData();
            _selectedIndex = -1;
            _parent = sender as PatientList;
            
        }
        public Register(Form sender,int selectedIndex,PatientInfo selectedInfo)
        {
            InitializeComponent();
            InitData();
            _selectedInfo = selectedInfo;
            _selectedIndex = selectedIndex;
            if (_selectedInfo != null)
                this.setDataToControl();
            _parent = sender as PatientList;
            
                 
        }

        private void InitData()
        {
            this.cbSickDegree.Items.AddRange(Constant.arrTreament);


            this.cb35Left.Items.AddRange (Constant.arrTempt);
            this.cb35Right.Items.AddRange(Constant.arrTempt);
            this.cb45Left.Items.AddRange(Constant.arrTempt);
            this.cb45Right.Items.AddRange(Constant.arrTempt);


            this.cbNo1.Items.AddRange(Constant.arrTempt);
            this.cbNo10.Items.AddRange(Constant.arrTempt);
            this.cbNo12.Items.AddRange(Constant.arrTempt);
            this.cbNo13.Items.AddRange(Constant.arrTempt);
            this.cbNo14.Items.AddRange(Constant.arrTempt);
            this.cbNo15.Items.AddRange(Constant.arrTempt);
            this.cbNo16_1.Items.AddRange(Constant.arrTempt);
            this.cbNo16_2.Items.AddRange(Constant.arrTempt);
            this.cbNo16_3.Items.AddRange(Constant.arrTempt);
            this.cbNo2.Items.AddRange(Constant.arrTempt);
            this.cbNo3.Items.AddRange(Constant.arrTempt);
            this.cbNo4.Items.AddRange(Constant.arrTempt);
            this.cbNo5.Items.AddRange(Constant.arrTempt);
            this.cbNo6.Items.AddRange(Constant.arrTempt);
            this.cbNo7.Items.AddRange(Constant.arrTempt);
            this.cbNo8.Items.AddRange(Constant.arrTempt);
            this.cbNo9.Items.AddRange(Constant.arrTempt);
        }
        private void setDataToControl()
        {
             
            this.txtName.Text=_selectedInfo.Name;
            this.rdbMale.Checked= _selectedInfo.Gender;
            this.txtAge.Text=_selectedInfo.Age.ToString();
            this.txtMonth.Text=_selectedInfo.Moth.ToString() ;
            this.txtSickName.Text=_selectedInfo.Disease;
            this.cbSickDegree.SelectedItem=_selectedInfo.Treatment;
            this.rdbHearingAidYes.Checked=_selectedInfo.UsingHearingAid;
            this.rdbHandicappedYes.Checked=_selectedInfo.IsHandicapped;
            this.txtHandicappedDegree.Text = _selectedInfo.HandicappedDegree;
            this.txtMMSE.Text=_selectedInfo.MMSE;
            this.rdbCheck.Checked = _selectedInfo.IsCheckedPatientInfo;
            this.txtOthers.Text=_selectedInfo.Others ;
            this.rdbAgree.Checked=_selectedInfo.IsHavingAgree ;
            this.cb35Left.SelectedItem = _selectedInfo.DBLeft35;
            this.cb35Right.SelectedItem = _selectedInfo.DBRight35;
            this.cb45Left.SelectedItem = _selectedInfo.DBLeft45;
            this.cb45Right.SelectedItem = _selectedInfo.DBRight45;
            this.cbNo1.SelectedItem = _selectedInfo.No1;
            this.cbNo2.SelectedItem = _selectedInfo.No2;
            this.cbNo3.SelectedItem = _selectedInfo.No3;
            this.cbNo4.SelectedItem = _selectedInfo.No4;
            this.cbNo5.SelectedItem = _selectedInfo.No5;
            this.cbNo6.SelectedItem = _selectedInfo.No6;
            this.cbNo7.SelectedItem = _selectedInfo.No7;
            this.cbNo8.SelectedItem = _selectedInfo.No8;
            this.cbNo9.SelectedItem = _selectedInfo.No9;
            this.cbNo10.SelectedItem = _selectedInfo.No10;
            this.cbNo12.SelectedItem = _selectedInfo.No12;
            this.cbNo13.SelectedItem = _selectedInfo.No13;
            this.cbNo14.SelectedItem = _selectedInfo.No14;
            this.cbNo15.SelectedItem = _selectedInfo.No15;
            this.cbNo16_1.SelectedItem = _selectedInfo.No16_1;
            this.cbNo16_2.SelectedItem = _selectedInfo.No16_2;
            this.cbNo16_3.SelectedItem = _selectedInfo.No16_3;
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            if (_selectedInfo == null)
                _selectedInfo = new PatientInfo();
            _selectedInfo.Name = this.txtName.Text;
            _selectedInfo.Gender = this.rdbMale.Checked ? true : false;
            _selectedInfo.Age = string.IsNullOrEmpty(this.txtAge.Text) ? -1 : int.Parse(this.txtAge.Text);
            _selectedInfo.Moth = string.IsNullOrEmpty(this.txtMonth.Text) ? -1 : int.Parse(this.txtMonth.Text);
            _selectedInfo.Disease = this.txtSickName.Text;
            _selectedInfo.Treatment = this.cbSickDegree.SelectedItem == null ? "" : this.cbSickDegree.SelectedItem.ToString();
            _selectedInfo.UsingHearingAid = this.rdbHearingAidYes.Checked ? true : false;
            _selectedInfo.IsHandicapped = this.rdbHandicappedYes.Checked ? true : false;
            _selectedInfo.HandicappedDegree = this.txtHandicappedDegree.Text;
            _selectedInfo.MMSE = this.txtMMSE.Text;
            _selectedInfo.IsCheckedPatientInfo = this.rdbCheck.Checked ? true : false;
            _selectedInfo.Others = this.txtOthers.Text;
            _selectedInfo.IsHavingAgree = this.rdbAgree.Checked ? true : false;
            _selectedInfo.DBLeft35 = this.cb35Left.SelectedItem == null ? "" : this.cb35Left.SelectedItem.ToString();
            _selectedInfo.DBRight35 = this.cb35Right.SelectedItem == null ? "" : this.cb35Right.SelectedItem.ToString();
            _selectedInfo.DBLeft45 = this.cb45Left.SelectedItem == null ? "" : this.cb45Left.SelectedItem.ToString();
            _selectedInfo.DBRight45 = this.cb45Right.SelectedItem == null ? "" : this.cb45Right.SelectedItem.ToString();
            _selectedInfo.No1 = this.cbNo1.SelectedItem == null ? "" : this.cbNo1.SelectedItem.ToString();
            _selectedInfo.No2 = this.cbNo2.SelectedItem == null ? "" : this.cbNo2.SelectedItem.ToString();
            _selectedInfo.No3 = this.cbNo3.SelectedItem == null ? "" : this.cbNo3.SelectedItem.ToString();
            _selectedInfo.No4 = this.cbNo4.SelectedItem == null ? "" : this.cbNo4.SelectedItem.ToString();
            _selectedInfo.No5 = this.cbNo5.SelectedItem == null ? "" : this.cbNo5.SelectedItem.ToString();
            _selectedInfo.No6 = this.cbNo6.SelectedItem == null ? "" : this.cbNo6.SelectedItem.ToString();
            _selectedInfo.No7 = this.cbNo7.SelectedItem == null ? "" : this.cbNo7.SelectedItem.ToString();
            _selectedInfo.No8 = this.cbNo8.SelectedItem == null ? "" : this.cbNo8.SelectedItem.ToString();
            _selectedInfo.No9 = this.cbNo9.SelectedItem == null ? "" : this.cbNo9.SelectedItem.ToString();
            _selectedInfo.No10 = this.cbNo10.SelectedItem == null ? "" : this.cbNo10.SelectedItem.ToString();
            _selectedInfo.No12 = this.cbNo12.SelectedItem == null ? "" : this.cbNo12.SelectedItem.ToString();
            _selectedInfo.No13 = this.cbNo13.SelectedItem == null ? "" : this.cbNo13.SelectedItem.ToString();
            _selectedInfo.No14 = this.cbNo14.SelectedItem == null ? "" : this.cbNo14.SelectedItem.ToString();
            _selectedInfo.No15 = this.cbNo15.SelectedItem == null ? "" : this.cbNo15.SelectedItem.ToString();
            _selectedInfo.No16_1 = this.cbNo16_1.SelectedItem == null ? "" : this.cbNo16_1.SelectedItem.ToString();
            _selectedInfo.No16_2 = this.cbNo16_2.SelectedItem == null ? "" : this.cbNo16_2.SelectedItem.ToString();
            _selectedInfo.No16_3 = this.cbNo16_3.SelectedItem == null ? "" : this.cbNo16_3.SelectedItem.ToString();

            if(_selectedIndex>=0)
            {
                _parent.lstPatient[_selectedIndex] = _selectedInfo;
            }
            else
            {
                _selectedInfo.Id = Constant.getNextID(this._parent.lstPatient);
                _parent.lstPatient.Add(_selectedInfo);
            }
            _parent.bindingSource();
            this.Close();    
        }
     
    }
}
