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

namespace DVLD.TestTypes
{
    public partial class EditTestTypes : Form
    {

        private int _TestID = 0;
        private clsTestType Test;

        public EditTestTypes(int TestID)
        {
            InitializeComponent();

            _TestID = TestID;
        }

        private void LoadData()
        {

            Test = clsTestType.Find((clsTestType.enTestType)_TestID);

            if(Test != null)
            {

                lblID.Text = _TestID.ToString();
                txtTitle.Text = Test.TestName;
                TxtDescription.Text = Test.TestDescription;
                txtFees.Text = Test.TestFees.ToString();

            }
        }



        private void EditTestTypes_Load(object sender, EventArgs e)
        {

            LoadData();
        }

      
        private void BtnSAve_Click_1(object sender, EventArgs e)
        {

            Test.TestName = txtTitle.Text;
            Test.TestDescription = TxtDescription.Text;
            Test.TestFees = Convert.ToSingle(txtFees.Text);

            if (Test.Update())
            {

                MessageBox.Show("Data Save Successfully", "Update Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Data Failed To Save", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
