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

namespace DVLD.Licenses
{
    public partial class ShowPersonLicensesHistory : Form
    {

        int _PersonID = -1;
        ClsDriver _Driver;

        public ShowPersonLicensesHistory()
        {
            InitializeComponent();
            
        }

        public ShowPersonLicensesHistory(int personID)
        {
            InitializeComponent();
            _PersonID = personID;
        }

        private void ShowPersonLicensesHistory_Load(object sender, EventArgs e)
        {
            if (_PersonID != -1)
            {
                showPersonCardByFilter1.LoadPersonByID(_PersonID);
                showPersonCardByFilter1.FilterEnable = false;
                ctrlDriverLicenses1.LoadInfoByPersonID(_PersonID);
            }

            else
            {
                showPersonCardByFilter1.Enabled = true;
                showPersonCardByFilter1.FilterFocus();

            }


        }

        private void guna2TileButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
