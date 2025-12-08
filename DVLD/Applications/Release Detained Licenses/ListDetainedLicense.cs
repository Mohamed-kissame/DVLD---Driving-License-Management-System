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

namespace DVLD.Applications.Release_Detained_Licenses
{
    public partial class ListDetainedLicense : Form
    {

        private DataTable _dtDetained;

        public ListDetainedLicense()
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

        private void _UpdateUIWhenEmpty()
        {
            bool hasRows = dgv.Rows.Count > 0;

            btnDetained.Enabled = hasRows;
            btnRelease.Enabled = hasRows;
            comboBox1.Enabled = hasRows;
            txtSearch.Enabled = hasRows;
        }


        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void ListDetainedLicense_Load(object sender, EventArgs e)
        {

            _dtDetained = ClsDetained.GetAllDetainedLicense();

            dgv.DataSource = _dtDetained;

            if(dgv.Rows.Count > 0)
            {

                dgv.Columns[0].HeaderText = "D.ID";

                dgv.Columns[1].HeaderText = "L.ID";

                dgv.Columns[2].HeaderText = "D.Date";

                dgv.Columns[3].HeaderText = "Is Released";

                dgv.Columns[4].HeaderText = "Fine Fees";

                dgv.Columns[5].HeaderText = "Release Date";

                dgv.Columns[6].HeaderText = "N.No";

                dgv.Columns[7].HeaderText = "Full Name";

                dgv.Columns[8].HeaderText = "Release App.ID";

            }

            _StyleGrid();
            UpdateRecordCount(_dtDetained.Rows.Count);

            _UpdateUIWhenEmpty();

        }

        private void txtSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (comboBox1.Text.Trim() == "Driver ID" || comboBox1.Text.Trim() == "Release Application ID")
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string FilterColumn = "";

            switch (comboBox1.Text)
            {

                case "Driver ID":
                    FilterColumn = "DriverID";
                    break;

                case "Is Released":
                    FilterColumn = "IsReleased";
                    break;

                case "National No":
                    FilterColumn = "NationalNo";
                    break;

                case "Full Name":
                    FilterColumn = "FullName";
                    break;

                case "Release Application ID":
                    FilterColumn = "ReleaseApplicationID";
                    break;

             

            }

            if (txtSearch.Text.Trim() == "")
            {
                _dtDetained.DefaultView.RowFilter = "";
                UpdateRecordCount(dgv.Rows.Count);
                return;
            }

            if (FilterColumn == "DriverID" || FilterColumn == "ReleaseApplicationID")
                _dtDetained.DefaultView.RowFilter = string.Format("[{0}] = {1}", FilterColumn, txtSearch.Text.Trim());
            else
                _dtDetained.DefaultView.RowFilter = string.Format("[{0}] LIKE '{1}%'", FilterColumn, txtSearch.Text.Trim());

            UpdateRecordCount(dgv.Rows.Count);

           
        }

        private void btnDetained_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Is Not Implemented Yet ", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void btnRelease_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Is Not Implemented Yet ", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void showPersonDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Is Not Implemented Yet ", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void showToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Is Not Implemented Yet ", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void showPersonLicensesHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Is Not Implemented Yet ", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void releaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Is Not Implemented Yet ", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void dgv_Paint(object sender, PaintEventArgs e)
        {
            if (dgv.Rows.Count == 0)
            {
                string message = "No detained licenses found.";
                using (Font font = new Font("Segoe UI", 12, FontStyle.Bold))
                {
                    TextRenderer.DrawText(
                        e.Graphics,
                        message,
                        font,
                        dgv.ClientRectangle,
                        Color.Gray,
                        TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
                }
            }
        }
    }
}
