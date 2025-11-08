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
using DVLD.Classes;
using DVLD.Pepole;
using DVLD.Users;

namespace DVLD.controlls
{
    public partial class ShowUserCard : UserControl
    {

        clsUsers user;

        public clsUsers SelectUserInfo
        {
            get { return user; }
        }

        public ShowUserCard()
        {
            InitializeComponent();
        }

        private void FillData()
        {

            lblID.Text = user._UserID.ToString();
            lblusername.Text = user._UserName;
            if (user._IsActive)
            {
                lblIsActive.Text = "Yes";
            }
            else
            {
                lblIsActive.Text = "No";
            }

        }

        private void RestData()
        {

            lblID.Text = "???";
            lblusername.Text = "???";
            lblIsActive.Text = "???";
        }

        public void LoadUserData(int UserID)
        {


            user = clsUsers.Find(UserID);

            if (user != null)
            {
                showPersonCard1.LoadPersonData(user._PersonID);
                FillData();
                
            }
            else
            {
                RestData();
                MessageBox.Show("No User with UserID = " + UserID.ToString(), "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            FillData();
           

        }

        public void LoadUserData(string username)
        {



            user = clsUsers.Find(username);

            if (user != null)
            {
                showPersonCard1.LoadPersonData(user._PersonID);
                FillData();

            }
            else
            {
                RestData();
                MessageBox.Show("No User with username = " + username.ToString(), "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            FillData();

        }

        private void ShowUserCard_Load(object sender, EventArgs e)
        {

        }
    }
}
