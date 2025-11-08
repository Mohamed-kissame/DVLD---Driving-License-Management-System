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

namespace DVLD.Users
{
    public partial class ChangePassword : Form
    {
        public ChangePassword(int UserID)
        {
            InitializeComponent();

            showUserCard1.LoadUserData(UserID);
        }



        private void ChangePassword_Load(object sender, EventArgs e)
        {

        }

        private void txtCurrnetPassword_Validating(object sender, CancelEventArgs e)
        {

            if(txtCurrnetPassword.Text != showUserCard1.SelectUserInfo._Password)
            {

                errorProvider1.SetError(txtCurrnetPassword, "Must Enter the match Password");
            }
            else
            {

                errorProvider1.SetError(txtCurrnetPassword, null);
            }

        }

        private void txtNewPassword_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtNewPassword.Text))
            {
                errorProvider1.SetError(txtNewPassword, "Must Enter the New Password");

            }
            else
            {
                errorProvider1.SetError(txtNewPassword, null);
            }
        }

        private void textBox3_Validating(object sender, CancelEventArgs e)
        {
            if (txtConfirmPassword.Text != txtNewPassword.Text)
            {
                errorProvider1.SetError(txtNewPassword, "Must Enter the same Password");

            }
            else
            {
                errorProvider1.SetError(txtCurrnetPassword, null);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {

            if(clsUsers.ChangePassword(showUserCard1.SelectUserInfo._UserID , txtConfirmPassword.Text))
            {

                MessageBox.Show("Password Change Successfuly", "Change Password", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Password Change Faild", "Change Password", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
