using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BussniesDVLDLayer;
using DVLD.Classes;


namespace DVLD
{
    public partial class Login : Form
    {

        public Login()
        {
            InitializeComponent();

            this.StartPosition = FormStartPosition.CenterScreen;
            this.AutoScaleMode = AutoScaleMode.None;
            this.AutoSize = false;

        }

        private void Login_Load(object sender, EventArgs e)
        {
           


            string UserName = "" ,  Password = "";

            if(LoginInfo.GetStoredInfo(ref UserName , ref Password))
            {

                textBox1.Text = UserName;
                textBox2.Text = Password;
                checkBox1.Checked = true;

            }
            else
            {
                checkBox1.Checked = false;
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            textBox2.PasswordChar = '*';
            textBox2.UseSystemPasswordChar = true;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {

            clsUsers _Users = clsUsers.FindByUsernameAndPassword(textBox1.Text.Trim() , textBox2.Text.Trim());

         

            if(_Users != null)
            {

                if (checkBox1.Checked)
                {
                    LoginInfo.RememberUserNameAndPassword(textBox1.Text.Trim(), textBox2.Text.Trim());
                }
                else
                {

                    LoginInfo.RememberUserNameAndPassword("", "");

                }

                if (!_Users._IsActive)
                {
                    MessageBox.Show("Your Account is Deactivated Please Contact Your Admin", "Login Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                LoginInfo.SetUser(_Users);

                this.Hide();
                main Form = new main(this, _Users._UserName);
                Form.Show();

            }
            else
            {
                textBox1.Focus();
                MessageBox.Show("Invalid UserName/Password", "Login Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            

        }
           

        private void btnShowPassword_MouseEnter_1(object sender, EventArgs e)
        {
            textBox2.UseSystemPasswordChar = false;
            textBox2.PasswordChar = '\0';
        }

        private void btnShowPassword_MouseMove(object sender, MouseEventArgs e)
        {
            textBox2.PasswordChar = '*';
            textBox2.UseSystemPasswordChar = true;
        }

        private void btnShowPassword_MouseLeave(object sender, EventArgs e)
        {
            textBox2.PasswordChar = '*';
            textBox2.UseSystemPasswordChar = true;
        }
    }
}
