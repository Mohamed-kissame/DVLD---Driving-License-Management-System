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

        private clsUsers _Users;

        public clsUsers SelectUserInfo
        {
            get { return _Users; }
        }

        private string _FileName = @"C:\Users\mkiss\OneDrive\Bureau\DVLD\DVLD\RememberMe.txt";

        public Login()
        {
            InitializeComponent();

            this.StartPosition = FormStartPosition.CenterScreen;

        }

        private string Encrypt(string Txt , int EncryptionShift = 2)
        {

            string Result = "";

            for (short i = 0; i < Txt.Length; i++)
            {

              Result += (char)((int)Txt[i] + EncryptionShift);

            }
            return Result;
        }

        private string Decrypt(string Txt , int DecryptionShift = 2)
        {

            string Result = "";

            for (int i = 0; i < Txt.Length; i++)
            {

                Result += (char)((int)Txt[i] - DecryptionShift);

            }
            return Result;

        }

        private void RememberMe(char Sepeartor = '/')
        {

            if (!checkBox1.Checked)
                return; 

            string username = textBox1.Text;
            string encryptedPassword = Encrypt(textBox2.Text);
            string DateTimeLogin = DateTime.Now.ToString();
            string rememberFlag = checkBox1.Checked.ToString();

            string newUserLine = username + Sepeartor + encryptedPassword + Sepeartor + rememberFlag + "\t\tLogin AT" + Sepeartor + DateTimeLogin;

           
            if (!File.Exists(_FileName))
                File.Create(_FileName).Close();

            
            string[] lines = File.ReadAllLines(_FileName);
            bool userFound = false;

            for (int i = 0; i < lines.Length; i++)
            {
                string[] parts = lines[i].Split(Sepeartor);
                if (parts.Length >= 2 && parts[0] == username)
                {
                    
                    lines[i] = newUserLine;
                    userFound = true;
                    break;
                }
            }

            
            if (!userFound)
            {
                lines = lines.Concat(new string[] { newUserLine }).ToArray();
            }

            
            File.WriteAllLines(_FileName, lines);

        }

        private void LoadRememberme()
        {

            string[] lines = File.ReadAllLines(_FileName);

            foreach (string line in lines)
            {
                string[] parts = line.Split('/');
                if (parts.Length == 3)
                {
                    string username = parts[0];
                    string encryptedPassword = parts[1];
                    bool rememberMe = bool.Parse(parts[2]);

                    if (rememberMe)
                    {
                        
                        textBox1.Text = username;
                        textBox2.Text = Decrypt(encryptedPassword);

                        
                        checkBox1.Checked = true;

                        break; 
                    }
                }
            }
        }

        private void Login_Load(object sender, EventArgs e)
        {

            LoadRememberme();

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

            _Users = new clsUsers();

            _Users = clsUsers.Find(textBox1.Text);

            if(_Users != null)
            {

                if (textBox1.Text == _Users._UserName && textBox2.Text == _Users._Password)
                {

                    if(_Users._IsActive == true)
                    {
                        LoginInfo.SetUser(_Users);
                        RememberMe();
                        this.Hide();
                        main Form = new main(this,_Users._UserName);
                        Form.Show();

                    }
                    else
                    {

                        MessageBox.Show("Your Account is Deactivated Please Contact Your Admin", "Login Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }
                }
                else
                {
                    MessageBox.Show("Invalid Password", "Login Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
               
            }
            else
            {

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
