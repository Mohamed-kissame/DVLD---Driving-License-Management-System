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

namespace DVLD.ApplicationTypes
{
    public partial class Manage_Application_Types : Form
    {
        public Manage_Application_Types()
        {
            InitializeComponent();
        }

        private static DataTable _dt = clsApplicationType.GetALLApplicationType();
        private DataTable _dtApplication = _dt.DefaultView.ToTable(false, "ApplicationTypeID", "ApplicationTypeTitle", "ApplicationFees");


        private void UpdateRecordCount(int Count)
        {

            lblCount.Text = $"# Records: {Count}";
            lblCount.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
        }

        private void RefrechApplication()
        {

            _dt = clsApplicationType.GetALLApplicationType();

            _dtApplication = _dt.DefaultView.ToTable(false, "ApplicationTypeID", "ApplicationTypeTitle", "ApplicationFees");

            dataGridView1.DataSource = _dtApplication;

            UpdateRecordCount(_dtApplication.Rows.Count);

        }

        private void _StyleGrid()
        {
            //dgv.Dock = DockStyle.Bottom;
            dataGridView1.BorderStyle = BorderStyle.FixedSingle;

            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.MultiSelect = false;
            dataGridView1.ReadOnly = true; // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.RowHeadersVisible = false;

            // Header
            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(0, 122, 204);
            dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            dataGridView1.ColumnHeadersHeight = 36;

            // Rows
            dataGridView1.DefaultCellStyle.Font = new Font("Segoe UI", 10);
            dataGridView1.DefaultCellStyle.SelectionBackColor = Color.FromArgb(229, 241, 251);
            dataGridView1.DefaultCellStyle.SelectionForeColor = Color.Black;
            dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(245, 245, 245);

            // Reduce flicker (enable DoubleBuffered via reflection – DGV’s property is protected)
            typeof(DataGridView).GetProperty("DoubleBuffered",
                System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic)
                ?.SetValue(dataGridView1, true, null);
        }

        private void Manage_Application_Types_Load(object sender, EventArgs e)
        {

           
            dataGridView1.DataSource = _dtApplication;

            UpdateRecordCount(_dtApplication.Rows.Count);

            _StyleGrid();

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void editApplicationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EditApplication editApplication = new EditApplication((int)dataGridView1.CurrentRow.Cells[0].Value);
            editApplication.ShowDialog();
            RefrechApplication();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
