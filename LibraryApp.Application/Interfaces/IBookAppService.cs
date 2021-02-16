using System.Collections.Generic;
using LibraryApp.Application.ViewModels;

namespace LibraryApp.Application.Interfaces
{
    public interface IBookAppService
    {
        void Create(BookViewModel book);

        void Delete(int bookId);

        IEnumerable<BookViewModel> GetAll();

        IEnumerable<BookViewModel> GetByAuthor(string author);

        BookViewModel GetById(int bookId);

        IEnumerable<BookViewModel> GetByTitle(string title);

        void Update(BookViewModel book);
    }
}