using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Desktop_client.Services;
using Desktop_client.Models;

namespace Desktop_client
{
    public partial class WelcomeForm : Form
    {
        // Create an instance of our new service
        private readonly LibraryApiService _apiService;

        public WelcomeForm()
        {
            InitializeComponent();
            this.Size = new Size(1000, 600);
            _apiService = new LibraryApiService(); // Initialize the service
        }

        private void RegisterButton_Click(object sender, EventArgs e)
        {
            using (var reg = new RegisterForm())
            {
                reg.ShowDialog();
            }
        }

        private async void SubmitLogInButton_Click(object sender, EventArgs e)
        {
            var email = emailTextBox.Text?.Trim() ?? "";
            var password = PasswordTextBox.Text ?? "";

            if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Email and Password are required.");
                return;
            }

            Borrower borrower;
            try
            {
                borrower = await _apiService.LoginAsync(email, password);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Failed to contact server:\n{ex}\n\nInner: {ex.InnerException?.Message}",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            if (borrower == null)
            {
                MessageBox.Show("Invalid credentials.");
                return;
            }

            var profile = new ProfileForm(borrower);
            profile.Show();
            this.Hide();
        }
    }
}
