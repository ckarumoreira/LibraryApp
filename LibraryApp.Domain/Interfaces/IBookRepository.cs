using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using LibraryApp.Domain.Models;

namespace LibraryApp.Domain.Interfaces
{
    public interface IBookRepository : IRepository<Book>
    {
        void Borrow(int bookId, string user);

        void Create(Book book);

        void Delete(int bookId);

        IEnumerable<Book> Get(Expression<Func<Book, bool>> predicate = null);

        void Return(int bookId, string user);

        void Update(Book book);
    }
}