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

namespace DVLD.LocalLicenseDriver
{
    public partial class AddEditLocalDrivingLicense : Form 
    {
        
        public AddEditLocalDrivingLicense()
        {
            InitializeComponent();

            lblDate.Text = DateTime.Now.ToString("dd/MM/yyyy");
            lblFees.Text = 15.00.ToString();
            lblUser.Text = LoginInfo.SelectUserInfo._UserName;
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex < tabControl1.TabPages.Count - 1)
            {
                tabControl1.SelectedIndex++; 
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tabPage2_Click(object sender, EventArgs e)
        {
          
        }

        private void FillCountry()
        {
            DataTable dt = clsLicenseClass.GetAllLicenseClass();


            foreach (DataRow row in dt.Rows)
            {

                comboBox1.Items.Add(row["ClassName"]);

            }

            comboBox1.SelectedIndex = 0;
        }

        private void AddEditLocalDrivingLicense_Load(object sender, EventArgs e)
        {

            FillCountry();

        }
    }
}
