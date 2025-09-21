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

       
        private DataTable _dt;
        private DataView _dv;

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

      

        private void UpdateRecordCount()
        {
            int count = (_dv != null) ? _dv.Count : (_dt?.Rows.Count ?? 0);
            lblCountRecord.Text = $"# Records:    {count}";
            lblCountRecord.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
        }

        private void RefreshPepole()
        {

            _dt = clsPepole.GetAllPepole();
            _dv = new DataView(_dt);

            dgv.DataSource = _dv;

            UpdateRecordCount();

            comboBox1.Items.Clear();

            comboBox1.Items.Add("None");

            foreach (DataColumn col in _dt.Columns)
            {

                comboBox1.Items.Add(col.ColumnName);
            }

            if (comboBox1.Items.Count > 0)
                comboBox1.SelectedIndex = 0;
        }

        private void Search()
        {

            if (_dv?.Table != null)
            {
                _dv.Table.CaseSensitive = false;
            }


            if (comboBox1.SelectedIndex > 0 && !string.IsNullOrEmpty(txtBoxeSearch.Text))
            {

                string colName = comboBox1.SelectedItem.ToString();
                string VAlue = txtBoxeSearch.Text.Trim().Replace("'", "''");


                try
                {

                    if (colName == "PersonID" || colName == "Phone")
                    {

                        if (!int.TryParse(VAlue, out _))
                        {

                            MessageBox.Show($"{colName} must be numeric.");
                            return;

                        }
                        else
                        {
                            _dv.RowFilter = $"[{colName}] = {VAlue}";
                        }

                    }

                    else if (colName == "NationalNo")
                    {
                        // Alphanumeric (letters + numbers)
                        if (!System.Text.RegularExpressions.Regex.IsMatch(VAlue, @"^[A-Za-z0-9]+$"))
                        {
                            MessageBox.Show("NationalNo must contain only letters and numbers.");
                            return;
                        }
                        _dv.RowFilter = $"[{colName}] LIKE '%{VAlue}%'";
                    }

                    else if (_dt.Columns[colName].ColumnName == typeof(DateTime).Name)
                    {

                        if (DateTime.TryParse(VAlue, out DateTime dob))
                        {
                            _dv.RowFilter = $"[{colName}] = #{dob:yyyy/MM/dd}#";
                        }
                        else
                        {
                            MessageBox.Show("Please enter a valid date (e.g. 2000-12-31).");
                            return;
                        }


                    }

                    else if (colName == "FirstName" || colName == "SecondName" || colName == "ThirdName" || colName == "LastName")
                    {

                        if (!System.Text.RegularExpressions.Regex.IsMatch(VAlue, @"^[A-Za-z]+$"))
                        {

                            MessageBox.Show($"{colName} must contain Only Letters");
                            return;
                        }
                        else
                        {
                            _dv.RowFilter = $"{colName} Like '%{VAlue}%'";
                        }

                    }

                    else if (colName == "Email")
                    {

                        if (!System.Text.RegularExpressions.Regex.IsMatch(VAlue, @"^[A-Za-z0-9@._-]*$"))
                        {
                            MessageBox.Show("Email can only contain letters, numbers, @, dot, underscore (_) or dash (-).");
                            return;
                        }

                        else
                        {

                            _dv.RowFilter = $"{colName} LIKE '%{VAlue}%'";

                        }
                    }



                }
                catch (Exception ex)
                {

                    MessageBox.Show("Error in search : " + ex.Message);
                    _dv.RowFilter = string.Empty;
                }


            }


            dgv.DataSource = _dv;


            UpdateRecordCount();


        }

        private void Pepole_Load(object sender, EventArgs e)
        {
            RefreshPepole();
            _StyleGrid();

            //fillDataGrade1.RefreshPepole();

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



        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pblogo_Click(object sender, EventArgs e)
        {

        }

        private void dgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;

            if (comboBox1.SelectedIndex == 0)
            {

                txtBoxeSearch.Visible = false;
                lblSearchTitle.Visible = false;
            }
            else
            {

                txtBoxeSearch.Visible = true;
                lblSearchTitle.Visible = true;
            }

            Search();

        }

        private void txtBoxeSearch_TextChanged(object sender, EventArgs e)
        {

            Search();

            if (string.IsNullOrWhiteSpace(txtBoxeSearch.Text))
            {
                dgv.DataSource = _dt;
                UpdateRecordCount();
            }
        }

        private void txtBoxeSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (comboBox1.SelectedItem == null) return;

            string colName = comboBox1.SelectedItem.ToString();


            if (colName == "PersonID" || colName == "Phone")
            {

                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                {
                    e.Handled = true;
                    MessageBox.Show($"{colName} must be numeric only!", "Validation Error");
                }
            }

            if (colName == "NationalNo")
            {
                if (!char.IsControl(e.KeyChar) && !char.IsLetterOrDigit(e.KeyChar))
                {
                    e.Handled = true;
                    MessageBox.Show($"{colName} must contain only Letters and Numbers!", "Validation Error");
                }
            }

            if (colName == "FirstName" || colName == "SecondName" || colName == "ThirdName" || colName == "LastName")
            {
                if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar))
                {

                    e.Handled = true;
                    MessageBox.Show($"{colName} must contain only Letters", "Validation Error");
                }

            }

            if (colName == "Email")
            {
                if (!char.IsControl(e.KeyChar) && !char.IsLetterOrDigit(e.KeyChar) && e.KeyChar != '@' && e.KeyChar != '.' && e.KeyChar != '_' && e.KeyChar != '-')
                {
                    e.Handled = true;
                    MessageBox.Show($"{colName} can only contain letters, numbers, @, dot, underscore (_) or dash (-).", "Validation Error");
                } 
            }

            if (colName == "DateOfBirth")
            {
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '-' && e.KeyChar != '/')
                {
                    e.Handled = true;
                    MessageBox.Show("Please enter a valid date (e.g. 2000-12-31).", "Validation Error");
                }
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            AddEditPepole from = new AddEditPepole(-1);
            from.ShowDialog();
            RefreshPepole();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {

            int personID = Convert.ToInt32(dgv.CurrentRow.Cells[0].Value);

            if (MessageBox.Show(
              "Are you sure you want to delete contact " + personID.ToString(),
              " Confirm Delete",
               MessageBoxButtons.YesNo,
               MessageBoxIcon.Question) == DialogResult.Yes)
            {


                if (clsPepole.DeletePerson(personID))
                {

                    if (clsPepole.isExistsInUser(personID))
                    {

                        MessageBox.Show("Can not delete this person because it is Linked to a user account", "Delete Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }
                    else
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
            form.Show();
            RefreshPepole();
        }

        private void addNewPersonToolStripMenuItem_Click(object sender, EventArgs e)
        {

            AddEditPepole form = new AddEditPepole(-1);
            form.ShowDialog();
            RefreshPepole();

        }

        private void PanalHeader_Paint(object sender, PaintEventArgs e)
        {

        }

        private void showDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowDetailPerson Form = new ShowDetailPerson((int)dgv.CurrentRow.Cells[0].Value);
            Form.ShowDialog();
            RefreshPepole();
            

        }
    }
}