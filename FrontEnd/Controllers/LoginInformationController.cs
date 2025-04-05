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

namespace FrontEnd.Controllers
{
    public partial class LoginInformationController : UserControl
    {
        public LoginInformationController()
        {
            InitializeComponent();
        }

        public int UserID { get; set; }
        private void _ShowUserInfo()
        {
                clsUser User = clsUser.Find(UserID);
            if (User != null)
            {
                lblUserID.Text=User.UserID.ToString();
                lblUserName.Text = User.UserName;
                lblIsActive.Text = User.IsActive.ToString();

            }
        }
        public void ShowUserInfo()
        {
            _ShowUserInfo();
        }

        private void LoginInformationController_Load(object sender, EventArgs e)
        {
            _ShowUserInfo();
        }
    }
}
