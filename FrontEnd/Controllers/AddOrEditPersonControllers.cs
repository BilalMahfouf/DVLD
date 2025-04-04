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
using System.Resources;
using System.Text.RegularExpressions;
using System.Net.Mail;
using System.Net;
using FrontEnd.Classes;

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

       private enum enMode { AddNew,Update};
        private enMode _Mode = enMode.Update;

        private Image MaleImage = Properties.Resources.Male_512;
        private Image FemaleImage = Properties.Resources.Female_512;


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

        private void _SetCountries()
        {
            DataTable Countries= clsCountries.GetAllCountries();
            cbCountries.DataSource = Countries;
            cbCountries.DisplayMember = "CountryName";
            cbCountries.SelectedIndex = 1;
        }

        public  void LoadPersonInfo()
        {
            clsPerson person = clsPerson.Find(PersonID);
            if (person != null)
            {
                tbFirstName.Text = person.FirstName;
                tbSecondName.Text = person.SecondName;
                tbThirdName.Text = person.ThirdName;
                tbLastName.Text = person.LastName;
                tbNationalNo.Text = person.NationalNo;
                dateTimePicker1.Text = person.DateOfBirth.ToString();
                if(person.Gender==0)
                {
                    rbMale.Checked = true;
                }
                else
                {
                    rbFemale.Checked = true;
                }
                rtbAddress.Text = person.Address;
                tbPhone.Text = person.Phone;
                tbEmail.Text = person.Email;
                if(File.Exists(person.ImagePath))
                {
                    pbPersonPicture.Image=Image.FromFile(person.ImagePath);
                    pbPersonPicture.ImageLocation = person.ImagePath;
                    linklblRemove.Visible = true;
                }
                cbCountries.Text = clsUIHelper.GetCountryName(person.NationalityCountryID);

            }

        }
        private void AddOrEditPersonControllers_Load(object sender, EventArgs e)
        {
            _SetCountries();
            
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
            try
            {
                // Generate a new image name with the original extension
                Guid ImageNewName = Guid.NewGuid();
                string destinationFolder = @"C:\DVLD Photos\";
                string FolderName = "C:\\DVLD Photos";
                string fileExtension = Path.GetExtension(ImagePath);
                string newFilePath = Path.Combine(destinationFolder, ImageNewName.ToString() + fileExtension);
                
                if(File.Exists(ImagePath) && Path.GetDirectoryName(ImagePath)== FolderName)
                {
                    return;
                }
               
                // Ensure the destination folder exists
                if (!Directory.Exists(destinationFolder))
                {
                    Directory.CreateDirectory(destinationFolder);
                }

                // Copy the new image
                File.Copy(ImagePath, newFilePath, true);

                string OldImagePath = pbPersonPicture.ImageLocation;

                // Release the previous image if exists
                if (!string.IsNullOrEmpty(OldImagePath) && File.Exists(OldImagePath))
                {
                    if (pbPersonPicture.Image != null)
                    {
                        pbPersonPicture.Image.Dispose();
                        pbPersonPicture.Image = null;
                        pbPersonPicture.ImageLocation = null;
                    }

                    // Delete the old image asynchronously
                   

                    _RemoveImage(OldImagePath);
                }
            

                // Assign new image
                pbPersonPicture.Image = Image.FromFile(newFilePath);
                pbPersonPicture.ImageLocation = newFilePath;
                linklblRemove.Visible = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saving image: " + ex.Message);
            }
        }


        private void linklblSetImage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

            if (ofdSetImage.ShowDialog() == DialogResult.OK)
            {
                _RemoveImage(pbPersonPicture.ImageLocation);
                pbPersonPicture.Image = Image.FromFile(ofdSetImage.FileName);
                pbPersonPicture.ImageLocation = ofdSetImage.FileName;
                linklblRemove.Visible = true;
            }
        }

        private void _RemoveImage(string ImagePath)
        {
            if (!string.IsNullOrEmpty(ImagePath) && File.Exists(ImagePath))
            {
                try
                {
                    // Get the folder path
                    string allowedFolder = @"C:\DVLD Photos";
                    string imageDirectory = Path.GetDirectoryName(ImagePath);

                    // Release the file lock
                    if (pbPersonPicture.Image != null)
                    {
                        pbPersonPicture.Image.Dispose();
                        pbPersonPicture.Image = null;
                        pbPersonPicture.ImageLocation = null;
                    }


                    // Check if the file is inside "C:\DVLD Photos"
                    if (string.Equals(imageDirectory, allowedFolder, StringComparison.OrdinalIgnoreCase))
                    {
                        
                        // Force garbage collection to fully release the file
                        GC.Collect();
                        GC.WaitForPendingFinalizers();

                        // Delete the file
                        File.Delete(ImagePath);
                        //MessageBox.Show("Picture removed and file deleted.");
                    }
                    
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error deleting old image: " + ex.Message);
                }
            }

            // Hide the remove link
            linklblRemove.Visible = false;
            _SetDefaultImage();
        }

        public void RemoveImage(string ImagePath)
        {
            _RemoveImage(ImagePath);
        }



        private void linklblRemove_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            _RemoveImage(pbPersonPicture.ImageLocation);
            
        }

        private bool ValidateUserInput(string Input)
        {
            if(Input==string.Empty)
            {
                MessageBox.Show("Please fill all the information", "Error", MessageBoxButtons.OK
                    , MessageBoxIcon.Error);
                return false;
            }
            return true;
            
        }
        private bool _SavePerson()
        {
            clsPerson Person;
            if (PersonID > 0) 
            {
                 Person=clsPerson.Find(PersonID);
                _Mode = enMode.Update;
            }
            else
            {
                 Person = new clsPerson();
                _Mode = enMode.AddNew;

            }
            if(_Mode == enMode.AddNew && clsPerson.isExist(tbNationalNo.Text))
            {
                return false;
            }
            if (!ValidateUserInput(tbNationalNo.Text))
            {
                return false;
            }
            Person.NationalNo = tbNationalNo.Text;

            if (!ValidateUserInput(tbFirstName.Text))
            {
                return false;
            }
            Person.FirstName=tbFirstName.Text;

            if (!ValidateUserInput(tbSecondName.Text))
            {
                return false;
            }
            Person.SecondName = tbSecondName.Text;

            Person.ThirdName = tbThirdName.Text;

            if (!ValidateUserInput(tbLastName.Text))
            {
                return false;
            }
            Person.LastName = tbLastName.Text;

            if (rbFemale.Checked)
            {
                Person.Gender = 1;
            }
            else if (rbMale.Checked)
            {
                Person.Gender = 0;
            }
            Person.DateOfBirth = Convert.ToDateTime(dateTimePicker1.Text);

            if (!ValidateUserInput(cbCountries.Text))
            {
                return false;
            }
            Person.NationalityCountryID = clsUIHelper.GetCountryID(cbCountries.Text);

            if (!ValidateUserInput(tbPhone.Text))
            {
                return false;
            }
            Person.Phone = tbPhone.Text;
            if(!clsUIHelper.IsValidEmail(tbEmail.Text))
            {
                MessageBox.Show("Please enter a valid email format", "Error", MessageBoxButtons.OK
                    , MessageBoxIcon.Error);
                return false;
            }
            Person.Email=tbEmail.Text;
            bool ImageC = !clsUIHelper.ImagesAreEqual(pbPersonPicture.Image, MaleImage) &&
              !clsUIHelper.ImagesAreEqual(pbPersonPicture.Image, FemaleImage);
            if (pbPersonPicture.Image != null && pbPersonPicture.ImageLocation != string.Empty
                && ImageC) 
            {
                _SaveImage(pbPersonPicture.ImageLocation);
                Person.ImagePath = pbPersonPicture.ImageLocation;
            }
            else
            {
                Person.ImagePath = null;
            }

            if (!ValidateUserInput(rtbAddress.Text))
            {
                return false;
            }
            Person.Address = rtbAddress.Text;
            if (Person.Save())
            {
                PersonID = Person.PersonID;

                
                return true;
            }
            

            return false;

        }

        private void _SetDefaultImage()
        {
            // it's not bug its a feature
                if (rbFemale.Checked)
                {
                    pbPersonPicture.Image = Properties.Resources.Female_512;
                }
                if (rbMale.Checked)
                {
                    pbPersonPicture.Image = Properties.Resources.Male_512;
                }
            linklblRemove.Visible = false;
            
        }

        // this code create an btnClose_Clicked event that can be accessed from any from
        // don't touch it because i don't how the hell it work

        // Define an event for requesting form closure
        public event Action<int> OnSaveRequested;

        // Method to raise the event
        protected virtual void SaveRequested(int PersonID)
        {
            Action<int> handler = OnSaveRequested;
            if (handler != null)
            {
                handler(PersonID); // Invoke event
            }
        }

        private void _ShowSaveResult()
        {
            if (_SavePerson())
            {
                if(_Mode==enMode.Update)
                {
                    MessageBox.Show("Person Updated successfully", "", MessageBoxButtons.OK
                    , MessageBoxIcon.Asterisk);
                    _Mode = enMode.Update;
                }
                else
                {
                    MessageBox.Show("Person added successfully", "", MessageBoxButtons.OK
                    , MessageBoxIcon.Asterisk);
                }
                
                if (OnSaveRequested != null)
                {
                    SaveRequested(PersonID);
                }
            }
            else
            {
                MessageBox.Show("This operation can't be done", "Error", MessageBoxButtons.OK
                                    , MessageBoxIcon.Error);
            }
        }
        private void btnSave_Click(object sender, EventArgs e)
        {

            _ShowSaveResult();
        }

        private void rbMale_CheckedChanged(object sender, EventArgs e)
        {
            _SetDefaultImage();
        }

        private void rbFemale_CheckedChanged(object sender, EventArgs e)
        {
            _SetDefaultImage();
        }
       
        

    }
}
