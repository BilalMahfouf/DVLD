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

namespace FrontEnd.Forms.TestTypes_Forms
{
    public partial class frmEditTestTypes : Form
    {
        public frmEditTestTypes(int TestTypeID)
        {
            InitializeComponent();
            _TestType=clsTestType.Find(TestTypeID);
        }
        clsTestType _TestType;
        private void AllTextBox_TextChanged(object sender, EventArgs e)
        {
            clsUIHelper.SetErrorProvider((Control)sender, errorProvider1);
        }
        private void _Refresh()
        {
            lblID.Text= _TestType.TestTypeID.ToString();
            tbTitle.Text= _TestType.TestTypeTitle.ToString();
            rtbDescription.Text= _TestType.TestTypeDescription.ToString();
            int Fees = (int)_TestType.TestTypeFees;
            mtbFees.Text = Fees.ToString();
        }
        private void frmEditTestTypes_Load(object sender, EventArgs e)
        {
            _Refresh();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private bool _Save()
        {
            if(tbTitle.Text==string.Empty)
            {
                return false;
            }
            _TestType.TestTypeTitle = tbTitle.Text;
            if(rtbDescription.Text==string.Empty)
            {
                return false;
            }
            _TestType.TestTypeDescription = rtbDescription.Text;
            if(mtbFees.Text==string.Empty)
            {
                return false;
            }
            _TestType.TestTypeFees=Convert.ToDecimal(mtbFees.Text);

            return _TestType.Save();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if(_Save())
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
    }
}
