using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace stationDemo
{
    public partial class frmAddStation : Form
    {
        public frmAddStation()
        {
            InitializeComponent();
        }
        OleDbDataAdapter adapter = new OleDbDataAdapter("select * from station", "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + "stationDemo.accdb" + ";Persist Security Info=True");
        DataSet ds = new DataSet();
        string NO="1";
        int rowsCount=0;
        private void frmSize_Load(object sender, EventArgs e)
        {
            initialization();
        }

        private void initialization()
        {
            adapter.Fill(ds);
            rowsCount = ds.Tables[0].Rows.Count;
            //initialize datatable
            updateInputFileds();
            dgvStation.DataSource = ds.Tables[0];
            dgvStation.Columns[0].HeaderText = "ID";
            dgvStation.Columns[1].HeaderText = "Station Name";
            if (dgvStation.SelectedRows.Count == 0)
            {
                btnStationEdit.Enabled = false;
                btnStationDelete.Enabled = false;
                btnStationAdd.Enabled = true;
            }
        }

        public void updateInputFileds()
        {
            rowsCount = ds.Tables[0].Rows.Count;
            NO = (rowsCount == 0) ? "1" : (Convert.ToInt32(ds.Tables[0].Rows[rowsCount - 1][0]) + 1) + "";
            txtStationNO.Text = NO;
            txtStationName.Text = "";
            txtStationName.Select();
            dgvStation.ClearSelection();
            epAddStation.Clear();
        }
        
        private void btnAdditionAdd_Click(object sender, EventArgs e)
        {
            try
            {
                string stationName = txtStationName.Text;
                if (stationName == "")
                {
                    epAddStation.SetError(txtStationName, "Please Enter Station Name");
                    return;
                }
                object[] row = new[] { txtStationNO.Text, txtStationName.Text };
                ds.Tables[0].Rows.Add(row);
                saveDB1();
                updateInputFileds();
                string path = Path.Combine(
                System.AppDomain.CurrentDomain.BaseDirectory,
                "Stations", stationName);
                Directory.CreateDirectory(path);
            }
       
         
             catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void saveDB1()
        {
            
                OleDbCommandBuilder cb = new OleDbCommandBuilder(adapter);
                adapter.Update(ds);
            
          
          
        }

        private void btnAdditionDelete_Click(object sender, EventArgs e)
        {
            if (dgvStation.SelectedRows.Count == 0)
            {
                return;
            }
            int selectedIndex = dgvStation.SelectedRows[0].Index;
            if (selectedIndex < 0)
            {
                epAddStation.SetError(dgvStation, "Please Select The Staion");
                return;
            }
            int id =Convert.ToInt32( ds.Tables[0].Rows[selectedIndex][0].ToString());
            DataTable dtLetterInfo;
            dtLetterInfo = DB.Data("select * from letter where stationNO=" + id);
            if(dtLetterInfo.Rows.Count!=0)
            {
                MessageBox.Show("Station can't be deleted as it has letters");
                return;
            }
            ds.Tables[0].Rows.RemoveAt(selectedIndex);
            saveDB2(id);
            updateInputFileds();

        }

     

        private void saveDB2(int id)
        {
            //delete all or one row
            if(id==-1) DB.affectBuild("delete from station");
            else
            DB.affectBuild("delete from station where ID=" +id);
        }

        private void btnAdditionNew_Click(object sender, EventArgs e)
        {
            updateInputFileds();
        }
        private void btnAdditionEdit_Click(object sender, EventArgs e)
        {
            if (txtStationName.Text == "")
            {
                epAddStation.SetError(txtStationName, "Please Enter Station Name");
                return;
            }
            if (dgvStation.SelectedRows.Count == 0)
            {
                epAddStation.SetError(dgvStation, "Please Select The Staion");
                return;
            }
            int selectedIndex = dgvStation.SelectedRows[0].Index;
            if (selectedIndex < 0)
            {
                epAddStation.SetError(dgvStation, "Please Select The Staion");
                return;
            }
            string NO = txtStationNO.Text;
            ds.Tables[0].Rows[selectedIndex][0]= NO;
            string name = txtStationName.Text;
            ds.Tables[0].Rows[selectedIndex][1] = name;
            saveDB1();
            updateInputFileds();
        }

        

        private void dgvStation_SelectionChanged(object sender, EventArgs e)
        {   
            if (dgvStation.SelectedRows.Count ==0)
            {
                btnStationEdit.Enabled = false;
                btnStationDelete.Enabled = false;
                btnStationAdd.Enabled = true;
                return;
            }

            int selectedIndex = dgvStation.SelectedRows[0].Index;
            if (selectedIndex < 0)
            {
                btnStationEdit.Enabled = false;
                btnStationDelete.Enabled = false;
                btnStationAdd.Enabled = true;
                return;
            }
            string NO = dgvStation.Rows[selectedIndex].Cells[0].Value.ToString();
            txtStationNO.Text = NO;
            string name = dgvStation.Rows[selectedIndex].Cells[1].Value.ToString();
            txtStationName.Text = name;
            btnStationEdit.Enabled = true;
            btnStationDelete.Enabled = true;
            btnStationAdd.Enabled = false;
        }

        private void btnAdditionFirstUP_Click(object sender, EventArgs e)
        {
           
            dgvStation.Rows[0].Selected = true;
        }

        private void btnAdditionLastDown_Click(object sender, EventArgs e)
        {
            int rowsCount = dgvStation.Rows.Count;
            dgvStation.Rows[rowsCount-1].Selected = true;
        }

        private void btnAdditionUP_Click(object sender, EventArgs e)
        {
            int selectedRowsCount = dgvStation.SelectedRows.Count;
            if (selectedRowsCount == 0) dgvStation.Rows[0].Selected = true;
            else if(dgvStation.SelectedRows[0].Index!=0)
            {
                dgvStation.Rows[dgvStation.SelectedRows[0].Index-1].Selected = true;
            }
        }

        private void btnAdditionDown_Click(object sender, EventArgs e)
        {
            int selectedRowsCount = dgvStation.SelectedRows.Count;
            if (selectedRowsCount == 0) dgvStation.Rows[0].Selected = true;
            else if (dgvStation.SelectedRows[0].Index != dgvStation.Rows.Count-1)
            {
                dgvStation.Rows[dgvStation.SelectedRows[0].Index + 1].Selected = true;
            }
        }

    
     

        private void txtAdditionName_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyData==Keys.Enter)
            {
                if (btnStationAdd.Enabled) btnStationAdd.PerformClick();
            }
        }

        private void txtAdditionName_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
