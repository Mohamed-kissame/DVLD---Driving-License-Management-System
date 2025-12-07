using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Forms;
using BussniesDVLDLayer;
using DVLD.controlls;
using DVLD.Licenses;
using DVLD.Pepole;

namespace DVLD.InternationalLicense
{
    public partial class InternationalLicenseApp : Form
    {

        private DataTable _dtInternationalLicenses;

        private ClsInternationalLicense _InternationalLicense;

   
        private int _GetPersonID()
        {
            int _PersonID = -1;

            _InternationalLicense = ClsInternationalLicense.Find((int)dgv.CurrentRow.Cells[0].Value);

            if(_InternationalLicense != null)
            {
                _PersonID = _InternationalLicense._PersonID;

            }

            return _PersonID;

        }

        public InternationalLicenseApp()
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

            dgv.BorderStyle = BorderStyle.FixedSingle;

            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv.MultiSelect = false;
            dgv.ReadOnly = true; // 
            dgv.AllowUserToAddRows = false;
            dgv.RowHeadersVisible = false;


            dgv.EnableHeadersVisualStyles = false;
            dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(0, 122, 204);
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            dgv.ColumnHeadersHeight = 36;


            dgv.DefaultCellStyle.Font = new Font("Segoe UI", 10);
            dgv.DefaultCellStyle.SelectionBackColor = Color.FromArgb(229, 241, 251);
            dgv.DefaultCellStyle.SelectionForeColor = Color.Black;
            dgv.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(245, 245, 245);


            typeof(DataGridView).GetProperty("DoubleBuffered",
                System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic)
                ?.SetValue(dgv, true, null);
        }

        private void InternationalLicenseApp_Load(object sender, EventArgs e)
        {

            _dtInternationalLicenses = ClsInternationalLicense.GetAllInternationalLicense();
            _dtInternationalLicenses = _dtInternationalLicenses.DefaultView.ToTable(false, "InternationalLicenseID", "DriverID", "IssuedUsingLocalLicenseID", "IssueDate", "ExpirationDate", "IsActive");

            dgv.DataSource = _dtInternationalLicenses;

            comboBox1.SelectedIndex = 0;

            if(dgv.Rows.Count > 0)
            {
                dgv.Columns[0].HeaderText = "Int.License ID";

                dgv.Columns[1].HeaderText = "Driver ID";

                dgv.Columns[2].HeaderText = "L.License ID";

                dgv.Columns[3].HeaderText = "Issue Date";

                dgv.Columns[4].HeaderText = "Expiration Date";

                dgv.Columns[5].HeaderText = "Is Active";
            }

            _StyleGrid();

            UpdateRecordCount(_dtInternationalLicenses.Rows.Count);

        }


        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string FilterColumn = "";

            switch (comboBox1.Text)
            {
                case "Int.License ID":
                    FilterColumn = "InternationalLicenseID";
                    break;
                case "Driver ID":
                    FilterColumn = "DriverID";
                    break;
                case "L.License ID":
                    FilterColumn = "IssuedUsingLocalLicenseID";
                    break;
                default:
                    FilterColumn = "InternationalLicenseID";
                    break;
            }

            if (txtSearch.Text.Trim() == "")
            {
                _dtInternationalLicenses.DefaultView.RowFilter = "";
                UpdateRecordCount(_dtInternationalLicenses.Rows.Count);
                return;

            }

            if (FilterColumn == "InternationalLicenseID" || FilterColumn == "DriverID" || FilterColumn == "IssuedUsingLocalLicenseID")
            {

                _dtInternationalLicenses.DefaultView.RowFilter = string.Format("{0} = {1}", FilterColumn, txtSearch.Text.Trim());
                UpdateRecordCount(_dtInternationalLicenses.DefaultView.Count);

            }

        }

        private void txtSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (txtSearch.Text.Trim() == "InternationalLicenseID" || txtSearch.Text.Trim() == "DriverID" || txtSearch.Text.Trim() == "IssuedUsingLocalLicenseID")
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void showToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ShowIntLicenseInfo intLicenseInfo = new ShowIntLicenseInfo();
            intLicenseInfo.ShowDialog();
        }

        private void showToolStripMenuItem_Click(object sender, EventArgs e)
        {

            int PersonID = _GetPersonID();

            ShowDetailPerson detailPerson = new ShowDetailPerson(PersonID);
            detailPerson.ShowDialog();
           
        }

        private void showLicensesHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int PersonID = _GetPersonID();

            ShowPersonLicensesHistory licensesHistory = new ShowPersonLicensesHistory(PersonID);
            licensesHistory.ShowDialog();
        }
    }
}
