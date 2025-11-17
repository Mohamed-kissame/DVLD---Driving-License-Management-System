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

namespace DVLD.Driver
{
    public partial class DriverView : Form
    {
        public DriverView()
        {
            InitializeComponent();
        }

        private DataTable _dtDriver;

        private void _StyleGrid()
        {
            //dgv.Dock = DockStyle.Bottom;
            dgv.BorderStyle = BorderStyle.FixedSingle;

            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv.MultiSelect = false;
            dgv.ReadOnly = true; // You edit via dialog/context menu
            dgv.AllowUserToAddRows = false;
            dgv.RowHeadersVisible = false;

            // Header
            dgv.EnableHeadersVisualStyles = false;
            dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(0, 122, 204);
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            dgv.ColumnHeadersHeight = 36;

            // Rows
            dgv.DefaultCellStyle.Font = new Font("Segoe UI", 10);
            dgv.DefaultCellStyle.SelectionBackColor = Color.FromArgb(229, 241, 251);
            dgv.DefaultCellStyle.SelectionForeColor = Color.Black;
            dgv.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(245, 245, 245);

            // Reduce flicker (enable DoubleBuffered via reflection – DGV’s property is protected)
            typeof(DataGridView).GetProperty("DoubleBuffered",
                System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic)
                ?.SetValue(dgv, true, null);
        }

        private void UpdateRecordCount(int count)
        {
            lblCountRecord.Text = $"# Records:    {count}";
            lblCountRecord.Font = new Font("Segoe UI", 10F, FontStyle.Bold);

        }



        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void DriverView_Load(object sender, EventArgs e)
        {

            comboBox1.SelectedIndex = 0;

            _dtDriver = ClsDriver.GetAllDrivers();

            dgv.DataSource = _dtDriver;

            _StyleGrid();

            UpdateRecordCount(_dtDriver.Rows.Count);


        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {


            string FilterName = "";

            switch (comboBox1.Text) {


                case "DriverID":
                    FilterName = "DriverID";
                    break;

                case "PersonID":
                    FilterName = "PersonID";
                    break;

                case "FullName":
                    FilterName = "FullName";
                    break;

                case "NationalNo":
                    FilterName = "NationalNo";
                    break;

                default:
                    FilterName = "DriverID";
                    break;
                   
                 

            }


            if(txtSearch.Text.Trim() == "")
            {

                _dtDriver.DefaultView.RowFilter = "";
                UpdateRecordCount(dgv.Rows.Count);
                return;

            }


            if (FilterName == "DriverID" || FilterName == "PersonID")
            {

                _dtDriver.DefaultView.RowFilter = string.Format("[{0}] = {1}", FilterName, txtSearch.Text.Trim());
                
            }
            else
            {

                _dtDriver.DefaultView.RowFilter = string.Format("[{0}] LIKE '{1}%'", FilterName, txtSearch.Text.Trim());

            }

            UpdateRecordCount(dgv.Rows.Count);


        }

        private void txtSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (comboBox1.Text == "DriverID" || comboBox1.Text == "PersonID")
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
    }
}
