using System;

namespace Desktop_client.Models
{
    internal class Loan
    {
        public long Id { get; set; }
        public DateTime BorrowedAt { get; set; }
        public DateTime DueAt { get; set; }
        public DateTime? ReturnedAt { get; set; }
<<<<<<< HEAD
        public Book Book { get; set; }
=======
>>>>>>> 7e8896f6eaeb727f99ba64333cdd65172b716097
    }
}


