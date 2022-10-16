using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace stationDemo
{
    public partial class frmStationDemo : Form
    {
        public frmStationDemo()
        {
            InitializeComponent();
        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                epLetter.Clear();
                //first check
                bool success1 = CheckInputs();
                if (!success1)
                {
                    return;
                }
                //second check
                bool success2 = CheckLetterNotExists();
                if (!success2)
                {
                    MessageBox.Show("letter exists!");
                    return;
                }
                //if conditions success then insert data to db

                //assign vars
                string stationName = cbxStationName.GetItemText(cbxStationName.SelectedItem);
                string lNO = txtLetterNO.Text;
                string rev = txtRev.Text;
                string DTS = txtDTS.Text;
                string subject = txtSubject.Text;
                string department = cbxDepartment.SelectedIndex < 0 ? cbxDepartment.Text : cbxDepartment.GetItemText(cbxDepartment.SelectedItem);
                string status = cbxStatus.SelectedIndex < 0 ? cbxStatus.Text : cbxStatus.GetItemText(cbxStatus.SelectedItem);
                string date = dtpDate.Value.ToString("yyyy/MM/dd");
                string complaintLink = txtComplaintLink.Text;
                string actionDate = dtpActionDate.Value.ToString("yyyy/MM/dd");
                string realSubmitalDate = dtpRealSubmitalDate.Value.ToString("yyyy/MM/dd");
                string estimatedDuration = txtEstimatedDuration.Text;
                string doneBy = txtDoneBy.Text;
                string remarks = txtRemarks.Text;
                string stationNO = cbxStationName.SelectedValue + "";
                string letterCopyPath = path;
                File.Copy(fullPath, path);
                object[] dataObject = new object[]{ letterCopyPath,lNO, rev, DTS, subject, department, status, date, complaintLink, actionDate, realSubmitalDate, estimatedDuration,
                doneBy, remarks, stationNO};
                DB.insertToDB("letter", new string[] {"letterCopyPath","letterNO", "rev", "DTS", "subject", "department", "status",
               "letterDate", "complaintLink", "actionDate", "realSubmitalDate", "estimatedDuration","doneBy","remarks","stationNO"}, dataObject
                   );

                //INSERT ALSO TO EXCEL FILE 
                InsertToExcelFile(stationName,dataObject);

                MessageBox.Show("Letter Is Submited Successfully");
                clearData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }

        }

        private void InsertToExcelFile(string stationName,object[] dataObject)
        {
            string path_local = Path.Combine(
              System.AppDomain.CurrentDomain.BaseDirectory,
              "Stations", stationName, stationName+".xlsx"
              );


            if (!File.Exists(path_local))
            {
                MessageBox.Show("station file Not Exists!");
                return;
            }

            if (new FileInfo(path_local).Length == 0)
            {
                return;
            }
            using (ExcelPackage xlPackage = new ExcelPackage())
            {
                var sb = new StringBuilder(); //this is your data
                using (var stream = File.OpenRead(path_local))
                {
                    xlPackage.Load(stream);
                }
                //read first sheet with first row that has no letterNO then write the row
                foreach (var workSheet in xlPackage.Workbook.Worksheets)
                {
                    var myWorksheet = workSheet;//select sheet here
                    var totalRows = myWorksheet.Dimension.End.Row;
                    var totalColumns = myWorksheet.Dimension.End.Column;
                    for (int rowNum = 3; rowNum <= totalRows; rowNum++) //select starting row here
                    {
                        if (myWorksheet.Cells[rowNum, 3].Value != null)
                        {
                            continue;
                        }
                        //start from Here
                        else
                        {
                            for (int colNum = 3; colNum <= totalColumns; colNum++)
                            {
                                myWorksheet.SetValue(rowNum, colNum, dataObject[colNum-2]);
                            }
                            myWorksheet.Cells[rowNum, 3].Hyperlink = new Uri(dataObject[0]+"");
                        }
                        break;

                    }
                    break;
                }
                File.WriteAllBytes(path_local, xlPackage.GetAsByteArray());

            }
        }

        private void clearData()
        {
            cbxStationName.Text = "Choose Station Name";
            txtLetterNO.Text = "";
            txtRev.Text = "";
            txtDTS.Text = "";
            txtSubject.Text = "";
            cbxDepartment.Text = "Select Department";
            cbxStatus.Text = "Select Status";
            dtpDate.Value = DateTime.Now;
            txtComplaintLink.Text = "";
            dtpActionDate.Value = DateTime.Now;
            dtpRealSubmitalDate.Value = DateTime.Now;
            txtEstimatedDuration.Text = "";
            txtDoneBy.Text = "";
            txtRemarks.Text = "";
            fullPath = "";
            epLetter.Clear();
            lblLetterCopyFileMsg.Text = "File Is Not Loaded!";
            path = "";
        }

        private bool CheckLetterNotExists()
        {
            string stationName = cbxStationName.GetItemText(cbxStationName.SelectedItem);
            string letterNO = txtLetterNO.Text;
            int stationNO = Convert.ToInt32(DB.Data("select ID from station where stationName='" + stationName + "'").Rows[0][0].ToString());
            DataTable dtLettersInfo = DB.Data("select letterNO from letter where stationNO=" + stationNO);
            bool letterNotExists = true;
            for (int i = 0; i < dtLettersInfo.Rows.Count; i++)
            {
                string letterNO_There = dtLettersInfo.Rows[i][0].ToString();
                if (letterNO_There == letterNO)
                {
                    letterNotExists = false;
                    break;
                }
            }
            return letterNotExists;
        }

        private bool CheckInputs()
        {
            int stationNameIndex = cbxStationName.SelectedIndex;
            string lNO = txtLetterNO.Text;
            string rev = txtRev.Text;
            string subject = txtSubject.Text;
            int departmentIndex = cbxDepartment.SelectedIndex;
            int statusIndex = cbxStatus.SelectedIndex;
            string date = dtpDate.Value.ToString("yyyy/MM/dd");
            bool result = true;
            if (path == "")
            {
                epLetter.SetError(lblLetterCopyFileMsg, "Please load The Letter");
                result = false;
            }
            if (stationNameIndex < 0 || cbxStationName.Text == "Choose Station Name")
            {
                epLetter.SetError(cbxStationName, "Please Select The Station Name");
                result = false;
            }
            if (lNO == "")
            {
                epLetter.SetError(txtLetterNO, "Please Enter Letter Number");
                result = false;
            }
            if (rev == "")
            {
                epLetter.SetError(txtRev, "Please Enter REV");
                result = false;
            }
            if (subject == "")
            {
                epLetter.SetError(txtSubject, "Please Enter The subject of the letter");
                result = false;
            }
            if (cbxDepartment.Text == "Select Department")
            {
                epLetter.SetError(cbxDepartment, "Please Select The Department");
                result = false;
            }
            if (cbxStatus.Text == "Select Status")
            {
                epLetter.SetError(cbxStatus, "Please Select The Status");
                result = false;
            }
            if (date == "")
            {
                epLetter.SetError(dtpDate, "Please Enter The Date Of The Letter");
                result = false;
            }
            return result;
        }
        bool firstLoad = true;
        SortedDictionary<string, SortedDictionary<string, decimal>> controlsDetails = new SortedDictionary<string, SortedDictionary<string, decimal>>();
        SortedDictionary<string, SortedDictionary<string, decimal>> controlsResult = new SortedDictionary<string, SortedDictionary<string, decimal>>();

        private void frmStationDemo_Load(object sender, EventArgs e)
        {
            initializeStationNames();
            clearData();


        }

        DataTable dtStations;
        DataTable dtStations2;
        private void initializeStationNames()
        {
            dtStations = DB.Data("select * from station");
            cbxStationName.DataSource = dtStations;
            cbxStationName.DisplayMember = "stationName";
            cbxStationName.ValueMember = "ID";
            cbxStationName.Text = "Choose Station Name";
            cbxStationName.Invalidate();

        }
        private void initializeStationNamesVersion2()
        {
            dtStations2 = DB.Data("select * from station");
            cbxStation.DataSource = dtStations2;
            cbxStation.DisplayMember = "stationName";
            cbxStation.ValueMember = "ID";
            cbxStation.Text = "Choose Station Name";
            dtLetterInfo = DB.Data("select * from letter where stationNO=" + -1);
            dgvStation.DataSource = dtLetterInfo;
            dgvStation.Columns[1].Visible = false;
            dgvStation.Columns[15].Visible = false;
        }

        private void btnAddStation_Click(object sender, EventArgs e)
        {
            frmAddStation frmAddStation = new frmAddStation();
            frmAddStation.ShowDialog();
            initializeStationNames();
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (tabControl1.SelectedIndex == 1)
            {
                initializeStationNamesVersion2();
                notStart = false;
            }
            else if (tabControl1.SelectedIndex == 0)
            {
                clearData();
            }
        }
        bool notStart = true;
        private void cbxStation_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxStation.SelectedIndex == -1 || notStart || cbxStation.Text == "Choose Station Name") return;
            initializeLetterTable();
        }
        DataTable dtLetterInfo;
        private void initializeLetterTable()
        {
            string stationNO = cbxStation.SelectedValue + "";
            dtLetterInfo = DB.Data("select * from letter where stationNO=" + stationNO);
            dgvStation.DataSource = dtLetterInfo;
            dgvStation.Columns[1].Visible = false;
            dgvStation.Columns[15].Visible = false;

            for (int i = 0; i < dgvStation.Rows.Count; i++)
            {
                string status = dgvStation.Rows[i].Cells[7].Value.ToString();
                if (status == "A) Approved")
                {
                    dgvStation.Rows[i].Cells[7].Style.BackColor = Color.Green;
                    dgvStation.Rows[i].Cells[7].Style.SelectionBackColor = Color.Green;
                    dgvStation.Rows[i].Cells[7].Style.ForeColor = Color.Black;
                    dgvStation.Rows[i].Cells[7].Style.SelectionForeColor = Color.Black;

                }
                else
                {
                    dgvStation.Rows[i].Cells[7].Style.ForeColor = Color.Red;
                    dgvStation.Rows[i].Cells[7].Style.SelectionForeColor = Color.Red;
                    dgvStation.Rows[i].Cells[7].Style.BackColor = Color.White;
                    dgvStation.Rows[i].Cells[7].Style.SelectionBackColor = Color.White;
                }
            }
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void cbxStationName_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        string fullPath = "";
        string path = "";
        private void btnLetterCopy_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Multiselect = false;
            DialogResult dr = ofd.ShowDialog();
            string stationName = cbxStationName.GetItemText(cbxStationName.SelectedItem);
            if (dr == DialogResult.OK)
            {
                fullPath = ofd.FileName;
                string fileName = Path.GetFileName(fullPath);
                path = Path.Combine(
                System.AppDomain.CurrentDomain.BaseDirectory,
                "Stations", stationName,
                fileName);
                lblLetterCopyFileMsg.Text = "File Is Loaded Successfully";
            }

        }

        private void dgvStation_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string fileLink = Path.Combine(
                System.AppDomain.CurrentDomain.BaseDirectory,
                "Stations", cbxStation.GetItemText(cbxStation.SelectedItem)
                );
            try
            {

                if (e.ColumnIndex == 2 && e.RowIndex >= 0)
                {
                    fileLink = Path.Combine(fileLink, dgvStation.Rows[e.RowIndex].Cells[1].Value.ToString());
                    Process.Start(fileLink);
                }
            }
            catch (Exception ex)
            {
                if (fileLink == "")
                {
                    MessageBox.Show("letter Not Found");
                }
                else
                    MessageBox.Show(ex.Message);
            }


        }

        private void btnSearch_Click(object sender, EventArgs e)
        {


        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string searchSentence = "";

            if (rdoLetterNO.Checked) searchSentence += "letterNO";
            else if (rdoRev.Checked) searchSentence += "rev";
            else if (rdoDTS.Checked) searchSentence += "DTS";
            else if (rdoSubject.Checked) searchSentence += "subject";
            else if (rdoDepartment.Checked) searchSentence += "department";
            else if (rdoStatus.Checked) searchSentence += "status";
            searchSentence += " like '%" + txtSearch.Text + "%'";
            DataView dv = new DataView(dtLetterInfo);

            dv.RowFilter = searchSentence;
            dgvStation.DataSource = dv;
            for (int i = 0; i < dgvStation.Rows.Count; i++)
            {
                string status = dgvStation.Rows[i].Cells[7].Value.ToString();
                if (status == "A) Approved")
                {
                    dgvStation.Rows[i].Cells[7].Style.BackColor = Color.Green;
                    dgvStation.Rows[i].Cells[7].Style.SelectionBackColor = Color.Green;
                    dgvStation.Rows[i].Cells[7].Style.ForeColor = Color.Black;
                    dgvStation.Rows[i].Cells[7].Style.SelectionForeColor = Color.Black;

                }
                else
                {
                    dgvStation.Rows[i].Cells[7].Style.ForeColor = Color.Red;
                    dgvStation.Rows[i].Cells[7].Style.SelectionForeColor = Color.Red;
                    dgvStation.Rows[i].Cells[7].Style.BackColor = Color.White;
                    dgvStation.Rows[i].Cells[7].Style.SelectionBackColor = Color.White;
                }
            }
        }

        private void rdoComplaintLink_CheckedChanged(object sender, EventArgs e)
        {
            txtSearch.Text = "";
        }

        private void frmStationDemo_Resize(object sender, EventArgs e)
        {
            if (firstLoad)
            {
                stationDemo.ResizeForm.initialFormHeight = 757;
                stationDemo.ResizeForm.initialFormWidth = 1303;
                stationDemo.ResizeForm.setContolDetails(this, controlsDetails);

                stationDemo.ResizeForm.setControlResult(this, controlsDetails, controlsResult);
                firstLoad = false;
            }
            stationDemo.ResizeForm.changeControls(this, controlsResult);

        }

        private void button1_Click(object sender, EventArgs e)
        {

         string excelFilePath = ConvertXLS_XLSX(new FileInfo( @"C:\Users\NanoChip\source\repos\stationDemo version 31-7-2022 - rev2\stationDemo\bin\Debug\Stations\test station\test station.xls"));
        }
        public static string ConvertXLS_XLSX(FileInfo file)
        {
            var app = new Microsoft.Office.Interop.Excel.Application();
            var xlsFile = file.FullName;
            var wb = app.Workbooks.Open(xlsFile,true,true);
            var xlsxFile = xlsFile + "x";
            wb.SaveAs(Filename: xlsxFile, FileFormat: Microsoft.Office.Interop.Excel.XlFileFormat.xlOpenXMLWorkbook);
            wb.Close();
            app.Quit();
            return xlsxFile;
        }
    }
}
