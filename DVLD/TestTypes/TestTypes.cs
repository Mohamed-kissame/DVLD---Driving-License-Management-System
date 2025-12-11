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
using DVLD.ApplicationTypes;

namespace DVLD.TestTypes
{
    public partial class TestTypes : Form
    {


        public TestTypes()
        {
            InitializeComponent();
        }

        private static DataTable _dt = clsTestType.GetAllTest();
        private DataTable _DtTest = _dt.DefaultView.ToTable(false, "TestTypeID", "TestTypeTitle", "TestTypeDescription", "TestTypeFees");

        private void UpdateRecordCount(int Count)
        {

            lblCount.Text = $"# Records: {Count}";
            lblCount.Font = new Font("Segoe UI", 10F, FontStyle.Bold);

        }

        private void RefreshTestTypes()
        {

            _dt = clsTestType.GetAllTest();

            _DtTest = _dt.DefaultView.ToTable(false, "TestTypeID", "TestTypeTitle", "TestTypeDescription", "TestTypeFees");

            dataGridView1.DataSource = _DtTest;

            UpdateRecordCount(_DtTest.Rows.Count);

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

        private void label2_Click(object sender, EventArgs e)
        {

        }

      

        private void TestTypes_Load(object sender, EventArgs e)
        {

            dataGridView1.DataSource = _DtTest;

            UpdateRecordCount(_DtTest.Rows.Count);

            _StyleGrid();
        }

        private void editTestToolStripMenuItem_Click(object sender, EventArgs e)
        {

            EditTestTypes editTestTypes = new EditTestTypes((int)dataGridView1.CurrentRow.Cells[0].Value);
            editTestTypes.ShowDialog();
            RefreshTestTypes();
        }

        private void guna2TileButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
