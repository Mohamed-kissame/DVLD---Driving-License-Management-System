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


namespace DVLD.Pepole
{
    public partial class Pepole : Form
    {
        public Pepole()
        {
            InitializeComponent();

            this.Font = new Font("Segoe UI", 10f);
            this.BackColor = Color.FromArgb(245, 245, 245);
        }

       
        private static DataTable _dt = clsPeople.GetAllPepole();

        private DataTable _dTPepole = _dt.DefaultView.ToTable(false, "PersonID", "NationalNo" , "FirstName", "LastName", "DateOfBirth", "Gender", "Nationality", "Email", "Phone");

        

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

        private void RefreshPepole()
        {

            _dt = clsPeople.GetAllPepole();
            _dTPepole = _dt.DefaultView.ToTable(false, "PersonID", "NationalNo" , "FirstName", "LastName", "DateOfBirth", "Gender", "Nationality", "Email", "Phone");

            dgv.DataSource = _dTPepole;

            UpdateRecordCount(_dTPepole.Rows.Count);
           
        }

        private void FillFilter()
        {
           
            foreach (DataColumn col in _dt.Columns)
            {

                comboBox1.Items.Add(col.ColumnName);
            }

            if (comboBox1.Items.Count > 0)
                comboBox1.SelectedIndex = 0;

        }

        private void StyleHeader()
        {

            lblTitle.Text = "Manage Pepole";
            lblTitle.Dock = DockStyle.Right;
            lblTitle.TextAlign = ContentAlignment.MiddleCenter;
            lblTitle.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblTitle.ForeColor = Color.FromArgb(45, 45, 48);


            pictureBox1.Size = new Size(56, 56);
            pictureBox1.Dock = DockStyle.Left;
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.Margin = new Padding(8, 8, 12, 8);

            pLine.BackColor = Color.FromArgb(230, 230, 230);
        }

        

        private void Pepole_Load(object sender, EventArgs e)
        {

            dgv.DataSource = _dTPepole;

            FillFilter();

            UpdateRecordCount(_dTPepole.Rows.Count);

            _StyleGrid();

            StyleHeader();

          
        }

        private void dgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

    

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {


            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;

            txtBoxeSearch.Visible = (comboBox1.Text != "None");

            lblSearchTitle.Visible = (comboBox1.Text != "None");

            if (txtBoxeSearch.Visible)
            {
                txtBoxeSearch.Text = "";
                lblSearchTitle.Visible = true;
                txtBoxeSearch.Focus();
            }
         


        }

        private void txtBoxeSearch_TextChanged(object sender, EventArgs e)
        {

            string FilterColumn = "";

            switch (comboBox1.Text)
            {

                case "PersonID":
                    FilterColumn = "PersonID";
                    break;

                case "NationalNo":
                    FilterColumn = "NationalNo";
                    break;

                case "FirstName":
                    FilterColumn = "FirstName";
                    break;

                case "LastName":
                    FilterColumn = "LastName";
                    break;

                case "DateOfBirth":
                    FilterColumn = "DateOfBirth";
                    break;

                case "Gender":
                    FilterColumn = "Gender";
                    break;

                case "Nationality":
                    FilterColumn = "Nationality";
                    break;

                case "Email":
                    FilterColumn = "Email";
                    break;

                case "Phone":
                    FilterColumn = "Phone";
                    break;


                default:
                    FilterColumn = "None";
                    break;

            }

            if (txtBoxeSearch.Text.Trim() == "" || FilterColumn == "None")
            {
                _dTPepole.DefaultView.RowFilter = "";
                UpdateRecordCount(dgv.Rows.Count);
                return;
            }

            if (FilterColumn == "PersonID")
                _dTPepole.DefaultView.RowFilter = string.Format("[{0}] = {1}", FilterColumn, txtBoxeSearch.Text.Trim());
            else
                _dTPepole.DefaultView.RowFilter = string.Format("[{0}] LIKE '{1}%'", FilterColumn, txtBoxeSearch.Text.Trim());

           UpdateRecordCount(dgv.Rows.Count);
          
        }

        private void txtBoxeSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (comboBox1.Text == "PersonID")
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            AddEditPepole from = new AddEditPepole();
            from.ShowDialog();
            RefreshPepole();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {

            int personID = Convert.ToInt32(dgv.CurrentRow.Cells[0].Value);

            if (MessageBox.Show(
              "Are you sure you want to delete person " + personID.ToString(),
              " Confirm Delete",
               MessageBoxButtons.YesNo,
               MessageBoxIcon.Question) == DialogResult.Yes)
            {


                if (clsPeople.isExistsInUser(personID))
                {


                    MessageBox.Show("Cannot delete this person because it is linked to a user account",
                           "Delete Error",
                           MessageBoxButtons.OK,
                           MessageBoxIcon.Error);
                    

                   
                }
                else
                {

                    if (clsPeople.DeletePerson(personID))
                    {
                        MessageBox.Show("Person with ID " + personID + " Deleted Successfuly ", "Delete Message", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        RefreshPepole();

                    }

                }
                
            }
          
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
  
            AddEditPepole form = new AddEditPepole((int)dgv.CurrentRow.Cells[0].Value);
            form.ShowDialog();
            RefreshPepole();
        }

        private void addNewPersonToolStripMenuItem_Click(object sender, EventArgs e)
        {

            AddEditPepole form = new AddEditPepole();
            form.ShowDialog();
            RefreshPepole();

        }

        private void showDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowDetailPerson Form = new ShowDetailPerson((int)dgv.CurrentRow.Cells[0].Value);
            Form.ShowDialog();
            
            

        }

        private void PanalHeader_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dgv_Paint(object sender, PaintEventArgs e)
        {
            if (dgv.Rows.Count == 0)
            {
                string message = "No People found.";
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

        private void guna2TileButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}