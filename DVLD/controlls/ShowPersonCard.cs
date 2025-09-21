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
using DVLD.Pepole;

namespace DVLD.controlls
{
    public partial class ShowPersonCard : UserControl
    {

       public int _PersonID;
        clsPepole _Pepole;

        public ShowPersonCard()
        {
            InitializeComponent();

            
        }

        private void FillData()
        {


            lblID.Text = _PersonID.ToString();
            lblName.Text = _Pepole.FullName();
            lblNationalNo.Text = _Pepole._NationaleNumber;
            lblGendor.Text = _Pepole._Gender ? "Female" : "Male";
            lblEmail.Text = _Pepole._Email;
            lblAddress.Text = _Pepole._Addrress;
            lblDate.Text = _Pepole._BirthOfDate.ToShortDateString();
            lblPhone.Text = _Pepole._Phone;
            //lblCountry.Text = clsCountry.Find(_Pepole._NationaleNumber).CountryName.ToString();
            //pBPicture.Image = Image.FromFile(_Pepole._ImagePath);

        }

        public void LoadData(int PersonID)
        {
            _PersonID = PersonID;


            _Pepole = new clsPepole();

            _Pepole = clsPepole.Find(_PersonID);

            if(_Pepole != null)
            {

                FillData();

            }
            

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void llbEdit_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

            AddEditPepole Form = new AddEditPepole(_PersonID);
            Form.ShowDialog();


        }

       

        private void ShowPersonCard_Load(object sender, EventArgs e)
        {
            LoadData(_PersonID);

        }
    }
}
