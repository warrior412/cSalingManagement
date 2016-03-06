namespace PenguinVoiceApp.Interface
{
    partial class PatientList
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.btnExportCSV = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.dvPatientList = new System.Windows.Forms.DataGridView();
            this.lstPatientDatasource = new System.Windows.Forms.BindingSource(this.components);
            this.btnDelete = new System.Windows.Forms.DataGridViewButtonColumn();
            this.btnUpdate = new System.Windows.Forms.DataGridViewButtonColumn();
            this.同意書 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.病人情報 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.年齢 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.性別 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.氏名 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.dvPatientList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lstPatientDatasource)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("MS UI Gothic", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label1.Location = new System.Drawing.Point(33, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(180, 27);
            this.label1.TabIndex = 0;
            this.label1.Text = "調査結果一覧";
            // 
            // btnExportCSV
            // 
            this.btnExportCSV.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExportCSV.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.btnExportCSV.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExportCSV.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnExportCSV.Location = new System.Drawing.Point(880, 13);
            this.btnExportCSV.Name = "btnExportCSV";
            this.btnExportCSV.Size = new System.Drawing.Size(90, 38);
            this.btnExportCSV.TabIndex = 1;
            this.btnExportCSV.Text = "CSV出力";
            this.btnExportCSV.UseVisualStyleBackColor = true;
            this.btnExportCSV.Click += new System.EventHandler(this.btnExportCSV_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAdd.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.btnAdd.FlatAppearance.BorderSize = 0;
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdd.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnAdd.ForeColor = System.Drawing.Color.White;
            this.btnAdd.Location = new System.Drawing.Point(976, 13);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(87, 38);
            this.btnAdd.TabIndex = 2;
            this.btnAdd.Text = "追加";
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // dvPatientList
            // 
            this.dvPatientList.AllowUserToAddRows = false;
            this.dvPatientList.AllowUserToDeleteRows = false;
            this.dvPatientList.AllowUserToResizeRows = false;
            this.dvPatientList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dvPatientList.AutoGenerateColumns = false;
            this.dvPatientList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dvPatientList.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dvPatientList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dvPatientList.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dvPatientList.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.LightGray;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("MS UI Gothic", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.InfoText;
            dataGridViewCellStyle5.Padding = new System.Windows.Forms.Padding(0, 5, 5, 5);
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.Gray;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dvPatientList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dvPatientList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dvPatientList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.氏名,
            this.性別,
            this.年齢,
            this.病人情報,
            this.同意書,
            this.btnUpdate,
            this.btnDelete});
            this.dvPatientList.DataSource = this.lstPatientDatasource;
            this.dvPatientList.EnableHeadersVisualStyles = false;
            this.dvPatientList.Location = new System.Drawing.Point(38, 72);
            this.dvPatientList.MultiSelect = false;
            this.dvPatientList.Name = "dvPatientList";
            this.dvPatientList.ReadOnly = true;
            this.dvPatientList.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.ControlLight;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("MS UI Gothic", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle7.Padding = new System.Windows.Forms.Padding(0, 5, 5, 5);
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dvPatientList.RowHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.dvPatientList.RowHeadersVisible = false;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("MS UI Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            dataGridViewCellStyle8.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.Color.Black;
            this.dvPatientList.RowsDefaultCellStyle = dataGridViewCellStyle8;
            this.dvPatientList.RowTemplate.Height = 28;
            this.dvPatientList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dvPatientList.Size = new System.Drawing.Size(1025, 662);
            this.dvPatientList.TabIndex = 3;
            this.dvPatientList.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dvPatientList_CellContentClick);
            // 
            // btnDelete
            // 
            this.btnDelete.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.btnDelete.FillWeight = 5F;
            this.btnDelete.HeaderText = "";
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.ReadOnly = true;
            this.btnDelete.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.btnDelete.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.btnDelete.Text = "削除";
            this.btnDelete.UseColumnTextForButtonValue = true;
            this.btnDelete.Width = 50;
            // 
            // btnUpdate
            // 
            this.btnUpdate.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.btnUpdate.FillWeight = 5F;
            this.btnUpdate.HeaderText = "";
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.ReadOnly = true;
            this.btnUpdate.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.btnUpdate.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.btnUpdate.Text = "編集";
            this.btnUpdate.UseColumnTextForButtonValue = true;
            this.btnUpdate.Width = 50;
            // 
            // 同意書
            // 
            this.同意書.DataPropertyName = "IsHavingAgreeByText";
            this.同意書.FillWeight = 25F;
            this.同意書.HeaderText = "同意書";
            this.同意書.Name = "同意書";
            this.同意書.ReadOnly = true;
            // 
            // 病人情報
            // 
            this.病人情報.DataPropertyName = "IsCheckedPatientInfoByText";
            this.病人情報.FillWeight = 15F;
            this.病人情報.HeaderText = "病人情報";
            this.病人情報.Name = "病人情報";
            this.病人情報.ReadOnly = true;
            // 
            // 年齢
            // 
            this.年齢.DataPropertyName = "AgeByText";
            this.年齢.FillWeight = 10F;
            this.年齢.HeaderText = "年齢";
            this.年齢.Name = "年齢";
            this.年齢.ReadOnly = true;
            // 
            // 性別
            // 
            this.性別.DataPropertyName = "GenderByText";
            this.性別.FillWeight = 10F;
            this.性別.HeaderText = "性別";
            this.性別.Name = "性別";
            this.性別.ReadOnly = true;
            // 
            // 氏名
            // 
            this.氏名.DataPropertyName = "Name";
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.White;
            this.氏名.DefaultCellStyle = dataGridViewCellStyle6;
            this.氏名.FillWeight = 30F;
            this.氏名.HeaderText = "氏名";
            this.氏名.Name = "氏名";
            this.氏名.ReadOnly = true;
            // 
            // PatientList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(1084, 762);
            this.Controls.Add(this.dvPatientList);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnExportCSV);
            this.Controls.Add(this.label1);
            this.Name = "PatientList";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PatientList";
            this.Load += new System.EventHandler(this.PatientList_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dvPatientList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lstPatientDatasource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnExportCSV;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.DataGridView dvPatientList;
        private System.Windows.Forms.BindingSource lstPatientDatasource;
        private System.Windows.Forms.DataGridViewTextBoxColumn 氏名;
        private System.Windows.Forms.DataGridViewTextBoxColumn 性別;
        private System.Windows.Forms.DataGridViewTextBoxColumn 年齢;
        private System.Windows.Forms.DataGridViewTextBoxColumn 病人情報;
        private System.Windows.Forms.DataGridViewTextBoxColumn 同意書;
        private System.Windows.Forms.DataGridViewButtonColumn btnUpdate;
        private System.Windows.Forms.DataGridViewButtonColumn btnDelete;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
    }
}