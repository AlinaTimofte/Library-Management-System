<<<<<<< HEAD
﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Desktop_client.Models;
using Desktop_client.Services;

namespace Desktop_client
{
    public partial class ProfileForm : Form
    {
        private Borrower borrower;
        private LibraryApiService apiService;
        private List<Author> authors;
        private List<Book> books;
        private List<Loan> userLoans;

        public ProfileForm()
        {
            InitializeComponent();
            apiService = new LibraryApiService();
        }

        public ProfileForm(Borrower borrower) : this()
        {
            this.borrower = borrower;
            this.Text = $"Profile - {borrower.Name}";
            LoadData();
        }

        private async void LoadData()
        {
            try
            {
                // Load authors
                authors = await apiService.GetAuthorsAsync();
                AuthorComboBox.Items.Clear();
                foreach (var author in authors)
                {
                    AuthorComboBox.Items.Add(author.Name);
                }

                // Load user's loans
                userLoans = await apiService.GetBorrowerLoansAsync(borrower.Id);
                UserCollectionComboBox.Items.Clear();
                foreach (var loan in userLoans)
                {
                    if (loan.Book != null)
                    {
                        UserCollectionComboBox.Items.Add(loan.Book.Title);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AuthorComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (AuthorComboBox.SelectedIndex >= 0 && AuthorComboBox.SelectedIndex < authors.Count)
            {
                LoadBooksByAuthor(authors[AuthorComboBox.SelectedIndex].Id);
            }
        }

        private async void LoadBooksByAuthor(long authorId)
        {
            try
            {
                books = await apiService.GetBooksByAuthorAsync(authorId);
                BooksComboBox.Items.Clear();
                foreach (var book in books)
                {
                    BooksComboBox.Items.Add(book.Title);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading books: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BooksComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (BooksComboBox.SelectedIndex >= 0 && BooksComboBox.SelectedIndex < books.Count)
            {
                var selectedBook = books[BooksComboBox.SelectedIndex];
                DescriptionTextBox.Text = selectedBook.Description ?? "No description available.";
            }
        }

        private void UserCollectionComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (UserCollectionComboBox.SelectedIndex >= 0 && UserCollectionComboBox.SelectedIndex < userLoans.Count)
            {
                var selectedLoan = userLoans[UserCollectionComboBox.SelectedIndex];
                DueAtTextBox.Text = selectedLoan.DueAt.ToString("yyyy-MM-dd");
            }
        }

        private async void ReturnButton_Click(object sender, EventArgs e)
        {
            if (UserCollectionComboBox.SelectedIndex < 0)
            {
                MessageBox.Show("Please select a book to return.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var selectedLoan = userLoans[UserCollectionComboBox.SelectedIndex];

            try
            {
                await apiService.ReturnBookAsync(selectedLoan.Id);
                MessageBox.Show("You have 3 days to bring the book back to the library.", "Return Confirmed", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Refresh the user's loans
                userLoans = await apiService.GetBorrowerLoansAsync(borrower.Id);
                UserCollectionComboBox.Items.Clear();
                foreach (var loan in userLoans)
                {
                    if (loan.Book != null)
                    {
                        UserCollectionComboBox.Items.Add(loan.Book.Title);
                    }
                }

                DueAtTextBox.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error returning book: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void ReserveButton_Click(object sender, EventArgs e)
        {
            if (BooksComboBox.SelectedIndex < 0)
            {
                MessageBox.Show("Please select a book to reserve.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var selectedBook = books[BooksComboBox.SelectedIndex];

            try
            {
                await apiService.ReserveBookAsync(selectedBook.Id);
                MessageBox.Show("The book can be picked up today!", "Reservation Confirmed", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error reserving book: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ExitAppButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void SuggestionsButton_Click(object sender, EventArgs e)
        {
            var suggestionsForm = new SuggestionsForm();
            suggestionsForm.Show();
        }
    }
}
=======
﻿using System;
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
    public partial class ProfileForm : Form
    {
        public ProfileForm()
        {
            InitializeComponent();
        }

        public ProfileForm(Borrower borrower) : this()
        {
            this.Text = $"Profile - {borrower.Name}";
        }
    }
}
>>>>>>> 7e8896f6eaeb727f99ba64333cdd65172b716097
