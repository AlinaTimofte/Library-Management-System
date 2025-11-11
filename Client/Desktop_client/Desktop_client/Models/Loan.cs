using System;

namespace Desktop_client.Models
{
    internal class Loan
    {
        public long Id { get; set; }
        public DateTime BorrowedAt { get; set; }
        public DateTime DueAt { get; set; }
        public DateTime? ReturnedAt { get; set; }
    }
}


