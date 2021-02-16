using System.Collections.Generic;
using System.Linq;

namespace LibraryApp.Application.ViewModels
{
    public class BookViewModel
    {
        public BookViewModel()
        {
            Loans = new List<BookLoanViewModel>();
        }

        public string Author { get; set; }
        public int Id { get; set; }

        public bool IsAvailable
        {
            get { return !Loans.Any(x => x.Returned == null); }
        }

        public List<BookLoanViewModel> Loans { get; set; }
        public string Title { get; set; }
    }
}