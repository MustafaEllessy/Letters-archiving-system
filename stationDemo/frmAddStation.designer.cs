namespace stationDemo
{
    partial class frmAddStation
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtStationName = new System.Windows.Forms.TextBox();
            this.txtStationNO = new System.Windows.Forms.TextBox();
            this.btnStationAdd = new System.Windows.Forms.Button();
            this.btnStationNew = new System.Windows.Forms.Button();
            this.btnStationEdit = new System.Windows.Forms.Button();
            this.btnStationDelete = new System.Windows.Forms.Button();
            this.dgvStation = new System.Windows.Forms.DataGridView();
            this.epAddStation = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dgvStation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.epAddStation)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(63, 105);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(142, 27);
            this.label2.TabIndex = 17;
            this.label2.Text = "Station Name";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(63, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(110, 27);
            this.label1.TabIndex = 18;
            this.label1.Text = "Station ID";
            // 
            // txtStationName
            // 
            this.txtStationName.Location = new System.Drawing.Point(210, 97);
            this.txtStationName.Name = "txtStationName";
            this.txtStationName.Size = new System.Drawing.Size(287, 34);
            this.txtStationName.TabIndex = 0;
            this.txtStationName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtStationName.TextChanged += new System.EventHandler(this.txtAdditionName_TextChanged);
            this.txtStationName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtAdditionName_KeyDown);
            // 
            // txtStationNO
            // 
            this.txtStationNO.BackColor = System.Drawing.Color.Gold;
            this.txtStationNO.Location = new System.Drawing.Point(210, 41);
            this.txtStationNO.Name = "txtStationNO";
            this.txtStationNO.ReadOnly = true;
            this.txtStationNO.Size = new System.Drawing.Size(287, 34);
            this.txtStationNO.TabIndex = 15;
            this.txtStationNO.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnStationAdd
            // 
            this.btnStationAdd.BackColor = System.Drawing.Color.Gold;
            this.btnStationAdd.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnStationAdd.Location = new System.Drawing.Point(216, 167);
            this.btnStationAdd.Name = "btnStationAdd";
            this.btnStationAdd.Size = new System.Drawing.Size(107, 43);
            this.btnStationAdd.TabIndex = 2;
            this.btnStationAdd.Text = "Add";
            this.btnStationAdd.UseVisualStyleBackColor = false;
            this.btnStationAdd.Click += new System.EventHandler(this.btnAdditionAdd_Click);
            // 
            // btnStationNew
            // 
            this.btnStationNew.BackColor = System.Drawing.Color.Gold;
            this.btnStationNew.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnStationNew.Location = new System.Drawing.Point(112, 167);
            this.btnStationNew.Name = "btnStationNew";
            this.btnStationNew.Size = new System.Drawing.Size(98, 43);
            this.btnStationNew.TabIndex = 1;
            this.btnStationNew.Text = "New";
            this.btnStationNew.UseVisualStyleBackColor = false;
            this.btnStationNew.Click += new System.EventHandler(this.btnAdditionNew_Click);
            // 
            // btnStationEdit
            // 
            this.btnStationEdit.BackColor = System.Drawing.Color.Gold;
            this.btnStationEdit.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnStationEdit.Location = new System.Drawing.Point(331, 167);
            this.btnStationEdit.Name = "btnStationEdit";
            this.btnStationEdit.Size = new System.Drawing.Size(103, 43);
            this.btnStationEdit.TabIndex = 3;
            this.btnStationEdit.Text = "Edit";
            this.btnStationEdit.UseVisualStyleBackColor = false;
            this.btnStationEdit.Click += new System.EventHandler(this.btnAdditionEdit_Click);
            // 
            // btnStationDelete
            // 
            this.btnStationDelete.BackColor = System.Drawing.Color.Gold;
            this.btnStationDelete.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnStationDelete.Location = new System.Drawing.Point(438, 167);
            this.btnStationDelete.Name = "btnStationDelete";
            this.btnStationDelete.Size = new System.Drawing.Size(98, 43);
            this.btnStationDelete.TabIndex = 4;
            this.btnStationDelete.Text = "Delete";
            this.btnStationDelete.UseVisualStyleBackColor = false;
            this.btnStationDelete.Click += new System.EventHandler(this.btnAdditionDelete_Click);
            // 
            // dgvStation
            // 
            this.dgvStation.AllowUserToAddRows = false;
            this.dgvStation.AllowUserToDeleteRows = false;
            this.dgvStation.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvStation.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvStation.BackgroundColor = System.Drawing.Color.DarkOrange;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Gold;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Gold;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvStation.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvStation.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvStation.EnableHeadersVisualStyles = false;
            this.dgvStation.Location = new System.Drawing.Point(35, 216);
            this.dgvStation.MultiSelect = false;
            this.dgvStation.Name = "dgvStation";
            this.dgvStation.ReadOnly = true;
            this.dgvStation.RowHeadersWidth = 51;
            this.dgvStation.RowTemplate.Height = 26;
            this.dgvStation.Size = new System.Drawing.Size(573, 458);
            this.dgvStation.TabIndex = 6;
            this.dgvStation.SelectionChanged += new System.EventHandler(this.dgvStation_SelectionChanged);
            // 
            // epAddStation
            // 
            this.epAddStation.ContainerControl = this;
            // 
            // frmAddStation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 26F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkOrange;
            this.ClientSize = new System.Drawing.Size(628, 686);
            this.Controls.Add(this.dgvStation);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtStationName);
            this.Controls.Add(this.txtStationNO);
            this.Controls.Add(this.btnStationAdd);
            this.Controls.Add(this.btnStationNew);
            this.Controls.Add(this.btnStationEdit);
            this.Controls.Add(this.btnStationDelete);
            this.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmAddStation";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = " ";
            this.Load += new System.EventHandler(this.frmSize_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvStation)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.epAddStation)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnStationDelete;
        private System.Windows.Forms.Button btnStationEdit;
        private System.Windows.Forms.Button btnStationNew;
        private System.Windows.Forms.Button btnStationAdd;
        private System.Windows.Forms.TextBox txtStationNO;
        private System.Windows.Forms.TextBox txtStationName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dgvStation;
        private System.Windows.Forms.ErrorProvider epAddStation;
    }
}