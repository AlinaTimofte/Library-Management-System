using System;
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
            new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

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
    }
}


