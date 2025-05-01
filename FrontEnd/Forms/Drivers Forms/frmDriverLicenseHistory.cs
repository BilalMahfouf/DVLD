using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BusinessLogicLayer;
using FrontEnd.Controllers.LicenseControllers;

namespace FrontEnd.Forms.Drivers_Forms
{
    public partial class frmDriverLicenseHistory : Form
    {
        public frmDriverLicenseHistory(int driverID)
        {
            InitializeComponent();
            _DriverID = driverID;
        }
        private int _DriverID;
        private void _SetFormFullScreenVerticalOnly()
        {
            // this from chatgbt i don't know how it work
            this.Top = 0; // Move form to top of screen
            this.Height = Screen.PrimaryScreen.WorkingArea.Height; // Full vertical height

        }

        private void _LoadLicensesHistory()
        {
            driverLicensesHistoryController1.DriverID = _DriverID;
            driverLicensesHistoryController1.LoadLicensesHistory();

        }

        private void _LoadPersonInfo()
        {
            personInfoController1.PersonID = clsDriver.Find(_DriverID).PersonID;
            personInfoController1.ShowPersonInfo();
        }
        private void frmDriverLicenseHistory_Load(object sender, EventArgs e)
        {
            _SetFormFullScreenVerticalOnly();
            _LoadLicensesHistory();
            _LoadPersonInfo();
        }

        private void btnClose1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
