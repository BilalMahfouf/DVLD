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
using FrontEnd.Classes;

namespace FrontEnd.Forms.User_Forms
{
    public partial class frmChangePassword : Form
    {
        public frmChangePassword(int UserID)
        {
            InitializeComponent();
            this._UserID = UserID;
        }
        private int _UserID;
        private clsUser _User;
       
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmChangePassword_Load(object sender, EventArgs e)
        {
            _User= clsUser.Find(_UserID);
            personInfoController1.PersonID = _User.PersonID;
            loginInformationController1.UserID = this._UserID;
            personInfoController1.ShowPersonInfo();
            loginInformationController1.ShowUserInfo();
        }

        private void AllTextBox_TextChanged(object sender, EventArgs e)
        {
            clsUIHelper.SetErrorProvider((Control)sender, errorProvider1);
        }

        private bool _ValidateCurrentPassword()
        {
            return _User.Password == clsUIHelper.ComputeHash(tbCurrentPassword.Text);
        }
        private bool _SaveChangePassword()
        {
            if (_ValidateCurrentPassword() && tbNewPassword.Text.Equals(tbConfirmPassword.Text)) 
            {
                _User.Password = clsUIHelper.ComputeHash(tbNewPassword.Text);
                return _User.Save();
            }
            return false;
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if(_SaveChangePassword())
            {
                MessageBox.Show("Password Updated successfully","",
                    MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                this.Close();
            }
            else
            {

                MessageBox.Show("This operation can't be done,please confirm your information", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
