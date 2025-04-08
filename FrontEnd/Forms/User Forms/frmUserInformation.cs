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

namespace FrontEnd.Forms.User_Forms
{
    public partial class frmUserInformation : Form
    {
        public frmUserInformation(int UserID)
        {
            InitializeComponent();
          
            this._UserID = UserID;
        }
        private int _PersonID;
        private int _UserID;

        private void frmUserInformation_Load(object sender, EventArgs e)
        {
            clsUser User= clsUser.Find(_UserID);
            if (User != null)
            {
                personInfoController1.PersonID = User.PersonID;
                loginInformationController1.UserID = this._UserID;
                personInfoController1.ShowPersonInfo();
                loginInformationController1.ShowUserInfo();
            }
            
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
