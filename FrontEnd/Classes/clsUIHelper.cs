﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using BusinessLogicLayer;
using System.IO;
using System.Windows.Forms;
using System.Drawing;
using System.Security.Cryptography;

namespace FrontEnd.Classes
{
    internal static class clsUIHelper
    {
         

        public static string GetCountryName(int CountryID)
        {
            return clsCountries.Find(CountryID).CountryName;
        }

        public static int GetCountryID(string CountryName)
        {
            return clsCountries.Find(CountryName).CountryID;
        }
        public static bool IsDomainValid(string email)
        {
            try
            {
                // Extract domain from email
                string domain = email.Split('@')[1];

                // Perform a DNS lookup for the domain
                var hostEntry = Dns.GetHostEntry(domain);

                // If domain has IP addresses, it exists
                return hostEntry.AddressList.Length > 0;
            }
            catch
            {
                return false; // Domain not found
            }
        }
        public static bool IsValidEmail(string email)
        {
            if (email == string.Empty) return true;
            try
            {
                // Step 1: Check if the email format is correct
                var addr = new MailAddress(email);

                // Step 2: Check if the domain exists
                return IsDomainValid(email);
            }
            catch
            {
                return false; // Invalid email format
            }
        }

        public static bool ImagesAreEqual(Image img1, Image img2)
        {
            if (img1 == null || img2 == null) return false;

            using (MemoryStream ms1 = new MemoryStream(), ms2 = new MemoryStream())
            {
                img1.Save(ms1, System.Drawing.Imaging.ImageFormat.Png);
                img2.Save(ms2, System.Drawing.Imaging.ImageFormat.Png);
                return ms1.ToArray().SequenceEqual(ms2.ToArray());
            }
        }

        public static void DeleteImageFromFile(string ImagePath)
        {
            if (!string.IsNullOrEmpty(ImagePath) && File.Exists(ImagePath))
            {
                try
                {
                    // Get the folder path
                    string allowedFolder = @"C:\DVLD Photos";
                    string imageDirectory = Path.GetDirectoryName(ImagePath);

                    // Check if the file is inside "C:\DVLD Photos"
                    if (string.Equals(imageDirectory, allowedFolder, StringComparison.OrdinalIgnoreCase))
                    {

                        // Delete the file
                        File.Delete(ImagePath);
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error deleting old image: " + ex.Message);
                }
            }


        }

        public static void SetErrorProvider(Control C, ErrorProvider errorProvider)
        {
            if (C is TextBox || C is RichTextBox) // Ensure it's a text input control
            {
                if (string.IsNullOrWhiteSpace(C.Text))
                {
                    errorProvider.SetError(C, "This field cannot be empty.");
                }
                else
                {
                    errorProvider.SetError(C, ""); // Clear error if valid
                }
            }
        }

       public  static void ShowErrorMessageForFailOperation()
        {
            MessageBox.Show("Can't Perform this operation", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public static void ShowNotImplementedYetMessage()
        {
            MessageBox.Show("This Feature is not implemented yet", "",
                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        public static string GetCurrentDate()
        {
            return DateTime.Now.ToString("dd/MM/yyyy");
        }

        public static void SetFormFullScreenVerticalOnly(Form from)
        {
            // this from chatgbt i don't know how it work
            from.Top = 0; // Move form to top of screen
            from.Height = Screen.PrimaryScreen.WorkingArea.Height; // Full vertical height

        }

        public static bool ShowErrorMessageForInActiveLicense(int LicenseID)
        {
                if (!clsLicense.isActive(LicenseID))
                {
                    MessageBox.Show("Selected License is not Active,you can't do any operation on it "
                        , "Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return true;
                }
            return false;
        }

        public static string ComputeHash(string input)
        {
            using (SHA256 sha256= SHA256.Create())
            {
                // Compute the hash value from the UTF-8 encoded input string
                byte[] hashBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(input));

                // Convert the byte array to a lowercase hexadecimal string
                StringBuilder HashResult = new StringBuilder();
                foreach (var b in hashBytes)
                {
                    HashResult.Append(b.ToString("x2"));
                }
                return HashResult.ToString();
            }
        }

    }
}
