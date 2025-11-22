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
using DVLD.Properties;

namespace DVLD.Tests.Controlls
{
    public partial class ctrlScheduleTest : UserControl
    {

        private clsTestType.enTestType _TestTypeID = clsTestType.enTestType.VisionTest;


        public clsTestType.enTestType TestType
        {

            get { return _TestTypeID; } 

            set { _TestTypeID = value;


                switch (_TestTypeID)
                {

                    case clsTestType.enTestType.VisionTest:
                        gpTestName.Text = "Vision Test";
                        picChangeTestType.Image = Resources.Vision_512;
                        break;

                    case clsTestType.enTestType.WrittenTest:
                        gpTestName.Text = "Writte Test";
                        picChangeTestType.Image = Resources.Written_Test_512;
                        break;

                    case clsTestType.enTestType.StreetTest:
                        gpTestName.Text = "Stret Test";
                        picChangeTestType.Image = Resources.Street_Test_32;
                        break;

                    default:
                        gpTestName.Text = "Vision Test";
                        picChangeTestType.Image = Resources.Vision_512;
                        break;

                }
            
            }
        }

        public ctrlScheduleTest()
        {
            InitializeComponent();
        }

        private void ctrlScheduleTest_Load(object sender, EventArgs e)
        {

        }
    }
}
