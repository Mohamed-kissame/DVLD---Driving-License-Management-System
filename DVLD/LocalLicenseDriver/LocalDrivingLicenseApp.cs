using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BussniesDVLDLayer;
using DVLD.Tests;

namespace DVLD.LocalLicenseDriver
{
    public partial class LocalDrivingLicenseApp : Form
    {

        private DataTable _dtAllLocalDrivingLicenseApplications;

        public LocalDrivingLicenseApp()
        {
            InitializeComponent();

        }

        private void UpdateRecordCount(int Count)
        {

            lblCount.Text = $"# Records: {Count}";
            lblCount.Font = new Font("Segoe UI", 10F, FontStyle.Bold);

        }

        private void _StyleGrid()
        {
           
            dataGridView1.BorderStyle = BorderStyle.FixedSingle;

            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.MultiSelect = false;
            dataGridView1.ReadOnly = true; // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.RowHeadersVisible = false;

           
            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(0, 122, 204);
            dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            dataGridView1.ColumnHeadersHeight = 36;

            
            dataGridView1.DefaultCellStyle.Font = new Font("Segoe UI", 10);
            dataGridView1.DefaultCellStyle.SelectionBackColor = Color.FromArgb(229, 241, 251);
            dataGridView1.DefaultCellStyle.SelectionForeColor = Color.Black;
            dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(245, 245, 245);

            
            typeof(DataGridView).GetProperty("DoubleBuffered",
                System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic)
                ?.SetValue(dataGridView1, true, null);
        }


        private void showDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {

            ShowLicenseAppInfo licenseAppInfo = new ShowLicenseAppInfo((int)dataGridView1.CurrentRow.Cells[0].Value);
            licenseAppInfo.Show();


        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            AddEditLocalDrivingLicense addEditLocalDrivingLicense = new AddEditLocalDrivingLicense();
            addEditLocalDrivingLicense.ShowDialog();
            LocalDrivingLicenseApp_Load(null, null);
        }

        private void LocalDrivingLicenseApp_Load(object sender, EventArgs e)
        {

            _dtAllLocalDrivingLicenseApplications = ClsLicenseDrivingLocal.GetAllLicense();
            dataGridView1.DataSource = _dtAllLocalDrivingLicenseApplications;

            comboBox1.SelectedIndex = 0;

            if (dataGridView1.Rows.Count > 0)
            {

                dataGridView1.Columns[0].HeaderText = "L.D.L.AppID";
               

                dataGridView1.Columns[1].HeaderText = "Driving Class";
                

                dataGridView1.Columns[2].HeaderText = "National No.";
              

                dataGridView1.Columns[3].HeaderText = "Full Name";
              

                dataGridView1.Columns[4].HeaderText = "Application Date";
              

                dataGridView1.Columns[5].HeaderText = "Passed Tests";
               
            }

            _StyleGrid();


            UpdateRecordCount(_dtAllLocalDrivingLicenseApplications.Rows.Count);

            

        }

        private void editApplicationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddEditLocalDrivingLicense AddEdit = new AddEditLocalDrivingLicense((int)dataGridView1.CurrentRow.Cells[0].Value);
            AddEdit.Show();
            LocalDrivingLicenseApp_Load(null, null);
        }

        private void txtSerach_TextChanged(object sender, EventArgs e)
        {
            string FilterColumn = "";
           
            switch (comboBox1.Text)
            {

                case "L.D.L.AppID":
                    FilterColumn = "LocalDrivingLicenseApplicationID";
                    break;

                case "National No.":
                    FilterColumn = "NationalNo";
                    break;


                case "Full Name":
                    FilterColumn = "FullName";
                    break;

                case "Status":
                    FilterColumn = "Status";
                    break;


                default:
                    FilterColumn = "None";
                    break;

            }

           
            if (txtSerach.Text.Trim() == "")
            {
                _dtAllLocalDrivingLicenseApplications.DefaultView.RowFilter = "";
                UpdateRecordCount(dataGridView1.Rows.Count);
                return;
            }


            if (FilterColumn == "LocalDrivingLicenseApplicationID")

                _dtAllLocalDrivingLicenseApplications.DefaultView.RowFilter = string.Format("[{0}] = {1}", FilterColumn, txtSerach.Text.Trim());
            else
                _dtAllLocalDrivingLicenseApplications.DefaultView.RowFilter = string.Format("[{0}] LIKE '{1}%'", FilterColumn, txtSerach.Text.Trim());

            UpdateRecordCount(dataGridView1.Rows.Count);
        }

