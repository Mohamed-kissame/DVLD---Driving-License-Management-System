using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Deployment.Internal;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BussniesDVLDLayer;

namespace DVLD.ApplicationTypes
{
    public partial class EditApplication : Form
    {

        private int _ApplicationID = 0;
        private clsApplicationType Application;

        public EditApplication(int ApplicationId)
        {
            InitializeComponent();

            _ApplicationID = ApplicationId;
        }

      
        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void LoadData()
        {

            Application = clsApplicationType.Find(_ApplicationID);

            if (Application != null)
            {

                lblID.Text = _ApplicationID.ToString();
                txtApplicationTitle.Text = Application.ApplicationName;
                txtFees.Text = Application.ApplicationFees.ToString();
            }
        }


        

        private void btnSave_Click(object sender, EventArgs e)
        {

            Application.ApplicationName = txtApplicationTitle.Text;
            Application.ApplicationFees = Convert.ToDecimal(txtFees.Text);

            if (Application.Update())
            {

                MessageBox.Show("Data Save Successfully", "Update Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {

                MessageBox.Show("Data Save Failed", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void EditApplication_Load_1(object sender, EventArgs e)
        {

            LoadData();
        }
    }
}
