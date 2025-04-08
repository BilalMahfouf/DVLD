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

namespace FrontEnd.Forms.ApplicationTypes_Forms
{
    public partial class frmManageApplicationTypes : Form
    {
        public frmManageApplicationTypes()
        {
            InitializeComponent();
        }

        private DataTable _ApplicationsTypes;
        private void _Refresh()
        {
            _ApplicationsTypes= clsApplicationType.GetAllApplicationTypes();
            dgvApplicationTypes.DataSource = _ApplicationsTypes;
            lblRecords.Text = "#Records: " + dgvApplicationTypes.Rows.Count.ToString();


        }
        private void _SetdgvDesigned()
        {
            dgvApplicationTypes.Columns[0].Width = 150;
            dgvApplicationTypes.Columns[1].Width = 320;
            dgvApplicationTypes.Columns[2].Width = 175;
            dgvApplicationTypes.Columns[0].Name = "ID";
            dgvApplicationTypes.Columns[1].Name = "Title";
            dgvApplicationTypes.Columns[2].Name = "Fees";
            

        }

        private void frmManageApplicationTypes_Load(object sender, EventArgs e)
        {
            _Refresh();
            _SetdgvDesigned();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tsmEdit_Click(object sender, EventArgs e)
        {
            int ID = Convert.ToInt32(dgvApplicationTypes.CurrentRow.Cells[0].Value);
            if (ID >0 && dgvApplicationTypes.CurrentRow!=null)
            {
                frmEditApplicationType frmEditApplicationType = new frmEditApplicationType(ID);
                frmEditApplicationType.ShowDialog();
                _Refresh();
            }
            
        }
    }
}