        private void txtSerach_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (comboBox1.Text == "L.D.L.AppID")
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void cancelToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (MessageBox.Show("Are you sure do you Want to Cancel this Application?", "Confirm Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }

            int LocalLicenseApplicationID = (int)dataGridView1.CurrentRow.Cells[0].Value;

            ClsLicenseDrivingLocal licenseDrivingLocal = ClsLicenseDrivingLocal.FindByLocalDrivingAppLicenseID(LocalLicenseApplicationID);

            if (licenseDrivingLocal != null)
            {

                if (licenseDrivingLocal.Cancel())
                {

                    MessageBox.Show("Application Cancelled Successfully", "Cancelled Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LocalDrivingLicenseApp_Load(null, null);

                }
                else
                {
                    MessageBox.Show("Application could not Cancelled", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }



        }

        private void deleteApplicationToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (MessageBox.Show("Are you sure do you Want to delete this Application?", "Confirm Message", MessageBoxButtons.YesNo,MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }

            int LocalLicenseApplicationID = (int)dataGridView1.CurrentRow.Cells[0].Value;

            ClsLicenseDrivingLocal licenseDrivingLocal = ClsLicenseDrivingLocal.FindByLocalDrivingAppLicenseID(LocalLicenseApplicationID);

            if(licenseDrivingLocal != null)
            {

                if (licenseDrivingLocal.Delete())
                {

                    MessageBox.Show("Application Deleted Successfully", "Deleted Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LocalDrivingLicenseApp_Load(null, null);
                }
                else
                {
                    MessageBox.Show("Application could not Deleted", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }

            

        }

        private void _ScheduleTest(clsTestType.enTestType TestType)
        {

            int LocalDrivingLicenseApplicationID = (int)dataGridView1.CurrentRow.Cells[0].Value;
            FrmScheduleTest frm = new FrmScheduleTest(LocalDrivingLicenseApplicationID, TestType);
            frm.ShowDialog();
          
            LocalDrivingLicenseApp_Load(null, null);

        }

        private void sechduleTestsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void issueDrivingLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Is Still This Option dosent Implement", "Implement Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void showLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Is Still This Option dosent Implement", "Implement Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void showPersonLicenseHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Is Still This Option dosent Implement", "Implement Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

            int LocalLicenseAppID = (int)dataGridView1.CurrentRow.Cells[0].Value;

            ClsLicenseDrivingLocal LicenseDrivingLocal = ClsLicenseDrivingLocal.FindByLocalDrivingAppLicenseID(LocalLicenseAppID);


            int TotalTestPassed = (int)dataGridView1.CurrentRow.Cells[5].Value;

            bool lisenseExist = LicenseDrivingLocal.IsLicenseIssued();

            issueDrivingLicenseToolStripMenuItem.Enabled = (TotalTestPassed == 3) && !lisenseExist;

            showLicenseToolStripMenuItem.Enabled = lisenseExist;

            editApplicationToolStripMenuItem.Enabled = !lisenseExist && (LicenseDrivingLocal._ApplicationStatus == ClsApplication.enApplicationStatus.New);

            sechduleTestsToolStripMenuItem.Enabled = !lisenseExist;

            cancelToolStripMenuItem.Enabled = (LicenseDrivingLocal._ApplicationStatus == ClsApplication.enApplicationStatus.New);

            deleteApplicationToolStripMenuItem.Enabled = (LicenseDrivingLocal._ApplicationStatus == ClsApplication.enApplicationStatus.New);

            bool PassedVisionTest = LicenseDrivingLocal.DoesPassTestType(clsTestType.enTestType.VisionTest); ;
            bool PassedWrittenTest = LicenseDrivingLocal.DoesPassTestType(clsTestType.enTestType.WrittenTest);
            bool PassedStreetTest = LicenseDrivingLocal.DoesPassTestType(clsTestType.enTestType.StreetTest);

            sechduleTestsToolStripMenuItem.Enabled = (!PassedVisionTest || !PassedWrittenTest || !PassedStreetTest) && (LicenseDrivingLocal._ApplicationStatus == ClsApplication.enApplicationStatus.New);

            if (sechduleTestsToolStripMenuItem.Enabled)
            {
                
                sechduleVesionTestToolStripMenuItem.Enabled = !PassedVisionTest;

                
                sechduleWritteTestToolStripMenuItem.Enabled = PassedVisionTest && !PassedWrittenTest;

               
                sechduleStrToolStripMenuItem.Enabled = PassedVisionTest && PassedWrittenTest && !PassedStreetTest;

            }



        }

        private void sechduleVesionTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _ScheduleTest(clsTestType.enTestType.VisionTest);
        }

        private void sechduleWritteTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _ScheduleTest(clsTestType.enTestType.WrittenTest);
        }

        private void sechduleStrToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _ScheduleTest(clsTestType.enTestType.StreetTest);
        }
    }
}
