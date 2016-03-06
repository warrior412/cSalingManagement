using PenguinVoiceApp.Common;
using PenguinVoiceApp.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PenguinVoiceApp.Interface
{
    public partial class PatientList : Form
    {
        public List<PatientInfo> lstPatient = null;
        public PatientList()
        {
            InitializeComponent();
        }

        private void PatientList_Load(object sender, EventArgs e)
        {
            this.bindingSource();
        }

        private void dvPatientList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView gv = sender as DataGridView;
            if(gv!=null&&gv.Columns[e.ColumnIndex] is DataGridViewButtonColumn&&e.RowIndex>=0)
            {
               if(e.ColumnIndex == 5)
               {
                   List<PatientInfo> lst = this.lstPatientDatasource.DataSource as List<PatientInfo>;
                   Register child = new Register(Form.ActiveForm, e.RowIndex, lstPatient[e.RowIndex]);
                   child.ShowDialog();
               }
               else
               {
                   if (MessageBox.Show(Constant.MsgConfirmDelete, "Alert", MessageBoxButtons.OKCancel) == DialogResult.OK)
                   {
                       this.lstPatient.RemoveAt(e.RowIndex);
                       this.bindingSource();
                   }
               }
               
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Register child = new Register(Form.ActiveForm);
            child.ShowDialog();
        }

        public void bindingSource()
        {
            dvPatientList.DataSource = null;
            if (this.lstPatient == null)
                this.lstPatient = new List<PatientInfo>();
            if (this.lstPatient.Count == 0)
            {
                this.btnExportCSV.Visible = false;
            }
            else
            {
                this.btnExportCSV.Visible = true;
            }
            this.lstPatientDatasource.DataSource = this.lstPatient;
            this.lstPatientDatasource.ResetBindings(false);
            dvPatientList.DataSource = this.lstPatientDatasource;
            dvPatientList.Refresh();
        }

        private void btnExportCSV_Click(object sender, EventArgs e)
        {
            DialogResult result = saveFileDialog1.ShowDialog();
            if( result == DialogResult.OK )
            {
                CsvExport<PatientInfo> csv = new CsvExport<PatientInfo>(this.lstPatient);
                csv.ExportToFile(saveFileDialog1.FileName);
            }
        }
       

       
    }
}
