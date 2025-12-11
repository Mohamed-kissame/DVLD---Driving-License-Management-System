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
using static DVLD.Pepole.AddEditPepole;

namespace DVLD.controlls
{
    public partial class showPersonCardByFilter : UserControl
    {

       
        private Pepole.AddEditPepole AddNew;
        private clsPeople Pepole;
        public int _PersonID;

        public showPersonCardByFilter()
        {
            InitializeComponent();

        }

        public void LoadPersonByID(int personID)
        {
            _PersonID = personID;
            txtSearch.Text = personID.ToString();
            gbFilter.Enabled = false;
            showPersonCard2.LoadPersonData(personID);
           
        }

        public void FilterFocus() { 
        
           
            txtSearch.Focus();

        }

        private bool _isEnabled = true;

        public bool FilterEnable
        {
            get { return _isEnabled; }

            set
            {

                _isEnabled = value;
                txtSearch.Enabled = _isEnabled;
            }
        }

        private void FindBy()
        {

            if (string.IsNullOrWhiteSpace(txtSearch.Text))
            {
                MessageBox.Show("Please enter a value to search.", "Validation Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            

            switch (comboBox2.Text)
            {
                case "PersonID":
                    int Id = Convert.ToInt32(txtSearch.Text);
                    showPersonCard2.LoadPersonData(Convert.ToInt32(txtSearch.Text));
                    _PersonID = Id;
                    break;

                case "NationalNo":
                    showPersonCard2.LoadPersonData(txtSearch.Text);

                    _PersonID = showPersonCard2.PersonID;
                    break;

                default:
                    return;
            }

          

        }

        private void showPersonCardByFilter_Load(object sender, EventArgs e)
        {
            comboBox2.SelectedIndex = 2;
        }

        private void showPersonCard1_Load(object sender, EventArgs e)
        {

        }

        private void BtnSearch_Click(object sender, EventArgs e)
        {
            FindBy();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (txtSearch.Visible)
            {
                txtSearch.Text = "";
                txtSearch.Focus();

            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
        }

        private void txtSearch_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (comboBox2.Text == "PersonID")
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void DatabackEvent(object obj , int PersonID)
        {

            comboBox2.SelectedIndex = 2;
            txtSearch.Text = PersonID.ToString();
            showPersonCard2.LoadPersonData(PersonID);
            _PersonID = PersonID;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {

            AddEditPepole Add = new AddEditPepole();
            Add.DataBack += DatabackEvent;

            Add.ShowDialog();


        }

        private void gbFilter_Enter(object sender, EventArgs e)
        {

        }
    }
}
