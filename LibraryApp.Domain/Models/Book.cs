using System.Collections.Generic;
using System.Linq;

namespace LibraryApp.Domain.Models
{
    public class Book
    {
        public Book()
        {
            Loans = new List<BookLoan>();
        }

        public string Author { get; set; }
        public int Id { get; set; }

        public bool IsAvailable
        {
            get
            {
                return !Loans.Any(l => l.Returned == null);
            }
        }

        public List<BookLoan> Loans { get; set; }
        public string Title { get; set; }
    }
}