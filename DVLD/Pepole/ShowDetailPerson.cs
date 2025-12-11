using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD.Pepole
{
    public partial class ShowDetailPerson : Form
    {


        public ShowDetailPerson(int Person)
        {
            InitializeComponent();

            showPersonCard1.LoadPersonData(Person);

        }

        private void ShowDetailPerson_Load(object sender, EventArgs e) { }

        private void guna2TileButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
