using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Desktop_client.Models;

namespace Desktop_client
{
    public partial class SuggestionsForm : Form
    {
        private Borrower borrower;
        public SuggestionsForm()
        {
            InitializeComponent();
        }

        public SuggestionsForm(Borrower borrower) : this()
        {
            this.Size = new Size(1090, 650);
            this.borrower = borrower;
            this.Text = $"Profile - {borrower.Name}";
        }
    
        private async void SendDataButton_Click(object sender, EventArgs e)
        {
            // Validation
            if (string.IsNullOrWhiteSpace(AuthorInsertTextBox.Text) ||
                string.IsNullOrWhiteSpace(TitleInsertTextBox.Text) ||
                string.IsNullOrWhiteSpace(GenreInsertTextBox.Text) ||
                string.IsNullOrWhiteSpace(DescriptionTextBox.Text))
            {
                MessageBox.Show("You need to write all the boxes.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (DescriptionTextBox.Text.Length > 1000)
            {
                MessageBox.Show("Description must be maximum 1000 characters.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Create Suggestion object
            var suggestion = new Models.Suggestion
            {
                Author = AuthorInsertTextBox.Text,
                Title = TitleInsertTextBox.Text,
                Genre = GenreInsertTextBox.Text,
                Description = DescriptionTextBox.Text
            };

            // Call API
            var apiService = new Services.LibraryApiService();
            try
            {
                var result = await apiService.AddSuggestionAsync(suggestion);
                if (result != null)
                {
                    MessageBox.Show("The informations had been saved.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    // Clear fields
                    AuthorInsertTextBox.Clear();
                    TitleInsertTextBox.Clear();
                    GenreInsertTextBox.Clear();
                    DescriptionTextBox.Clear();
                }
                else
                {
                    MessageBox.Show("Failed to save suggestion.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ExitAppButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void GoToProfileButton_Click(object sender, EventArgs e)
        {
            var profileForm = new ProfileForm(borrower);
            profileForm.Show();
            this.Hide();
        }
    }
}