using System;

namespace LibraryApp.Domain.Models
{
    public class BookLoan
    {
        public DateTime Borrowed { get; set; }
        public DateTime? Returned { get; set; }
        public string User { get; set; }
    }
}