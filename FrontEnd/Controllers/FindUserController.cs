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
using FrontEnd.Forms;

namespace FrontEnd.Controllers
{
    public partial class FindPersonController : UserControl
    {
        public FindPersonController()
        {
            InitializeComponent();
        }
        private int _PersonID;
        private void FindUserController_Load(object sender, EventArgs e)
        {
            cbFilterBy.SelectedIndex = 0;
        }

        private void cbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cbFilterBy.SelectedIndex == 1)
            {
                mtbSearch.Mask = "0000000000";
            }
            else
            {
                mtbSearch.Mask = "";
            }
        }

        private void btnAddNewPerson_Click(object sender, EventArgs e)
        {
            frmAddOrEditPerson frmAddNewPerson = new frmAddOrEditPerson(-1);
            frmAddNewPerson.ShowDialog();
        }

        public delegate void SendPersonIDEventHandler(object sender, int PersonID);

        public event SendPersonIDEventHandler SendPersonID;

        private bool _CheckPersonExist()
        {
            if(cbFilterBy.SelectedIndex==1)
            {
                _PersonID = Convert.ToInt32(mtbSearch.Text);
                return clsPerson.isExist(_PersonID);
            }
            else
            {
                clsPerson P = clsPerson.Find(mtbSearch.Text);
                if(P == null)
                {
                    _PersonID = -1;
                    return false;
                }
                else
                {
                    _PersonID=P.PersonID;
                }
                    return _PersonID > 0;
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if(_CheckPersonExist())
            {
                SendPersonID?.Invoke(this, _PersonID);
            }
            else
            {
                SendPersonID?.Invoke(this, -1);
            }
        }
    }
}
