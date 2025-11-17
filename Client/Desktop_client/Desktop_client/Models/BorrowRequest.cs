using System;

namespace Desktop_client.Models
{
    internal class BorrowRequest
    {
        public long BookId { get; set; }
        public long BorrowerId { get; set; }
        public int Days { get; set; }
    }
}


