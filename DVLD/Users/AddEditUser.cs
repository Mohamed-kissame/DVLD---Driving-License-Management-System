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
using DVLD.Pepole;

namespace DVLD.Users
{
    public partial class AddEditUser : Form
    {

       private enum enMode { AddNew = 0 , Update = 1};

        private enMode _Mode = enMode.AddNew;

        int _UserID = -1;

        clsUsers user;

        public AddEditUser()
        {
            InitializeComponent();

            this.AutoScaleMode = AutoScaleMode.None;
            this.AutoSize = false;

            _Mode = enMode.AddNew;

        }

        public AddEditUser(int UserID)
        {
            InitializeComponent();

            _Mode = enMode.Update;

            _UserID = UserID;


        }

        private void RestValue()
        {
            if (_Mode == enMode.AddNew)
            {
                lblTitle.Text = "Add New User";
                user = new clsUsers();
               
            }

            if(_Mode == enMode.Update)
            {

                lblTitle.Text = "Update User";
            }

            txtUserName.Text = string.Empty;
            txtPassword.Text = string.Empty;
            txtConfirm.Text = string.Empty;
        }

        private void LoadData()
        {

            user = clsUsers.Find(_UserID);

            if(user == null)
            {

                MessageBox.Show("This Form will be closed because No User with Id " + _UserID + " is exist");
                this.Close();
                return;
            }

            lblTitle.Text = "Update Person";
            showPersonCardByFilter1.LoadPersonByID(user._PersonID);
            lblID.Text = user._UserID.ToString();
            txtUserName.Text = user._UserName;
            txtPassword.Text = user._Password;
            txtConfirm.Text = user._Password;
            if (user._IsActive)
                checkIsActive.Checked = true;
            else
                checkIsActive.Checked = false;

        }



        private void AddEditUser_Load(object sender, EventArgs e)
        {
            
                RestValue();

            if (_Mode == enMode.Update)
                LoadData();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnNext_Click_1(object sender, EventArgs e)
        {

            if(_Mode == enMode.AddNew)
                if (clsPeople.isExistsInUser(showPersonCardByFilter1._PersonID))
                    MessageBox.Show("This Person Is Already a user choose another One", "Select Another Person", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                    tabControl1.SelectedIndex = 1;

            if (_Mode == enMode.Update)
                tabControl1.SelectedIndex = 1;
        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {
            txtPassword.UseSystemPasswordChar = true;
            txtPassword.PasswordChar = '*';
        }

        private void txtConfirm_TextChanged(object sender, EventArgs e)
        {
            txtConfirm.UseSystemPasswordChar = true;
            txtConfirm.PasswordChar = '*';
        }

        private void checkIsActive_CheckedChanged(object sender, EventArgs e)
        {
          
        }


        private void txtUserName_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtUserName.Text.Trim()))
            {

                e.Cancel = true;

                errorProvider1.SetError(txtUserName, "This is Required");

            }
            else
            {

                errorProvider1.SetError(txtUserName, null);
            }
        }

        private void txtPassword_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtPassword.Text.Trim()))
            {



                errorProvider1.SetError(txtPassword, "This is Required");

            }
            else
            {

                errorProvider1.SetError(txtPassword, null);
            }
        }

        private void txtConfirm_Validating(object sender, CancelEventArgs e)
        {

            if (string.IsNullOrEmpty(txtConfirm.Text.Trim()))
            {



                errorProvider1.SetError(txtConfirm, "This is Required");

            }
            else
            {

                errorProvider1.SetError(txtConfirm, null);
            }

            if(txtConfirm.Text != txtPassword.Text)
            {

                e.Cancel = true;

                errorProvider1.SetError(txtConfirm, "This is must match the password");

            }

            else
            {
                errorProvider1.SetError(txtConfirm, null);
            }
        }

        private void txtPassword_TextChanged_1(object sender, EventArgs e)
        {
            txtPassword.UseSystemPasswordChar = true;
            txtPassword.PasswordChar = '*';
        }

        private void txtConfirm_TextChanged_1(object sender, EventArgs e)
        {
            txtConfirm.UseSystemPasswordChar = true;
            txtConfirm.PasswordChar = '*';
        }

        private void guna2TileButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnSave_Click_1(object sender, EventArgs e)
        {
            user._PersonID = showPersonCardByFilter1._PersonID;
            user._UserName = txtUserName.Text.Trim();
            user._Password = txtConfirm.Text.Trim();
            user._IsActive = checkIsActive.Checked;


            if (user.Save())
            {
                lblID.Text = user._UserID.ToString();
                _Mode = enMode.Update;
                lblTitle.Text = "Update User";
                MessageBox.Show("Data Saved Successfully");

            }
            else
            {
                MessageBox.Show("Error in Saving Data");
            }
        }
    }
}
