using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BusinessLogicLayer;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace FrontEnd.Forms
{
    public partial class frmManagePeople : Form
    {
        public frmManagePeople()
        {
            InitializeComponent();
            this.Width = 1400;
         
        }

        private DataTable _People;
    
        
        private void _Refresh()
        {
            _People= clsPerson.GetAllPeopleWithCountryName();
            dgvPeople.DataSource = _People;
            lblRecords.Text = "#Records:   " + dgvPeople.Rows.Count.ToString();


        }
      
        private void _dgvPeopleDesigned()
        {
            dgvPeople.Columns["ImagePath"].Visible = false;
            dgvPeople.Columns["DateOfBirth"].Width = 170;
            dgvPeople.Columns["Email"].Width = 170;
            dgvPeople.Columns["FirstName"].Width = 130;
            dgvPeople.Columns["SecondName"].Width = 120;
            dgvPeople.Columns["Phone"].Width = 121;

            dgvPeople.Columns["LastName"].Width = 130;
            dgvPeople.Columns["Gender"].Width = 70;



        }
        private void _cbFilterByDesigned()
        {
            cbfilterBy.SelectedIndex = 0;
        }
        private void frmManagePeople_Load(object sender, EventArgs e)
        {
            _Refresh();
            _dgvPeopleDesigned();
            _cbFilterByDesigned();
        }

        private bool _SearchForPersonBy(string SearchOption, string SearchOn)
        {
            if (string.IsNullOrEmpty(SearchOption) || string.IsNullOrEmpty(SearchOn))
                return false;

            SearchOption = SearchOption.Replace(" ", "");

         
            DataTable temp = _People.Clone();
            temp.Rows.Clear();

            foreach (DataRow row in _People.Rows)
            {
                if (row[SearchOption].ToString() == SearchOn)
                {
                    temp.ImportRow(row); // Copy only the found row
                   
                }
            }

            if(temp.Rows.Count > 0)
            {
                dgvPeople.DataSource = temp; // Show the rows that has been found 
                return true;
            }
            else return false;
        }


        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        
        private void cbfilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cbfilterBy.SelectedIndex>0)
            {
                mtbSearch.Visible = true;
                if (cbfilterBy.SelectedItem != null && cbfilterBy.SelectedItem.ToString() == "Person ID")
                {
                    // Allow only 10-digit numeric input
                    mtbSearch.Mask = "0000000000";
                }
                else
                {
                    mtbSearch.Mask = string .Empty;
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
            if(!_SearchForPersonBy(cbfilterBy.Text, mtbSearch.Text))
            {
                DataTable temp = _People.Clone();
                temp.Rows.Clear();
                dgvPeople.DataSource= temp;
            }
        }

        private void mtbSearch_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void btnAddNewPerson_Click(object sender, EventArgs e)
        {
           
           
          
        }

        private void tsmSendEmail_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This feature is not implementing yet",
               "" , MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void tsmPhoneCall_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This feature is not implementing yet",
              "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void tsmShowDetails_Click(object sender, EventArgs e)
        {
            if(dgvPeople.CurrentRow != null)
            {
                int PersonID = Convert.ToInt32(dgvPeople.CurrentRow.Cells["PersonID"].Value);
                frmPersonInfo frmPersonInfo = new frmPersonInfo(PersonID);
                frmPersonInfo.ShowDialog();
            }
           
        }
    }
}
