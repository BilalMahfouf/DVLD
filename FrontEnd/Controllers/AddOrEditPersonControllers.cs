using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrontEnd.Controllers
{
    public partial class AddOrEditPersonControllers : UserControl
    {
        public AddOrEditPersonControllers()
        {
            InitializeComponent();
            dateTimePicker1.MaxDate = DateTime.Today.AddYears(-18);
        }

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

        private void AddOrEditPersonControllers_Load(object sender, EventArgs e)
        {

        }

        
    }
}
