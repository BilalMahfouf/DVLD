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
    public partial class frmAddOrEditPerson : Form
    {
        private int _PersonID;
        public frmAddOrEditPerson(int PersonID)
        {
            InitializeComponent();
            this._PersonID = PersonID;
            


           
        }

        private void frmAddOrEditPerson_Load(object sender, EventArgs e)
        {
            if(this._PersonID>0)
            {
                addOrEditPersonControllers1.PersonID= this._PersonID;
                lblMode.Text = "Update Person";
            }
            else
            {
                lblMode.Text = "Add New Person";
            }
        }

        private void addOrEditPersonControllers1_Load(object sender, EventArgs e)
        {

        }

        private void addOrEditPersonControllers1_OnCloseRequested()
        {
            this.Close();
            
        }
    }
}
