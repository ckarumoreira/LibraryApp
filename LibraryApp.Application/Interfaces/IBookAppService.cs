using System.Collections.Generic;
using LibraryApp.Application.ViewModels;

namespace LibraryApp.Application.Interfaces
{
    public interface IBookAppService
    {
        void Create(BookViewModel book);

        void Delete(int bookId);

        IEnumerable<BookViewModel> GetAll();

        BookViewModel GetById(int bookId);

        void Update(BookViewModel book);
    }
}