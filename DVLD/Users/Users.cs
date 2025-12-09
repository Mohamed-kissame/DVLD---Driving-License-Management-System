using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BussniesDVLDLayer;
using DVLD.controlls;
using Newtonsoft.Json.Linq;

namespace DVLD.Users
{
    public partial class Users : Form
    {
        public Users()
        {
            InitializeComponent();

            cmbIsActive.Visible = false;
        }

        private static DataTable _Dt = clsUsers.GetAllUsers();
        private DataTable _dtUsers = _Dt.DefaultView.ToTable(false, "UserID", "PersonID" , "FullName", "UserName" , "IsActive");
        

        private void UpdateRecordCount(int Count)
        {
           
            lblCount.Text = $"# Records: {Count}";
            lblCount.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
        }

        private void FillFilter()
        {
            foreach (DataColumn col in _Dt.Columns)
            {

                comboBox1.Items.Add(col.ColumnName);
            }

            if (comboBox1.Items.Count > 0)
                comboBox1.SelectedIndex = 0;
        }

        private void RefrechUsers()
        {

            _Dt = clsUsers.GetAllUsers();

            _dtUsers = _Dt.DefaultView.ToTable(false, "UserID", "PersonID", "FullName", "UserName", "IsActive");

            dataGridView1.DataSource = _dtUsers;

            UpdateRecordCount(_dtUsers.Rows.Count);

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

        private void Filter()
        {

            string FilterName = "";

            switch (comboBox1.Text)
            {

                case "UserID":
                    FilterName = "UserID";
                    break;

                case "PersonID":
                    FilterName = "PersonID";
                    break;

                case "UserName":
                    FilterName = "UserName";
                    break;

                case "FullName":
                    FilterName = "FullName";
                    break;

                case "IsActive":
                    FilterName = "IsActive";
                    break;

                case "None":
                    FilterName = "None";
                    break;
                
            }

            if (txtSearch.Text.Trim() == "" || FilterName == "None")
            {
                _dtUsers.DefaultView.RowFilter = "";
                UpdateRecordCount(_dtUsers.Rows.Count);
                return;
            }

            if(FilterName == "UserID" || FilterName == "PersonID")
                _dtUsers.DefaultView.RowFilter = string.Format("[{0}] = {1}", FilterName, txtSearch.Text.Trim());
            else
                _dtUsers.DefaultView.RowFilter = string.Format("[{0}] LIKE '{1}%'", FilterName, txtSearch.Text.Trim());

            if (FilterName == "IsActive")
            {
             
                if (FilterName == "IsActive" && cmbIsActive.Text == "Yes")
                    _dtUsers.DefaultView.RowFilter = string.Format("[{0}] = {1}" , FilterName , true);
                else
                    _dtUsers.DefaultView.RowFilter = string.Format("[{0}] = {1}" , FilterName , false);
            }


            UpdateRecordCount(_dtUsers.DefaultView.Count);

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Users_Load(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = 0;

            dataGridView1.DataSource = _dtUsers;

            UpdateRecordCount(_dtUsers.Rows.Count);

            FillFilter();

            _StyleGrid();


        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {

            Filter();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;

            if (comboBox1.Text == "IsActive")
            {
                txtSearch.Visible = false;
                lblSearch.Visible = false;

                cmbIsActive.Visible = true;
                cmbIsActive.SelectedIndex = 0; 
            }
            else if (comboBox1.Text == "None")
            {
                txtSearch.Visible = false;
                lblSearch.Visible = false;
                cmbIsActive.Visible = false;
            }
            else
            {
                txtSearch.Visible = true;
                lblSearch.Visible = true;
                txtSearch.Text = "";
                txtSearch.Focus();

                cmbIsActive.Visible = false;
            }


        }

        private void txtSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (comboBox1.Text == "UserID" || comboBox1.Text == "PersonID")
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {

            AddEditUser addEditUser = new AddEditUser();
            addEditUser.ShowDialog();
            RefrechUsers();

        }

        private void addNewUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddEditUser addEditUser = new AddEditUser();
            addEditUser.ShowDialog();
            RefrechUsers();
        }

        private void updateUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddEditUser addEditUser = new AddEditUser((int)dataGridView1.CurrentRow.Cells[0].Value);
            addEditUser.ShowDialog();
            RefrechUsers();
        }

        private void deleteUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int UserId = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);

            if (MessageBox.Show(
              "Are you sure you want to delete user " + UserId.ToString(),
              " Confirm Delete",
               MessageBoxButtons.YesNo,
               MessageBoxIcon.Question) == DialogResult.Yes)
            {

                if (clsUsers.DeleteUser(UserId))
                {

                    MessageBox.Show("User with ID " + UserId + " Deleted Successfuly ", "Delete Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    RefrechUsers();

                }
                else
                {

                    MessageBox.Show("Cannot delete this User because it is linked",
                           "Delete Error",
                           MessageBoxButtons.OK,
                           MessageBoxIcon.Error);
                }
            }
        }

        private void showInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowUserInfo show = new ShowUserInfo((int)dataGridView1.CurrentRow.Cells[0].Value);
            show.ShowDialog();
            RefrechUsers();
        }

        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChangePassword change = new ChangePassword((int)dataGridView1.CurrentRow.Cells[0].Value);
            change.ShowDialog();
            RefrechUsers();
        }

        private void dataGridView1_Paint(object sender, PaintEventArgs e)
        {
            if (dataGridView1.Rows.Count == 0)
            {
                string message = "No Users found.";
                using (Font font = new Font("Segoe UI", 12, FontStyle.Bold))
                {
                    TextRenderer.DrawText(
                        e.Graphics,
                        message,
                        font,
                        dataGridView1.ClientRectangle,
                        Color.Gray,
                        TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
                }
            }
        }
    }
}
