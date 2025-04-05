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
    public partial class frmAddOrEditUser : Form
    {
        public frmAddOrEditUser(int UserID)
        {
            InitializeComponent();
            findUserController1.SendPersonID += frmAddOrEditUser_SendPersonID;
            _UserID = UserID;
        }

        private int _PersonID;
        private int _UserID;



        private void btnClose_Click(object sender, EventArgs e)
        {

        }
        private void _Refresh()
        {
            clsUser User = clsUser.Find(_UserID);
            personInfoController1.PersonID = User.PersonID;
            personInfoController1.ShowPersonInfo();
            pUserInfo.Enabled = true;
            lblUserID.Text = _UserID.ToString();
            tbUserName.Text = User.UserName;
        }

        private void _SetMode()
        {
            if (_UserID>0)
            {
                lblMode.Text = "Update User";
                _Refresh();
            }
            else
            {
                lblMode.Text = "Add New User";
                lblUserID.Text = "???";

            }
        }
        public void SetMode()
        {
            _SetMode();
        }
        private void frmAddOrEditUser_Load(object sender, EventArgs e)
        {
            _SetMode();
        }

        private void btnClose_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmAddOrEditUser_SendPersonID(object sender,int PersonID)
        {
            if(PersonID > 0)
            {
                _PersonID=PersonID;
                personInfoController1.PersonID = PersonID;
                personInfoController1.ShowPersonInfo();
                btnNext.Enabled = true;
            }
            else
            {
                MessageBox.Show("Person does not exist","Error"
                    ,MessageBoxButtons.OK,MessageBoxIcon.Error);
                personInfoController1.PersonID = -1;
                personInfoController1.ShowPersonInfo();
                btnNext.Enabled = false;
                pUserInfo.Enabled = false;
            }
            
        }

        private bool _SaveUser()
        {
            if(pUserInfo.Enabled)
            {
                clsUser User;
                if(_UserID > 0)
                {
                    User = clsUser.Find(_UserID);
                }
                else
                {
                    User = new clsUser();
                }

                if (tbUserName.Text == string.Empty)
                {
                    return false;
                }
                User.UserName = tbUserName.Text;
                if((!tbPassword.Text.Equals(tbConfirmPassword.Text)) && tbPassword.Text==string.Empty)
                {
                    return false;
                }
                User.Password = tbPassword.Text;
                if(_UserID<0)
                {
                    User.PersonID = _PersonID;
                }
                if (cbIsActive.Checked)
                {
                    User.IsActive = true;
                }
                else
                {
                    User.IsActive = false;
                }
                if(User.Save())
                {
                    _UserID = User.UserID;
                    return true;
                }

            }
            return false;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if(_SaveUser())
            {
                MessageBox.Show("Data saved successfully", "", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                _SetMode();
            }
            else
            {
                MessageBox.Show("This operation can't be done", "Error"
                    , MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if(!clsUser.IsExist(_PersonID))
            {
                tabControl1.SelectedTab = tabPage2;
                pUserInfo.Enabled = true;
            }
            else
            {
                MessageBox.Show(@"This person already connected to a user
                    ,please use another person", "Error", MessageBoxButtons.OK
                    , MessageBoxIcon.Error);
                pUserInfo.Enabled = false;

            }
        }
    }
}
