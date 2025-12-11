using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD.controlls {
    public partial class ShowUserInfo : Form
    {
        public ShowUserInfo(int userid)
        {
            InitializeComponent();
           


            showUserCard1.LoadUserData(userid);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void showUserCard1_Load(object sender, EventArgs e)
        {

        }

        private void BtnClose_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
