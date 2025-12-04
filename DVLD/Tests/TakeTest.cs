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
using DVLD.Tests.Controlls;

namespace DVLD.Tests
{
    public partial class TakeTest : Form
    {

        private int _AppointmentID;
        private clsTestType.enTestType _TestTypeID;

        private int _TestID = -1;
        private ClsTests _Test;

        public TakeTest(int AppointmentID, clsTestType.enTestType testType)
        {
            InitializeComponent();
            _AppointmentID = AppointmentID;
            _TestTypeID = testType;
        }

        private void rdbFail_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void TakeTest_Load(object sender, EventArgs e)
        {

            ctrlScheduledTest1.TestTypeID = _TestTypeID;
            ctrlScheduledTest1.LoadInfo(_AppointmentID);

            if (ctrlScheduledTest1.TestAppointmentID == -1)
                btnSave.Enabled = false;
            else
                btnSave.Enabled = true;

            int _TestID = ctrlScheduledTest1.TestID;

            if (_TestID != -1)
            {
                _Test = ClsTests.FindByTestID(_TestID);

                if (_Test._TestResult)
                    rdbPass.Checked = true;
                else
                    rdbFail.Checked = true;
                txtNotes.Text = _Test._Notes;

                lblError.Visible = true;
                rdbFail.Enabled = false;
                rdbPass.Enabled = false;
            }

            else
                _Test = new ClsTests();

        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            if (MessageBox.Show("Are you sure you want to save? After that you cannot change the Pass/Fail results after you save?.",
                        "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No
               )
            {
                return;
            }

            _Test._TestAppointmentID = _AppointmentID;
            _Test._TestResult = rdbPass.Checked;
            _Test._Notes = txtNotes.Text.Trim();
            _Test._CreatedByUserID = LoginInfo.SelectUserInfo._UserID;

            if (_Test.Save())
            {

                MessageBox.Show("Test result saved successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnSave.Enabled = false;
            }
            else
            {
                MessageBox.Show("Failed to save test result", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
