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

namespace FrontEnd.Forms
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {

        }

        private void _Clear()
        {
            tbPassword.Text= string.Empty;
            tbUserName.Text= string.Empty;
        }
         public void Clear()
        {
            _Clear();
        }
        private void btnLogin_Click(object sender, EventArgs e)
        {
            clsUser User = clsUser.Find(tbUserName.Text, tbPassword.Text);
            if (User != null)
            {
                clsUserInfo.UserName = User.UserName;
                clsUserInfo.UserID = User.UserID;

                frmMain frmMain = new frmMain();
                frmMain.ShowDialog();
            }
            else
            {
                MessageBox.Show("Login info are wrong", "Error"
                    , MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
