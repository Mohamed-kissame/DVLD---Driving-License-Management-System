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
using DVLD.Pepole;
using DVLD.Properties;

namespace DVLD.controlls
{
    public partial class ShowPersonCard : UserControl
    {

       private int _PersonID = -1;
       private clsPeople _Pepole;

        public int PersonID
        {
            get { return _PersonID; }

           
        }

        public clsPeople SelectedPersonInfo {

            get { return _Pepole; }

        }


        public ShowPersonCard()
        {
            InitializeComponent();

        }

        private void LoadImage()
        {

            if(_Pepole._Gender == "Female")
            {

                pBPicture.Image = Resources.woman;
               
            }
            else
            {
                pBPicture.Image = Resources.man;
            }

            string ImagePath = _Pepole._ImagePath;

            if (ImagePath != "")
                if (File.Exists(ImagePath))
                    pBPicture.ImageLocation = ImagePath;
                else
                    MessageBox.Show("Could not find this image: = " + ImagePath, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void FillData()
        {
            _PersonID = _Pepole._PersonID;
            lblID.Text = _PersonID.ToString();
            lblName.Text = _Pepole.FullName();
            lblNationalNo.Text = _Pepole._NationaleNumber;
            lblGendor.Text = _Pepole._Gender;
            lblEmail.Text = _Pepole._Email;
            lblAddress.Text = _Pepole._Addrress;
            lblDate.Text = _Pepole._BirthOfDate.ToShortDateString();
            lblPhone.Text = _Pepole._Phone;
            lblCountry.Text = clsCountry.Find(_Pepole._Nationality).CountryName.ToString();
            LoadImage();
          
        }

        public void LoadPersonData(int PersonID)
        {
           

            _Pepole = clsPeople.Find(PersonID);

            if (_Pepole != null)
            {
                FillData();
                llbEdit.Enabled = false;
            }
            else {
                RestData();
                MessageBox.Show("No Person with PersonID = " + PersonID.ToString(), "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
                FillData();
            llbEdit.Enabled = true;

        }

        public void LoadPersonData(string NationalNO)
        {


            _Pepole = clsPeople.Find(NationalNO);

            if (_Pepole != null)
            {
                FillData();
                llbEdit.Enabled = true;
            }
            else
            {
                RestData();
                MessageBox.Show("No Person with PersonID = " + NationalNO.ToString(), "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            FillData();
            llbEdit.Enabled = true;
        }

        public void RestData()
        {
            _PersonID = -1;
            llbEdit.Enabled = false;
            lblID.Text = "???";
            lblName.Text = "???";
            lblNationalNo.Text = "???";
            lblGendor.Text = "???";
            lblEmail.Text = "???";
            lblAddress.Text = "???";
            lblDate.Text = "???";
            lblPhone.Text = "???";
            lblCountry.Text = "???";
            pBPicture.ImageLocation = "";
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void llbEdit_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

            AddEditPepole Form = new AddEditPepole(_PersonID);
            Form.ShowDialog();
            LoadPersonData(_PersonID);
        }

        private void ShowPersonCard_Load(object sender, EventArgs e)
        {
           

        }
    }
}
