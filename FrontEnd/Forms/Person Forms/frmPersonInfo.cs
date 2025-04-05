using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FrontEnd.Controllers;

namespace FrontEnd.Forms
{
    public partial class frmPersonInfo : Form
    {
        private int _PersonID;
        public frmPersonInfo(int PersonID)
        {
            InitializeComponent();
            this._PersonID = PersonID;
            personInfoController1.PersonID = _PersonID;
        }
        
        private void frmPersonInfo_Load(object sender, EventArgs e)
        {
            
        }

        

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void personInfoController1_OnClicklinklblEditPerson_1()
        {
            
            
        }
    }
}
