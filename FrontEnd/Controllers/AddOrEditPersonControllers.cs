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
using System.IO;

namespace FrontEnd.Controllers
{
    public partial class AddOrEditPersonControllers : UserControl
    {
        public AddOrEditPersonControllers()
        {
            InitializeComponent();
            dateTimePicker1.MaxDate = DateTime.Today.AddYears(-18);
        }

        public int PersonID;
        private void SetErrorProvider(Control C)
        {
            if (C is TextBox || C is RichTextBox) // Ensure it's a text input control
            {
                if (string.IsNullOrWhiteSpace(C.Text))
                {
                    errorProvider1.SetError(C, "This field cannot be empty.");
                }
                else
                {
                    errorProvider1.SetError(C, ""); // Clear error if valid
                }
            }
        }

        private void SetCountries()
        {
            DataTable Countries= clsCountries.GetAllCountries();
            cbCountries.DataSource = Countries;
            cbCountries.DisplayMember = "CountryName";
            cbCountries.SelectedIndex = 2;
        }

        private void AddOrEditPersonControllers_Load(object sender, EventArgs e)
        {
            SetCountries();
        }

        private void AllTextBox_TextChanged(object sender, EventArgs e)
        {
            SetErrorProvider((Control)sender);
        }


        // this code create an btnClose_Clicked event that can be accessed from any from
        // don't touch it because i don't how the hell it work

        // Define an event for requesting form closure
        public event Action OnCloseRequested;

        // Method to raise the event
        protected virtual void CloseRequested()
        {
            Action handler = OnCloseRequested;
            if (handler != null)
            {
                handler(); // Invoke event
            }
        }


        private void btnClose_Click(object sender, EventArgs e)
        {
            if(OnCloseRequested!=null)
            {
                CloseRequested();
            }
        }

        private void _SaveImage(string ImagePath)
        {
            Guid ImageNewName = Guid.NewGuid();
            string destinationFolder = @"C:\DVLD Photos\";  
            string newFilePath = Path.Combine(destinationFolder, ImageNewName.ToString());

            File.Copy(ImagePath, newFilePath.ToString());
            string OldImagePath = pbPersonPicture.ImageLocation;

           

            if (!string.IsNullOrEmpty(OldImagePath) && File.Exists(OldImagePath))
            {

                // Force garbage collection to release the file lock

                if (pbPersonPicture.Image != null)
                {
                    pbPersonPicture.Image.Dispose();
                    pbPersonPicture.Image = null;
                    pbPersonPicture.ImageLocation = null;

                }
                GC.Collect();
                GC.WaitForPendingFinalizers();

                try
                {
                    File.Delete(OldImagePath);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error deleting old image: " + ex.Message);
                }
            }
            pbPersonPicture.Image = Image.FromFile(newFilePath);
            pbPersonPicture.ImageLocation = newFilePath;
            linklblRemove.Visible = true;
        }

        private void linklblSetImage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

            if (ofdSetImage.ShowDialog() == DialogResult.OK)
            {
                _SaveImage(ofdSetImage.FileName);
            }
        }

        private void _RemoveImage(string ImagePath)
        {
            
                if (!string.IsNullOrEmpty(ImagePath) && File.Exists(ImagePath))
                {
               
                // Force garbage collection to release the file lock
               
                if (pbPersonPicture.Image != null)
                {
                    pbPersonPicture.Image.Dispose();
                    pbPersonPicture.Image = null;
                    pbPersonPicture.ImageLocation = null;

                }
                GC.Collect();
                GC.WaitForPendingFinalizers();

                try
                {
                        File.Delete(ImagePath);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error deleting old image: " + ex.Message);
                    }
                }
            linklblRemove.Visible = false;
        }
        

        private void linklblRemove_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            _RemoveImage(pbPersonPicture.ImageLocation);
            
        }

        private void _SavePerson()
        {
            clsPerson clsPerson = new clsPerson();
            clsPerson.FirstName=tbFirstName.Text;
            clsPerson.SecondName = tbSecondName.Text;
            clsPerson.ThirdName = tbThirdName.Text;
            clsPerson.LastName=tbLastName.Text;
            if(rbFemale.Checked)
            {
                clsPerson.Gender = 1;
            }
            else if (rbMale.Checked)
            {
                clsPerson.Gender = 0;
            }
            clsPerson.DateOfBirth = Convert.ToDateTime(dateTimePicker1.Text);


            clsPerson.Email=tbEmail.Text;

        }

        private void btnSave_Click(object sender, EventArgs e)
        {

        }
    }
}
