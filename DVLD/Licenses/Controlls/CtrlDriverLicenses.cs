using System;
using System.CodeDom;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BussniesDVLDLayer;

namespace DVLD.Licenses.Controlls
{
    public partial class CtrlDriverLicenses : System.Windows.Forms.UserControl
    {

        private int _DriverID = -1;
        private DataTable _dtLocalLicensesHistory;
        private DataTable _dtInternationalHistory;

        private ClsDriver _Driver;

        public CtrlDriverLicenses()
        {
            InitializeComponent();
        }

        private void _StyleGrid(DataGridView dgv)
        {

            dgv.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
           

            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv.MultiSelect = false;
            dgv.ReadOnly = true; 
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

        private void UpdateRecordCount(System.Windows.Forms.Label lblCount ,int Count)
        {
            lblCount.Text = $"# Records:    {Count}";
            lblCount.Font = new Font("Segoe UI", 10F, FontStyle.Bold);

        }

        private void _LoadLocaLicensesHistroy()
        {
            
            _dtLocalLicensesHistory = ClsDriver.GetLicenses(_DriverID);
            dgvLocal.DataSource = _dtLocalLicensesHistory;
            if (_dtLocalLicensesHistory != null)
            {
                UpdateRecordCount(lblCount, _dtLocalLicensesHistory.Rows.Count);
            }

        }

        private void _LoadInternationalLicensesHistory()
        {
            
            _dtInternationalHistory = ClsDriver.GetInternational(_DriverID);
            dgvInternational.DataSource = _dtInternationalHistory;
            if (_dtInternationalHistory != null)
            {
                UpdateRecordCount(lblCount1, _dtInternationalHistory.Rows.Count);
            }
        }

        private void _InitControlls()
        {
            _StyleGrid(dgvLocal);
            _StyleGrid(dgvInternational);
        }

        public void LoadInfor(int DriverID)
        {
            _DriverID = DriverID;
            _Driver = ClsDriver.FindByDriverID(_DriverID);

            if(_Driver == null)
            {
                MessageBox.Show("Driver not found with id = " + _DriverID.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _InitControlls();
            _LoadLocaLicensesHistroy();
            _LoadInternationalLicensesHistory();

            
        }

        public void LoadInfoByPersonID(int PersonID)
        {
             _Driver = ClsDriver.FindByPersonID(PersonID);

            if(_Driver == null)
            {
                MessageBox.Show("Driver not found with Person id = " + PersonID.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _DriverID = _Driver._DriverID;

            _InitControlls();
            _LoadLocaLicensesHistroy();
            _LoadInternationalLicensesHistory();
          
        }

        public void Clear()
        {

            _dtLocalLicensesHistory.Clear();
            _dtInternationalHistory.Clear();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void showLicenseInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {

            int LicenseID = (int)dgvLocal.CurrentRow.Cells[0].Value;

            ShowLicenseInfo show = new ShowLicenseInfo(LicenseID);
            show.ShowDialog();
        }
    }
}
