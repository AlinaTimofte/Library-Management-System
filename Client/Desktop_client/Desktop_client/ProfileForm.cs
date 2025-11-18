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
        private bool isReserveInProgress;

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

        private const int DefaultLoanDays = 7;

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

                await RefreshUserLoansAsync();
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

                await RefreshUserLoansAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error returning book: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void ReserveButton_Click(object sender, EventArgs e)
        {
            if (isReserveInProgress)
            {
                return;
            }

            if (BooksComboBox.SelectedIndex < 0)
            {
                MessageBox.Show("Please select a book to reserve.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (borrower == null)
            {
                MessageBox.Show("Borrower information is missing. Please log in again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var selectedBook = books[BooksComboBox.SelectedIndex];

            try
            {
                isReserveInProgress = true;
                ReserveButton.Enabled = false;

                var loan = await apiService.BorrowBookAsync(selectedBook.Id, borrower.Id, DefaultLoanDays);
                if (loan == null)
                {
                    MessageBox.Show("Unable to reserve the book at the moment. Please try again.", "Reservation Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var dueDateText = loan.DueAt.ToString("yyyy-MM-dd");
                MessageBox.Show($"The book has been added to your loans.\nDue date: {dueDateText}.", "Reservation Confirmed", MessageBoxButtons.OK, MessageBoxIcon.Information);

                await RefreshUserLoansAsync();

                if (loan.Book != null)
                {
                    int newLoanIndex = userLoans.FindIndex(l => l.Id == loan.Id);
                    if (newLoanIndex >= 0)
                    {
                        UserCollectionComboBox.SelectedIndex = newLoanIndex;
                        DueAtTextBox.Text = loan.DueAt.ToString("yyyy-MM-dd");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error reserving book: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                isReserveInProgress = false;
                ReserveButton.Enabled = true;
            }
        }

        private async void RefreshButton_Click(object sender, EventArgs e)
        {
            if (borrower == null)
            {
                MessageBox.Show("Borrower information is missing. Please log in again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                await RefreshUserLoansAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error refreshing loans: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task RefreshUserLoansAsync()
        {
            if (borrower == null)
            {
                return;
            }

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