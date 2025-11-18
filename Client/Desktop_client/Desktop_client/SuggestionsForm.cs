using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Desktop_client
{
    public partial class SuggestionsForm : Form
    {
        public SuggestionsForm()
        {
            InitializeComponent();
        }

        private void ExitAppButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void GoToProfileButton_Click(object sender, EventArgs e)
        {
            var profileForm = new ProfileForm();
            profileForm.Show();
        }
    }
}
