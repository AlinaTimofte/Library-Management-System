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

namespace Desktop_client
{
    public partial class RegisterForm : Form
    {
        private readonly LibraryApiService _apiService;
        public RegisterForm()
        {
            InitializeComponent();
            _apiService = new LibraryApiService();
            this.GoToMainPageButton.Click += GoToMainPageButton_Click;
        }

        private async void RegisterBorrowerButton_Click(object sender, EventArgs e)
        {
            var name = this.NameTextBox.Text?.Trim() ?? "";
            var email = this.EmailTextBox.Text?.Trim() ?? "";
            var password = this.PasswordTextBox.Text ?? "";

            if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Name, Email and Password are required.");
                return;
            }

            try
            {
                var created = await _apiService.RegisterBorrowerAsync(name, email, password);
                if (created == null)
                {
                    MessageBox.Show("Registration failed (email may already be used).");
                    return;
                }

                MessageBox.Show("Successfully registered. You can log in now.");
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
        }

        private void GoToMainPageButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
