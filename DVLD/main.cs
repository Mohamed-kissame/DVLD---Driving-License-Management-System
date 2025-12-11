using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DVLD.Application.RenewLicense;
using DVLD.Application.ReplaceForDamagedOrLost;
using DVLD.Applications.Release_Detained_Licenses;
using DVLD.ApplicationTypes;
using DVLD.Classes;
using DVLD.controlls;
using DVLD.Driver;
using DVLD.InternationalLicense;
using DVLD.Licenses.DetainLicense;
using DVLD.Licenses.ReleaseLicense;
using DVLD.LocalLicenseDriver;
using DVLD.Pepole;
using DVLD.TestTypes;
using DVLD.Users;

namespace DVLD
{
    public partial class main : Form
    {

        private string _username;
        private DateTime _loginTime;
        private Login _LoginForm;

        public main(Login LoginForm ,string UserName)
        {
            InitializeComponent();

            _username = UserName;
            _loginTime = DateTime.Now;
            _LoginForm = LoginForm;

            SetupModernUI();
        }

        private void SetupModernUI()
        {
            // ===== MenuStrip Modern Look =====
            menuStrip1.Renderer = new ToolStripProfessionalRenderer(new ModernColors());
            menuStrip1.BackColor = Color.FromArgb(44, 62, 80);
            menuStrip1.ForeColor = Color.White;
            menuStrip1.Font = new Font("Segoe UI", 11, FontStyle.Bold);

            // ===== Status Bar =====
            StatusStrip status = new StatusStrip();
            status.BackColor = Color.FromArgb(52, 73, 94);
            status.ForeColor = Color.White;
            status.Font = new Font("Segoe UI", 9, FontStyle.Regular);

            // User info
            ToolStripStatusLabel lblUser = new ToolStripStatusLabel($"Logged in as: {_username}");
            ToolStripStatusLabel spacer = new ToolStripStatusLabel() { Spring = true };
            ToolStripStatusLabel lblDate = new ToolStripStatusLabel($"Login time: {_loginTime:dd/MM/yyyy HH:mm}");

            status.Items.Add(lblUser);
            status.Items.Add(spacer);
            status.Items.Add(lblDate);

            this.Controls.Add(status);

            // ===== Form Style =====
            this.IsMdiContainer = true;
            this.BackColor = Color.FromArgb(236, 240, 241);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.WindowState = FormWindowState.Maximized;
        }

        public class ModernMenuRenderer : ToolStripProfessionalRenderer
        {
            public ModernMenuRenderer() : base(new ModernColors()) { }

            protected override void OnRenderMenuItemBackground(ToolStripItemRenderEventArgs e)
            {
                if (e.Item.Selected)
                {
                    e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(52, 152, 219)), e.Item.ContentRectangle);
                }
                else
                {
                    base.OnRenderMenuItemBackground(e);
                }
            }
        }

        public class ModernColors : ProfessionalColorTable
        {
            public override Color MenuItemSelected => Color.FromArgb(52, 152, 219);
            public override Color MenuItemBorder => Color.FromArgb(41, 128, 185);
            public override Color MenuBorder => Color.FromArgb(236, 240, 241);
            public override Color ToolStripDropDownBackground => Color.White;
            public override Color ImageMarginGradientBegin => Color.White;
            public override Color ImageMarginGradientMiddle => Color.White;
            public override Color ImageMarginGradientEnd => Color.White;
        }
    


        private void accountSeToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void pepoleToolStripMenuItem_Click(object sender, EventArgs e)
        {

            Pepole.Pepole pepole = new DVLD.Pepole.Pepole();
            
            pepole.ShowDialog();
        }

        private void main_Load(object sender, EventArgs e)
        {

        }

        private void signToolStripMenuItem_Click(object sender, EventArgs e)
        {

            this.Close();
            _LoginForm.Show();
        }

        private void usersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Users.Users user = new Users.Users();
           
            user.ShowDialog();
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

      

        private void currentUserInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowUserInfo show = new ShowUserInfo(LoginInfo.SelectUserInfo._UserID);
            show.Show();
        }

        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChangePassword change = new ChangePassword(LoginInfo.SelectUserInfo._UserID);
            change.Show();
        }

        private void drivingToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void manageApplicationToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Manage_Application_Types Application = new Manage_Application_Types();
            Application.Show();
        }

        private void manageTestTypesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TestTypes.TestTypes Test = new TestTypes.TestTypes();
            Test.Show();
        }

        private void manageApplicationToolStripMenuItem_Click(object sender, EventArgs e)
        {

         

        }

        private void replaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ReplaceForDamagedLicense replaceFor = new ReplaceForDamagedLicense();
            replaceFor.ShowDialog();
        }

        private void localDriToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LocalLicenseDriver.LocalDrivingLicenseApp Local = new LocalLicenseDriver.LocalDrivingLicenseApp();
            Local.Show();
        }

        private void localToolStripMenuItem_Click(object sender, EventArgs e)
        {

            AddEditLocalDrivingLicense addEditLocalDrivingLicense = new AddEditLocalDrivingLicense();
            addEditLocalDrivingLicense.ShowDialog();

        }

        private void driversToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DriverView Driver = new DriverView();
            Driver.Show();
        }

        private void retakeTestToolStripMenuItem_Click(object sender, EventArgs e)
        {

            LocalLicenseDriver.LocalDrivingLicenseApp Local = new LocalLicenseDriver.LocalDrivingLicenseApp();
            Local.Show();

        }

        private void renewDrivingLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RenewLicense renew = new RenewLicense();
            renew.ShowDialog();
        }

        private void internationalDrivingLicenseApplicationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InternationalLicenseApp internationalLicense = new InternationalLicenseApp();
            internationalLicense.ShowDialog();

        }

        private void internationaleLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NewInternationalLicenseAPP newInternational = new NewInternationalLicenseAPP();
            newInternational.ShowDialog();
        }

        private void manageDetainLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ListDetainedLicense detainedLicense = new ListDetainedLicense();
            detainedLicense.ShowDialog();
        }

        private void detainLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Detained detainedLicense = new Detained();
            detainedLicense.ShowDialog();
        }

        private void releaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ReleaseLicense release = new ReleaseLicense();
            release.ShowDialog();
        }

        private void relaseLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ReleaseLicense release = new ReleaseLicense();
            release.ShowDialog();
        }
    }
}
