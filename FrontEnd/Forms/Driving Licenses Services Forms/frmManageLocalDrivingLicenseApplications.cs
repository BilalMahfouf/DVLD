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

namespace FrontEnd.Forms.Driving_Licenses_Services_Forms
{
    public partial class frmManageLocalDrivingLicenseApplications : Form
    {
        public frmManageLocalDrivingLicenseApplications()
        {
            InitializeComponent();
        }
        private DataTable _ManageApplications;
        private void _Refresh()
        {
            _ManageApplications = clsManageLocalDrivingApplications.GetAllLocalDrivingApplications();
            dgvApplications.DataSource = _ManageApplications;
            lblRecords1.Text = "Records: " + dgvApplications.Rows.Count.ToString();


        }

        private void SetdgvDesigned()
        {
            dgvApplications.Columns[0].Width = 100;
            dgvApplications.Columns[0].Name = "L.D.L.AppID";
            dgvApplications.Columns[0].HeaderText = "L.D.L.AppID";

            dgvApplications.Columns[1].Width = 250;
            dgvApplications.Columns[1].Name = "Driving Class";
            dgvApplications.Columns[1].HeaderText = "Driving Class";

            dgvApplications.Columns[2].Width = 100;
            dgvApplications.Columns[3].Width = 250;
            dgvApplications.Columns[4].Width = 150;
            dgvApplications.Columns[5].Width = 100;
            dgvApplications.Columns[5].Name = "Passed Tests";
            dgvApplications.Columns[5].HeaderText = "Passed Tests";
            dgvApplications.Columns[6].Width = 105;

        }

        private void _SetcbFilterByDesigned()
        {
            cbfilterBy.SelectedIndex = 0;
        }


        private void frmManageLocalDrivingLicenseApplications_Load(object sender, EventArgs e)
        {
            _Refresh();
            SetdgvDesigned();
            _SetcbFilterByDesigned();
        }

        private string _ReplaceString(string str)
        {
            if (str == "L.D.L.AppID")
            {
                return "LocalDrivingLicenseApplicationID";
            }
            return str;
        }
        private bool Search(string SearchOption, string SearchOn)
        {
            DataTable SearchResult = _ManageApplications.Clone();
            SearchOption=_ReplaceString(SearchOption);
            foreach (DataRow Row in _ManageApplications.Rows)
            {
                if (Row[SearchOption].ToString().ToUpper() == SearchOn.ToUpper())
                {
                    SearchResult.ImportRow(Row);
                }
            }
            if(SearchResult.Rows.Count > 0)
            {
                dgvApplications.DataSource = SearchResult;
                return true;
            }
            return false;

        }

        private void cbfilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbfilterBy.SelectedIndex > 0)
            {
                mtbSearch.Visible = true;
                if (cbfilterBy.SelectedItem != null && cbfilterBy.SelectedItem.ToString() == "L.D.L.AppID")
                {
                    // Allow only 10-digit numeric input
                    mtbSearch.Mask = "0000000000";
                }
                else
                {
                    mtbSearch.Mask = string.Empty;
                }
            }

            else
            {
                mtbSearch.Visible = false;
                _Refresh();
            }
        }

        private void mtbSearch_TextChanged(object sender, EventArgs e)
        {
            if (!Search(cbfilterBy.Text, mtbSearch.Text))
            {
                DataTable temp = _ManageApplications.Clone();
                temp.Rows.Clear();
                dgvApplications.DataSource= temp;
            }
        }

        private void btnClose1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pbAddNewLocalDrivingApplication_Click(object sender, EventArgs e)
        {
            frmNewDrivingLicense_Local frm = new frmNewDrivingLicense_Local();
            frm.ShowDialog();
        }
    }
}
