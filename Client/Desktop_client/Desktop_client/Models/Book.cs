using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desktop_client.Models
{
    public class Book
    {
        public long Id { get; set; }
        public string Title { get; set; } = "";
        public Author Author { get; set; }
        public string Description { get; set; } = "";
        public int AvailableCopies { get; set; }
    }
}
