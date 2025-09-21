using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Contracts;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BussniesDVLDLayer;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace DVLD.Pepole
{
    public partial class AddEditPepole : Form
    {


       public enum enMode { AddNew = 0, Update = 1 };

        private enMode _Mode;


        int _PeronID;
        clsPepole _Pepole;


        public AddEditPepole(int PersonID)
        {
            InitializeComponent();


            _PeronID = PersonID;

            rdMale.Checked = true;

            if (_PeronID == -1)
            
                _Mode = enMode.AddNew;
            else
            
                _Mode = enMode.Update;
            
        }

        private void FillCountry()
        {
            DataTable dt = clsCountry.GeAllCountry();


            foreach (DataRow row in dt.Rows)
            {

                cbCountry.Items.Add(row["CountryName"]);
            }
        }

        private void LoadData()
        {

            FillCountry();
            cbCountry.SelectedIndex = 0;

            if (_Mode == enMode.AddNew)
            {

                label1.Text = "Add New Person";
                _Pepole = new clsPepole();
                return;
            }

            _Pepole = clsPepole.Find(_PeronID);

            if (_Pepole == null)
            {

                MessageBox.Show("This Form will be closed because No Person with Id " + _PeronID + " is exist");
                this.Close();
                return;
            }
            else
            {

                label1.Text = "Update Person";
                lblID.Text = _Pepole._PersonID.ToString();
                mtbNationlaNNo.Text = _Pepole._NationaleNumber;
                txtFirstName.Text = _Pepole._FirstNAme;
                txtSecondName.Text = _Pepole._SecondName;
                txtThirdName.Text = _Pepole._ThierdName;
                txtLastNAme.Text = _Pepole._LastName;
                dateTimePicker1.Value = _Pepole._BirthOfDate;
                if (_Pepole._Gender)  // true
                    rBFemale.Checked = true;
                else
                    rdMale.Checked = true;

                txtAddress.Text = _Pepole._Addrress;
                txtPhone.Text = _Pepole._Phone;
                txtEmail.Text = _Pepole._Email;


                var country = clsCountry.Find(_Pepole._NationaleNumber);

                if (country != null)
                {

                    cbCountry.SelectedIndex = cbCountry.FindString(country.CountryName);
                    
                }
                else
                {

                    cbCountry.SelectedIndex = -1;
                }

                if (_Pepole._ImagePath != "")
                {

                    pictureBox1.Load(_Pepole._ImagePath);
                }

                llbRemove.Visible = (_Pepole._ImagePath != "");

            }
        }
        private void AddEditPepole_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void rBFemale_CheckedChanged(object sender, EventArgs e)
        {
            if (rBFemale.Checked == true)
            {
                rdMale.Checked = false;
                pbGender.Image = Properties.Resources.woman;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void rdMale_CheckedChanged(object sender, EventArgs e)
        {

            if (rdMale.Checked == true) { 
                pbGender.Image = Properties.Resources.man1;
                rBFemale.Checked = false;
             }
        }

        private void llbRemove_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

           

        }

        private void mtbNationlaNNo_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            if (txtFirstName.Text == "")
            {

                errorProvider1.SetError(txtFirstName, "First Name is Required");
                return;
            }
            else
            {
                errorProvider1.Clear();
            }


            if (txtSecondName.Text == "")
            {

                errorProvider1.SetError(txtSecondName, "Second Name is Required");
                return;
            }
            else
            {
                errorProvider1.Clear();
            }


            if (txtThirdName.Text == "")
            {

                errorProvider1.SetError(txtThirdName, "Third Name is Required");
                return;
            }
            else
            {
                errorProvider1.Clear();
            }

            if (txtLastNAme.Text == "")
            {

                errorProvider1.SetError(txtLastNAme, "Last Name is Required");
                return;
            }
            else
            {
                errorProvider1.Clear();
            }

            if (!clsPepole.isExistsByNationalNo(mtbNationlaNNo.Text))
            {
                // Prevent duplicates in Add OR Update
                if (_Mode == enMode.AddNew || (_Mode == enMode.Update && _Pepole._NationaleNumber != mtbNationlaNNo.Text))
                {
                    errorProvider1.SetError(mtbNationlaNNo, "This National No already exists for another person.");
                    return;
                }
            }
            else
            {
                errorProvider1.Clear();
            }
           

            if (string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                errorProvider1.SetError(txtEmail, "Email is required.");
                return;
            }
            else if (!txtEmail.Text.Contains("@") || !txtEmail.Text.Contains("."))
            {
                errorProvider1.SetError(txtEmail, "Please enter a valid email address.");
            }
            else
            {
                errorProvider1.Clear();
            }

            if (string.IsNullOrEmpty(txtPhone.Text))
            {

                errorProvider1.SetError(txtPhone, "Phone number is required");
                return;
               
            }
            else
            {
                errorProvider1.Clear();
            }

            if(cbCountry.SelectedIndex == -1)
            {
                errorProvider1.SetError(cbCountry, "Please select a Country");
                return;
            }
            else
            {

                errorProvider1.Clear();

            }

            if (string.IsNullOrWhiteSpace(txtAddress.Text))
            {

                errorProvider1.SetError(txtAddress, "Address is required");
                return;
            }
            else
            {

                errorProvider1.Clear();
            }

          

            

           int CountryID = clsCountry.Find(cbCountry.Text).ID;

            _Pepole._NationaleNumber = mtbNationlaNNo.Text;
            _Pepole._FirstNAme = txtFirstName.Text;
            _Pepole._SecondName = txtSecondName.Text;
            _Pepole._ThierdName = txtThirdName.Text;
            _Pepole._LastName = txtLastNAme.Text;
            _Pepole._BirthOfDate = dateTimePicker1.Value;
            _Pepole._Gender = rBFemale.Checked;
            _Pepole._Addrress = txtAddress.Text;
            _Pepole._Email = txtEmail.Text;
            _Pepole._Phone = txtPhone.Text;
            _Pepole._Nationality = CountryID;
            _Pepole._ImagePath = pbGender.ImageLocation ?? "";



            if (_Pepole.Save())
            {

                MessageBox.Show("Data Saved Successfully");


                _Mode = enMode.Update;
                lblID.Text = _Pepole._PersonID.ToString();
            }
            else
            {
                MessageBox.Show("Error in Saving Data");
            }

        }
          
        

        private void cbCountry_SelectedIndexChanged(object sender, EventArgs e)
        {

           

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            
        }
    }
}
