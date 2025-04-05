using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrontEnd.Forms.User_Forms
{
    public partial class frmUserInformation : Form
    {
        public frmUserInformation(int UserID,int PerosnID)
        {
            InitializeComponent();
            this._PersonID = PerosnID;
            this._UserID = UserID;
        }
        private int _PersonID;
        private int _UserID;

        private void frmUserInformation_Load(object sender, EventArgs e)
        {
            personInfoController1.PersonID = this._PersonID;
            loginInformationController1.UserID = this._UserID;
            personInfoController1.ShowPersonInfo();
            loginInformationController1.ShowUserInfo();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
