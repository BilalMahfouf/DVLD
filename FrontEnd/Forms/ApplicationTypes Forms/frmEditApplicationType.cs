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

namespace FrontEnd.Forms.ApplicationTypes_Forms
{
    public partial class frmEditApplicationType : Form
    {
        public frmEditApplicationType(int ApplicationTypeID)
        {
            InitializeComponent();
            _ApplicationType = clsApplicationType.Find(ApplicationTypeID);
        }
        
        clsApplicationType _ApplicationType;
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        bool _Save()
        {
            if (_ApplicationType != null)
            {
                if(tbTitle.Text ==string.Empty)
                {
                    return false;
                }
                _ApplicationType.ApplicationTitle= tbTitle.Text;
                if (mtbFees.Text == string.Empty)
                {
                    return false;
                }
                _ApplicationType.ApplicationFee = Convert.ToDecimal(mtbFees.Text);
                return _ApplicationType.Save();
            }
            return false;
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (_Save())
            {
                MessageBox.Show("Data saved successfully", "", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                  this.Close();
            }
            else
            {
                MessageBox.Show("This operation can't be done", "Error"
                    , MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AllTextBox_TextChanged(object sender, EventArgs e)
        {
            clsUIHelper.SetErrorProvider((Control)sender, errorProvider1);
        }

         private void _Refresh()
        {
            if(_ApplicationType!=null)
            {
                lblID.Text = _ApplicationType.ApplicationTypeID.ToString();
                tbTitle.Text = _ApplicationType.ApplicationTitle;
                int Fees = (int)_ApplicationType.ApplicationFee;
                mtbFees.Text = Fees.ToString();
            }
            else
            {
                this.Close();
            }
           

        }
        private void frmEditApplicationType_Load(object sender, EventArgs e)
        {
            _Refresh();
        }
    }
}
