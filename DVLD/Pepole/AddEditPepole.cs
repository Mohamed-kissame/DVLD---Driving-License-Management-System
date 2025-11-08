using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Diagnostics.Contracts;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BussniesDVLDLayer;
using DVLD.Classes;
using Microsoft.Win32;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace DVLD.Pepole
{
    public partial class AddEditPepole : Form
    {

        public delegate void DatabackEvent(object obj, int PersonID);

        public event DatabackEvent DataBack;

       public enum enMode { AddNew = 0, Update = 1 };

        private enMode _Mode;


        int _PeronID;
        clsPeople _Pepole;

        public AddEditPepole()
        {
            InitializeComponent();

            _Mode = enMode.AddNew;

        }


        public AddEditPepole(int PersonID)
        {
            InitializeComponent();

            _Mode = enMode.Update;

            _PeronID = PersonID;

        }

        private void Settings()
        {
            

            this.txtFirstName.TabIndex = 0;
            this.txtSecondName.TabIndex = 1;
            this.txtThirdName.TabIndex = 2;

            llbRemove.Visible = false;

            rdMale.Checked = true;

        }

        private void FillCountry()
        {
            DataTable dt = clsCountry.GeAllCountry();


            foreach (DataRow row in dt.Rows)
            {

                cbCountry.Items.Add(row["CountryName"]);
          
            }

            cbCountry.SelectedIndex = 118;
        }

        private void _RestDefaultValue()
        {

            FillCountry();

            if (_Mode == enMode.AddNew)
            {

                lblTitle.Text = "Add New Person";
                _Pepole = new clsPeople();
            }
            else
            {

                lblTitle.Text = "Update Person";

            }

            llbRemove.Visible = (pbPicture.ImageLocation != null);

            dateTimePicker1.Format = DateTimePickerFormat.Short;

            DateTime currentDate = DateTime.Now;


            DateTime eighteenYearsAgo = currentDate.AddYears(-18);


            dateTimePicker1.Value = eighteenYearsAgo;

            txtFirstName.Text = String.Empty ;
            txtSecondName.Text = String.Empty;
            txtThirdName.Text = String.Empty;
            txtLastNAme.Text = String.Empty;
            rdMale.Checked = true;
            txtPhone.Text = String.Empty;
            txtEmail.Text = String.Empty;
            txtAddress.Text = String.Empty;

        }

        private void LoadData()
        {

            _Pepole = clsPeople.Find(_PeronID);

            if (_Pepole == null)
            {

                MessageBox.Show("This Form will be closed because No Person with Id " + _PeronID + " is exist");
                this.Close();
                return;
            }
            else
            {

                lblTitle.Text = "Update Person";
                lblID.Text = _Pepole._PersonID.ToString();
                txtNationalNo.Text = _Pepole._NationaleNumber;
                txtFirstName.Text = _Pepole._FirstNAme;
                txtSecondName.Text = _Pepole._SecondName;
                txtThirdName.Text = _Pepole._ThierdName;
                txtLastNAme.Text = _Pepole._LastName;
                dateTimePicker1.Value = _Pepole._BirthOfDate;
                if (_Pepole._Gender == "Female")  
                    rBFemale.Checked = true;
                else
                    rdMale.Checked = true;

                txtAddress.Text = _Pepole._Addrress;
                txtPhone.Text = _Pepole._Phone;
                txtEmail.Text = _Pepole._Email;

                cbCountry.SelectedIndex = cbCountry.FindString(clsCountry.Find(_Pepole._Nationality).CountryName);

                if (_Pepole._ImagePath != "")
                {
                    pbPicture.ImageLocation = _Pepole._ImagePath;

                }

               
                llbRemove.Visible = (_Pepole._ImagePath != "");

            }
        }

        private bool HandelImage()
        {
            if(_Pepole._ImagePath != pbPicture.ImageLocation)
            {
               if(_Pepole._ImagePath != "")
                {
                    try
                    {
                        File.Delete(_Pepole._ImagePath);
                    }
                    catch (IOException)
                    {
                        
                    }
                }
                if (pbPicture.ImageLocation != null)
                {
                    //then we copy the new image to the image folder after we rename it
                    string SourceImageFile = pbPicture.ImageLocation.ToString();

                    if (clsUtilty.CopyImageToFolderManageImage(ref SourceImageFile))
                    {
                        pbPicture.ImageLocation = SourceImageFile;
                        return true;
                    }
                    else
                    {
                        MessageBox.Show("Error Copying Image File", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                }
            }

            return true;
        }

        private void AddEditPepole_Load(object sender, EventArgs e)
        {

            _RestDefaultValue();

            if(_Mode == enMode.Update)
            LoadData();
        }

        private void rBFemale_CheckedChanged(object sender, EventArgs e)
        {
            if (rBFemale.Checked == true)
            {
                rdMale.Checked = false;
                pbPicture.Image = Properties.Resources.woman;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void rdMale_CheckedChanged(object sender, EventArgs e)
        {

            if (rdMale.Checked == true) { 
                pbPicture.Image = Properties.Resources.man1;
                rBFemale.Checked = false;
             }
        }

        private void llbRemove_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            pbPicture.Image = null;
            pbPicture.ImageLocation = null;
            llbRemove.Visible = false;

        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            if (!HandelImage())
                return;

            int CountryID = clsCountry.Find(cbCountry.Text).ID;

            _Pepole._NationaleNumber = txtNationalNo.Text.Trim().ToString();
            _Pepole._FirstNAme = txtFirstName.Text.Trim().ToString();
            _Pepole._SecondName = string.IsNullOrEmpty(txtSecondName.Text) ? "" : txtSecondName.Text.Trim().ToString();
            _Pepole._ThierdName = string.IsNullOrEmpty(txtThirdName.Text) ? "" : txtThirdName.Text.Trim().ToString();
            _Pepole._LastName = txtLastNAme.Text.Trim().ToString();
            _Pepole._BirthOfDate = dateTimePicker1.Value;
            _Pepole._Gender = Convert.ToString(rBFemale.Checked);
            _Pepole._Addrress = txtAddress.Text.Trim().ToString();
            _Pepole._Email = txtEmail.Text.ToString();
            _Pepole._Phone = txtPhone.Text.Trim().ToString();
            _Pepole._Nationality = CountryID;
            if (pbPicture.ImageLocation != null)
            {

                _Pepole._ImagePath = pbPicture.ImageLocation;
            }

            else
            {
                _Pepole._ImagePath = "";
            }



            if (_Pepole.Save())
            {

                
                lblID.Text = _Pepole._PersonID.ToString();
                _Mode = enMode.Update;
                lblTitle.Text = "Update Person";
                MessageBox.Show("Data Saved Successfully");

                DataBack?.Invoke(this, _Pepole._PersonID);
            }
            else
            {
                MessageBox.Show("Error in Saving Data");
            }

        }

        private void llbImage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

            openFileDialog1.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp";
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {

                string selectedFilePath = openFileDialog1.FileName;
                pbPicture.Load(selectedFilePath);
                llbRemove.Visible = true;

            }
        }
        private void txtEmail_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void txtEmail_Validating(object sender, CancelEventArgs e)
        {

            if (txtEmail.Text.Trim() == "")
                return;

            if (!clsValidation.ValidateEmail(txtEmail.Text))
            {

                e.Cancel = true;

                errorProvider1.SetError(txtEmail, "This is Required");

            }
            else
            {
                errorProvider1.SetError(txtEmail, null);
            }

        }

        private void txtNationalNo_Validating(object sender, CancelEventArgs e)
        {

            if (string.IsNullOrEmpty(txtNationalNo.Text.Trim()))
            {

                e.Cancel = true;

                errorProvider1.SetError(txtNationalNo, "This is Required");

            }
            else
            {

                errorProvider1.SetError(txtNationalNo, null);
            }

            if(txtNationalNo.Text.Trim() != _Pepole._NationaleNumber && clsPeople.isExistsByNationalNo(txtNationalNo.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtNationalNo, "National Number is used for another person!");

            }
            else
            {

                errorProvider1.SetError(txtNationalNo, null);
            }

        }
    }
}
