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
using DVLD.Pepole;
using Newtonsoft.Json.Linq;


namespace DVLD.controlls
{
    public partial class FillDataGrade : UserControl
    {
        public FillDataGrade()
        {
            InitializeComponent();
            this.AutoScaleMode = AutoScaleMode.Font;

        }

        //private Pepole.AddEditPepole AddPepole = new Pepole.AddEditPepole();

        private DataTable _dt;
        private DataView _dv;

        private void StyleDataGridView(DataGridView dgv)
        {
            // General
            dataGridView2.Dock = DockStyle.Bottom;
            dataGridView2.BorderStyle = BorderStyle.None;

            dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView2.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView2.MultiSelect = false;
            dataGridView2.ReadOnly = true; // You edit via dialog/context menu
            dataGridView2.AllowUserToAddRows = false;
            dataGridView2.RowHeadersVisible = false;

            // Header
            dataGridView2.EnableHeadersVisualStyles = false;
            dataGridView2.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(0, 122, 204);
            dataGridView2.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dataGridView2.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            dataGridView2.ColumnHeadersHeight = 36;

            // Rows
            dataGridView2.DefaultCellStyle.Font = new Font("Segoe UI", 10);
            dataGridView2.DefaultCellStyle.SelectionBackColor = Color.FromArgb(229, 241, 251);
            dataGridView2.DefaultCellStyle.SelectionForeColor = Color.Black;
            dataGridView2.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(245, 245, 245);

            // Reduce flicker (enable DoubleBuffered via reflection – DGV’s property is protected)
            typeof(DataGridView).GetProperty("DoubleBuffered",
                System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic);
        }

        private void UpdateRecordCount()
        {
            int count = (_dv != null) ? _dv.Count : (_dt?.Rows.Count ?? 0);
            lblCpountRecord.Text = $"# Records:    {count}";
            lblCpountRecord.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
        }


        public void RefreshPepole()
        {

            _dt = clsPepole.GetAllPepole();

            _dv = new DataView(_dt);

          

            dataGridView2.DataSource = _dt;

            UpdateRecordCount();

            StyleDataGridView(dataGridView2);

            comboBox1.Items.Clear();

            comboBox1.Items.Add("None");

            foreach (DataColumn col in _dt.Columns)
            {

                comboBox1.Items.Add(col.ColumnName);
            }

            if (comboBox1.Items.Count > 0)
                comboBox1.SelectedIndex = 0;

        }

        private void FillDataGrade_Load(object sender, EventArgs e)
        {
            RefreshPepole();
           
        }

        private void Search()
        {

            if (_dv?.Table != null)
            {
                _dv.Table.CaseSensitive = false;
            }


            if (comboBox1.SelectedIndex > 0 && !string.IsNullOrEmpty(textBox1.Text))
            {

                string colName = comboBox1.SelectedItem.ToString();
                string VAlue = textBox1.Text.Trim().Replace("'", "''");

              
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


            dataGridView2.DataSource = _dv;


            UpdateRecordCount();


        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (comboBox1.SelectedIndex == 0)
            {
                textBox1.Visible = false;
            }
            else
            {
                textBox1.Visible = true;
            }

            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;

            

            Search();
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
          
            

        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
          
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

            textBox1.CharacterCasing = CharacterCasing.Normal;

            //if (string.IsNullOrEmpty(textBox1.Text))
            //{

            //    dataGridView2.Refresh();

            //}
           
            Search();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (comboBox1.SelectedItem == null) return;

            string colName = comboBox1.SelectedItem.ToString();

            
            if (colName == "PersonID" || colName == "Phone")
            {
                
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                {
                    e.Handled = true; 
                    MessageBox.Show($"{colName} must be numeric only!");
                }
            }

            if(colName == "NationalNo")
            {
                if(!char.IsControl(e.KeyChar) && !char.IsLetterOrDigit(e.KeyChar))
                {
                    e.Handled = true;
                    MessageBox.Show($"{colName} must contain only Letters and Numbers!" , "Validation Error" );
                }
            }

            if (colName == "FirstName" || colName == "SecondName" || colName == "ThirdName" || colName == "LastName")
            {
                if(!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar))
                {

                    e.Handled = true;
                    MessageBox.Show($"{colName} must contain only Letters", "Validation Error");
                }

            }

            if(colName == "Email")
            {
                if(!char.IsControl(e.KeyChar) && !char.IsLetterOrDigit(e.KeyChar) && e.KeyChar != '@' && e.KeyChar != '.' && e.KeyChar != '_' && e.KeyChar != '-')
                {
                    e.Handled = true;
                    MessageBox.Show($"{colName} can only contain letters, numbers, @, dot, underscore (_) or dash (-)." , "Validation Error");
                }
            }

            if(colName == "DateOfBirth")
            {
                if(!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '-' && e.KeyChar != '/')
                {
                    e.Handled = true;
                    MessageBox.Show("Please enter a valid date (e.g. 2000-12-31).", "Validation Error");
                }
            }
        }

        private void bttnADD_Click(object sender, EventArgs e)
        {

            //AddPepole = new Pepole.AddEditPepole();
            //AddPepole.ShowDialog();
            //RefreshPepole();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            bttnADD.TextImageRelation = TextImageRelation.ImageBeforeText;
            Form form = this.FindForm();
            form.Close();

        }
    }
}
