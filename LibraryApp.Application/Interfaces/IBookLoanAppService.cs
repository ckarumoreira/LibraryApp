using System.Collections.Generic;
using LibraryApp.Application.ViewModels;

namespace LibraryApp.Application.Interfaces
{
    public interface IBookLoanAppService
    {
        void BorrowBook(int bookId, string user);

        IEnumerable<BookLoanViewModel> GetLoans(int bookId);

        void ReturnBook(int bookId, string user);
    }
}