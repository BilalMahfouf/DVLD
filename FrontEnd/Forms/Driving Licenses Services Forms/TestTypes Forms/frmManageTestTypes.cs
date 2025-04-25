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

namespace FrontEnd.Forms.TestTypes_Forms
{
    public partial class frmManageTestTypes : Form
    {
        public frmManageTestTypes()
        {
            InitializeComponent();
        }

        private void _Refresh()
        {
            dgvTestTypes.DataSource = clsTestType.GetAllTestTypes();
            lblRecords.Text= "#Records: "+dgvTestTypes.Rows.Count.ToString(); 
        }

        private void _SetDesigned()
        {
            dgvTestTypes.Columns[0].Width = 100;
            dgvTestTypes.Columns[1].Width = 200;
            dgvTestTypes.Columns[2].Width = 420;
            dgvTestTypes.Columns[3].Width = 107;

            dgvTestTypes.Font = new Font("Segoe UI", 10, FontStyle.Regular);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmManageTestTypes_Load(object sender, EventArgs e)
        {
            _Refresh();
            _SetDesigned();
        }

        private void tsmEdit_Click(object sender, EventArgs e)
        {
            int ID = Convert.ToInt32(dgvTestTypes.CurrentRow.Cells[0].Value);
            frmEditTestTypes frm = new frmEditTestTypes(ID);
            frm.ShowDialog();
            _Refresh();
        }
    }
}
