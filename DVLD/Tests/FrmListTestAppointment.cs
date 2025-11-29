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

namespace DVLD.Tests
{
    public partial class FrmListTestAppointment : Form
    {

        private DataTable _dtLicenseTestAppointment;
        private int _LocalLicense = -1;
        private clsTestType.enTestType _TestTypeID = clsTestType.enTestType.VisionTest;


        public FrmListTestAppointment(int LocalLicenseDrivingAppID , clsTestType.enTestType TestTypeID)
        {
            InitializeComponent();

            _LocalLicense = LocalLicenseDrivingAppID;
            _TestTypeID = TestTypeID;
        }

        private void _StyleGrid()
        {
            //dgv.Dock = DockStyle.Bottom;
            dgv.BorderStyle = BorderStyle.FixedSingle;

            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv.MultiSelect = false;
            dgv.ReadOnly = true; // You edit via dialog/context menu
            dgv.AllowUserToAddRows = false;
            dgv.RowHeadersVisible = false;

            // Header
            dgv.EnableHeadersVisualStyles = false;
            dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(0, 122, 204);
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            dgv.ColumnHeadersHeight = 36;

            // Rows
            dgv.DefaultCellStyle.Font = new Font("Segoe UI", 10);
            dgv.DefaultCellStyle.SelectionBackColor = Color.FromArgb(229, 241, 251);
            dgv.DefaultCellStyle.SelectionForeColor = Color.Black;
            dgv.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(245, 245, 245);

            // Reduce flicker (enable DoubleBuffered via reflection – DGV’s property is protected)
            typeof(DataGridView).GetProperty("DoubleBuffered",
                System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic)
                ?.SetValue(dgv, true, null);
        }

        private void UpdateRecordCount(int count)
        {
            lblCount.Text = $"# Records:    {count}";
            lblCount.Font = new Font("Segoe UI", 10F, FontStyle.Bold);

        }

        private void _LoadTestTypeImageAndTitle()
        {
            switch (_TestTypeID)
            {

                case clsTestType.enTestType.VisionTest:
                    {
                        lblTitle.Text = "Vision Test Appointments";
                        this.Text = lblTitle.Text;
                        pictureBox1.Image = Resources.Vision_512;
                        break;
                    }

                case clsTestType.enTestType.WrittenTest:
                    {
                        lblTitle.Text = "Written Test Appointments";
                        this.Text = lblTitle.Text;
                        pictureBox1.Image = Resources.Written_Test_512;
                        break;
                    }
                case clsTestType.enTestType.StreetTest:
                    {
                        lblTitle.Text = "Street Test Appointments";
                        this.Text = lblTitle.Text;
                        pictureBox1.Image = Resources.Street_Test_32;
                        break;
                    }
            }
        }

        private void FrmListTestAppointment_Load(object sender, EventArgs e)
        {

            _StyleGrid();

            ctrlShowLicenseApplicationInfo1.LoadLicenseApplicationInfo(_LocalLicense);
            _dtLicenseTestAppointment = clsTestAppointment.GetAllTestAppointmentPerTestType(_LocalLicense, _TestTypeID);

            dgv.DataSource = _dtLicenseTestAppointment;

            UpdateRecordCount(dgv.Rows.Count);

            if(dgv.Rows.Count > 0)
            {

                dgv.Columns[0].HeaderText = "Appointment ID";


                dgv.Columns[1].HeaderText = "Appointment Date";


                dgv.Columns[2].HeaderText = "Paid Fees";


                dgv.Columns[3].HeaderText = "Is Locked";


            }


        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            ClsLicenseDrivingLocal licenseDrivingLocal = ClsLicenseDrivingLocal.FindByLocalDrivingAppLicenseID(_LocalLicense);

            if(licenseDrivingLocal.IsThereAnActiveScheduledTest(_TestTypeID))
            {

                MessageBox.Show("Person Already have an active appointment for this Test", "Not allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            ClsTests LastTest = licenseDrivingLocal.GetLastTestPerTestType(_TestTypeID);

            if (LastTest == null)
            {
                FrmScheduleTest frm1 = new FrmScheduleTest(_LocalLicense, _TestTypeID);
                frm1.ShowDialog();
                FrmListTestAppointment_Load(null, null);
                return;
            }

          
            if (LastTest._TestResult == true)
            {
                MessageBox.Show("This person already passed this test before, you can only retake faild test", "Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            FrmScheduleTest frm2 = new FrmScheduleTest
                (LastTest.TestAppointmentInfo._LocalDrivingLicenseApplicationID, _TestTypeID);
            frm2.ShowDialog();
            FrmListTestAppointment_Load(null, null);
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int TestAppointmentID = (int)dgv.CurrentRow.Cells[0].Value;


            FrmScheduleTest frm = new FrmScheduleTest(_LocalLicense, _TestTypeID, TestAppointmentID);
            frm.ShowDialog();
            FrmListTestAppointment_Load(null, null);
        }
    }
}
