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
        private void _Refresh()
        {
            if (this._PersonID > 0)
            {
                addOrEditPersonControllers1.PersonID = this._PersonID;
                lblMode.Text = "Update Person";
                lblPersonID.Text = _PersonID.ToString();
                addOrEditPersonControllers1.PersonID=this._PersonID;
                addOrEditPersonControllers1.LoadPersonInfo();
            }
            else
            {
                lblMode.Text = "Add New Person";
            }
        }
        private void frmAddOrEditPerson_Load(object sender, EventArgs e)
        {
            _Refresh();
        }

        private void addOrEditPersonControllers1_Load(object sender, EventArgs e)
        {

        }

        private void addOrEditPersonControllers1_OnCloseRequested()
        {
            this.Close();
            
        }

        private void addOrEditPersonControllers1_OnSaveRequested(int obj)
        {
            this._PersonID = obj;
            _Refresh();

        }

        private void _RemoveImage(string ImagePath)
        {
            addOrEditPersonControllers1.RemoveImage(ImagePath);
        }
        public void RemoveImage(string ImagePath)
        {
            _RemoveImage(ImagePath);
        }

    }
}
