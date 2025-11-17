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

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            AddEditLocalDrivingLicense addEditLocalDrivingLicense = new AddEditLocalDrivingLicense();
            addEditLocalDrivingLicense.ShowDialog();
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

           
            

        }
    }
}
