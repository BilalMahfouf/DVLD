using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BusinessLogicLayer;

namespace FrontEnd.Forms.User_Forms
{
    public partial class frmManageUsers : Form
    {
        public frmManageUsers()
        {
            InitializeComponent();
        }

        private DataTable _Users;

        private void _Refresh()
        {
            _Users = clsUser.GetAllUsersWithFullName();
            dgvUsers.DataSource = _Users;
            lblRecords.Text = "#Records: " + _Users.Rows.Count.ToString();
        }
        private void dgvUesrsDesigned()
        {
            dgvUsers.Columns["UserID"].Width = 120;
            dgvUsers.Columns["PersonID"].Width = 120;
            dgvUsers.Columns["FullName"].Width = 300;
            dgvUsers.Columns["UserName"].Width = 300;
            dgvUsers.Columns["IsActive"].Width = 120;


        }


        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void _cbFilterByDesigned()
        {
            cbFilterBy.SelectedIndex = 0;
        }
        private void frmManageUsers_Load(object sender, EventArgs e)
        {
            _Refresh();
            dgvUesrsDesigned();
            _cbFilterByDesigned();
        }
        private bool _SearchForUserBy(string SearchOption, string SearchOn)
        {
            if (string.IsNullOrEmpty(SearchOption) || string.IsNullOrEmpty(SearchOn))
                return false;

            SearchOption = SearchOption.Replace(" ", "");


            DataTable temp = _Users.Clone();
            temp.Rows.Clear();

            foreach (DataRow row in _Users.Rows)
            {
                if (row[SearchOption].ToString() == SearchOn)
                {
                    temp.ImportRow(row); // Copy only the found row

                }
            }

            if (temp.Rows.Count > 0)
            {
                dgvUsers.DataSource = temp; // Show the rows that has been found 
                return true;
            }
            else return false;
        }
        private void cbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbFilterBy.SelectedIndex == 5)
            {
                cbIsActiveFilter.Visible = true;
                cbIsActiveFilter.SelectedIndex = 0;
                mtbSearch.Visible = false;
                return;
            }
            if (cbFilterBy.SelectedIndex > 0)
            {

                mtbSearch.Visible = true;
                if (cbFilterBy.SelectedItem != null && cbFilterBy.SelectedItem.ToString() == "Person ID"
                    || cbFilterBy.SelectedItem != null && cbFilterBy.SelectedItem.ToString() == "User ID")
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

            if (!_SearchForUserBy(cbFilterBy.Text, mtbSearch.Text))
            {
                DataTable temp = _Users.Clone();
                temp.Rows.Clear();
                dgvUsers.DataSource = temp;
            }
        }

        private void _IsActiveFilter(bool IsActive)
        {
            // don't touch this func its logic is complicated but it work
            DataTable newUsers = new DataTable();

            newUsers = _Users.Clone(); // this insure that newUsers has the same
                                       // schema as _Users so that  newUsers.ImportRow(row) work
        
            foreach (DataRow row in _Users.Rows)
            {
                if (IsActive && (bool)row["IsActive"])
                {
                    newUsers.ImportRow(row);
                }
                else if (!IsActive)
                {
                    if (!(bool)row["IsActive"])
                    {
                        newUsers.ImportRow(row);
                    }
                }

            }
               dgvUsers.DataSource = newUsers;
            

        }
        private void _IsActiveSearch(string Choice)
        {
            switch (Choice)
            {
                case "All":
                    _Refresh();
                    break;
                case "Yes":
                    _IsActiveFilter(true);
                    break;
                case "No":
                    _IsActiveFilter(false);
                    break;


            }

        }
        private void cbIsActiveFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            _IsActiveSearch(cbIsActiveFilter.Text);
        }

        private void tsmSendEmail_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This feature is not implementing yet",
              "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void tsmPhoneCall_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This feature is not implementing yet",
              "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void tsmDelete_Click(object sender, EventArgs e)
        {
            if (dgvUsers.CurrentRow != null)
            {
                int UserID = Convert.ToInt32(dgvUsers.CurrentRow.Cells["UserID"].Value);
                if (clsUser.DeleteUser(UserID))
                {
                    MessageBox.Show("User deleted successfully",
              "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Can't delete this user because it " +
                        "has relation in the system",
             "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            _Refresh();
        }

        private void tsmShowDetails_Click(object sender, EventArgs e)
        {
            if(dgvUsers.CurrentRow != null)
            {
                int UserID = Convert.ToInt32(dgvUsers.CurrentRow.Cells["UserID"].Value);

                frmUserInformation frmUserInformation = new frmUserInformation(UserID);
                frmUserInformation.ShowDialog();
            }
            
        }

        private void tsmChangePassword_Click(object sender, EventArgs e)
        {
            if (dgvUsers.CurrentRow != null)
            {
                int UserID = Convert.ToInt32(dgvUsers.CurrentRow.Cells["UserID"].Value);

                frmChangePassword frmChangePassword = new frmChangePassword(UserID);
                frmChangePassword.ShowDialog();
              

            }
        }

        private void btnAddNewUser_Click(object sender, EventArgs e)
        {

            frmAddOrEditUser frmAddNewUser = new frmAddOrEditUser(-1);
            frmAddNewUser.ShowDialog();
            _Refresh();

        }

        private void tsmAddNewUser_Click(object sender, EventArgs e)
        {

            frmAddOrEditUser frmAddNewUser = new frmAddOrEditUser(-1);
            frmAddNewUser.ShowDialog();
            _Refresh();

        }

        private void tsmEdit_Click(object sender, EventArgs e)
        {
            int UserID = Convert.ToInt32(dgvUsers.CurrentRow.Cells["UserID"].Value);
            frmAddOrEditUser frmEditUser = new frmAddOrEditUser(UserID);
            frmEditUser.ShowDialog();
            _Refresh();
        }
    }
}
