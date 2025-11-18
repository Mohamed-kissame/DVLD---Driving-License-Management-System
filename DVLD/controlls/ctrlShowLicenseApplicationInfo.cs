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

namespace DVLD.controlls
{
    public partial class ctrlShowLicenseApplicationInfo : UserControl
    {

        private int _LAppID = -1;
        private int _PersonID = -1;
        private ClsLicenseDrivingLocal _LicenseDrivingLocal;

        public ctrlShowLicenseApplicationInfo()
        {
            InitializeComponent();

            if (DesignMode)
                return;
        }

        private void RestData()
        {

            lblLAppID.Text = "[???]";
            lblAppliedLicense.Text = "[???]";
            lblPassedTest.Text = "[???]";
            lblID.Text = "[???]";
            lblStatus.Text = "[???]";
            lblFees.Text = "[???]";
            LblType.Text = "[???]";
            lblApplicant.Text = "[???]";
            lblDate.Text = "[???/???/???]";
            lblStatusDate.Text = "[???/???/???]";
            lblCreatedBy.Text = "[???]";

        }

        private void FillData()
        {

            lblLAppID.Text = _LicenseDrivingLocal.LocalDrivingLicenseApplicationID.ToString();
            lblAppliedLicense.Text = _LicenseDrivingLocal.LicenseClassInfo.ClassName.ToString();
            lblPassedTest.Text = "3/3";
            lblID.Text = _LicenseDrivingLocal._ApplicationID.ToString();
            lblStatus.Text = _LicenseDrivingLocal.StatusText.ToString();
            lblFees.Text = _LicenseDrivingLocal.PaidFees.ToString();
            LblType.Text = _LicenseDrivingLocal.ApplicationTypeInfo.ApplicationName; 
            lblApplicant.Text = _LicenseDrivingLocal.PersonFullName.ToString(); 
            lblDate.Text = clsFormat.DateToShort(_LicenseDrivingLocal.ApplicationDate);
            lblStatusDate.Text = clsFormat.DateToShort(_LicenseDrivingLocal.LastStatusDate);
            lblCreatedBy.Text = _LicenseDrivingLocal.UserInfo._UserName.ToString();
            



        }

        public void LoadLicenseApplicationInfo(int LAppID)
        {

            this._LAppID = LAppID;

            _LicenseDrivingLocal = ClsLicenseDrivingLocal.FindByLocalDrivingAppLicenseID(LAppID);

            if(_LicenseDrivingLocal != null)
            {
                this._PersonID = _LicenseDrivingLocal._PersonID;

                FillData();


            }
            else
            {

                RestData();

                MessageBox.Show("No Application with Id " + LAppID.ToString(), "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }



        }

        private void ctrlShowLicenseApplicationInfo_Load(object sender, EventArgs e)  {  }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

            ShowDetailPerson detailPerson = new ShowDetailPerson(_PersonID);
            detailPerson.Show();


        }
    }
}
