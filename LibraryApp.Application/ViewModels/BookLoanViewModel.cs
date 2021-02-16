using System;

namespace LibraryApp.Application.ViewModels
{
    public class BookLoanViewModel
    {
        public DateTime Borrowed { get; set; }
        public DateTime? Returned { get; set; }
        public string User { get; set; }
    }
}