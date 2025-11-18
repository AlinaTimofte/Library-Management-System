using System.Text.Json.Serialization;

namespace Desktop_client.Models
{
    internal class BorrowRequest
    {
        [JsonPropertyName("bookId")]
        public long BookId { get; set; }

        [JsonPropertyName("borrowerId")]
        public long BorrowerId { get; set; }

        [JsonPropertyName("days")]
        public int Days { get; set; }
    }
}