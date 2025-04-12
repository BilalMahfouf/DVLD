using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrontEnd.Forms.Driving_Licenses_Services_Forms
{
    public partial class frmNewDrivingLicense_Local : Form
    {
        public frmNewDrivingLicense_Local()
        {
            InitializeComponent();
            findUserController1.SendPersonID += frmNewDrivingLicense_SendPersonID;
        }

        private void frmNewDrivingLicense_Local_Load(object sender, EventArgs e)
        {

        }

        private void frmNewDrivingLicense_SendPersonID(object sender,int PersonID)
        {
            if(PersonID > 0)
            {
                personInfoController1.PersonID = PersonID;
                personInfoController1.ShowPersonInfo();
                btnNext.Enabled = true;
            }
        }

        private void personInfoController1_Load(object sender, EventArgs e)
        {

        }
    }
}
