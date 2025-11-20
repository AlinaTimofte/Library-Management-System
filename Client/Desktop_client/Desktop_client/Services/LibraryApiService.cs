using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Desktop_client.Models;

namespace Desktop_client.Services
{
    internal class LibraryApiService
    {
        private static readonly HttpClient client = new HttpClient();
        private static readonly JsonSerializerOptions jsonOptions =
            new JsonSerializerOptions { 
                PropertyNameCaseInsensitive = true,
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase 
            };

        public LibraryApiService()
        {
            if (client.BaseAddress == null)
            {
                client.BaseAddress = new Uri("http://localhost:8080");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));
            }
        }

        // Register: POST /api/borrowers/register  { name, email, password }
        public async Task<Borrower> RegisterBorrowerAsync(string name, string email, string password)
        {
            var payload = new { name, email, password };
            string json = JsonSerializer.Serialize(payload);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await client.PostAsync("api/borrowers/register", content);
            if (!response.IsSuccessStatusCode) return null;

            string body = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<Borrower>(body, jsonOptions);
        }

        // Login: POST /api/borrowers/login  { email, password }
        public async Task<Borrower> LoginAsync(string email, string password)
        {
            var payload = new { email, password };
            string json = JsonSerializer.Serialize(payload);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await client.PostAsync("api/borrowers/login", content);
            if (!response.IsSuccessStatusCode) return null;

            string body = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<Borrower>(body, jsonOptions);
        }

        // Borrow: POST /api/loans/borrow  { bookId, borrowerId, days }
        public async Task<Loan> BorrowBookAsync(long bookId, long borrowerId, int days)
        {
            var payload = new BorrowRequest { BookId = bookId, BorrowerId = borrowerId, Days = days };
            string json = JsonSerializer.Serialize(payload);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await client.PostAsync("api/loans/borrow", content);
            if (!response.IsSuccessStatusCode) return null;

            string body = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<Loan>(body, jsonOptions);
        }

        // Return: POST /api/loans/{loanId}/return
        public async Task<Loan> ReturnBookAsync(long loanId)
        {
            var response = await client.PostAsync($"api/loans/{loanId}/return", null);
            if (!response.IsSuccessStatusCode) return null;

            string body = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<Loan>(body, jsonOptions);
        }

        // Get all authors: GET /api/authors
        public async Task<List<Author>> GetAuthorsAsync()
        {
            var response = await client.GetAsync("api/authors");
            if (!response.IsSuccessStatusCode) return new List<Author>();

            string body = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<List<Author>>(body, jsonOptions);
        }

        // Get books by author: GET /api/books/by-author/{authorId}
        public async Task<List<Book>> GetBooksByAuthorAsync(long authorId)
        {
            var response = await client.GetAsync($"api/books/by-author/{authorId}");
            if (!response.IsSuccessStatusCode) return new List<Book>();

            string body = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<List<Book>>(body, jsonOptions);
        }

        // Get book by ID: GET /api/books/{id}
        public async Task<Book> GetBookAsync(long bookId)
        {
            var response = await client.GetAsync($"api/books/{bookId}");
            if (!response.IsSuccessStatusCode) return null;

            string body = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<Book>(body, jsonOptions);
        }

        // Reserve book: POST /api/books/{id}/reserve
        public async Task<Book> ReserveBookAsync(long bookId)
        {
            var response = await client.PostAsync($"api/books/{bookId}/reserve", null);
            if (!response.IsSuccessStatusCode) return null;

            string body = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<Book>(body, jsonOptions);
        }

        // Get borrower loans: GET /api/borrowers/{id}/loans
        public async Task<List<Loan>> GetBorrowerLoansAsync(long borrowerId)
        {
            var response = await client.GetAsync($"api/borrowers/{borrowerId}/loans");
            if (!response.IsSuccessStatusCode) return new List<Loan>();

            string body = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<List<Loan>>(body, jsonOptions);
        }

        // Add Suggestion: POST /api/suggestions
        public async Task<Suggestion> AddSuggestionAsync(Suggestion suggestion)
        {
            string json = JsonSerializer.Serialize(suggestion, jsonOptions);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await client.PostAsync("api/suggestions", content);
            if (!response.IsSuccessStatusCode) return null;

            string body = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<Suggestion>(body, jsonOptions);
        }
    }
}