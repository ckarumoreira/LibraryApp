using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using LibraryApp.Data.Connection;
using LibraryApp.Data.Helper;
using LibraryApp.Domain.Interfaces;
using LibraryApp.Domain.Models;
using LibraryApp.Domain.Validations;
using MongoDB.Driver;

namespace LibraryApp.Data.Repository
{
    public class BookRepository : Repository<Book>, IBookRepository
    {
        public BookRepository(Database db)
            : base(db)
        {
        }

        protected override IMongoCollection<Book> Collection => _db.Books;

        public void Borrow(int bookId, string user)
        {
            var book = Get(x => x.Id == bookId).SingleOrDefault();

            var validator = new BorrowBookValidation();
            if (!validator.Validate(book))
            {
                throw new Exception("Invalid.");
            }

            var loan = new BookLoan()
            {
                User = user,
                Borrowed = DateTime.Now
            };

            Collection.UpdateOne(
                b => b.Id == bookId,
                Builders<Book>.Update
                    .Push(b => b.Loans, loan)
            );
        }

        public void Create(Book book)
        {
            var validator = new CreateBookValidation();
            if (!validator.Validate(book))
            {
                throw new Exception("Invalid.");
            }

            book.Id = GetNextId();
            Collection.InsertOne(book);
        }

        public void Delete(int bookId)
        {
            Collection.DeleteOne(b => b.Id == bookId);
        }

        public IEnumerable<Book> Get(Expression<Func<Book, bool>> predicate = null)
        {
            // Missing: aggregate to sortByCount.

            var query = Collection.Find(predicate ?? Builders<Book>.Filter.Empty);

            return query.ToList();
        }

        public void Return(int bookId, string user)
        {
            var book = Get(b => b.Id == bookId).SingleOrDefault();
            var validator = new ReturnBookValidation();
            if (!validator.Validate(book))
            {
                throw new Exception("Invalid.");
            }

            var loan = new BookLoan()
            {
                User = user,
                Borrowed = DateTime.Now
            };

            var filter = Builders<Book>.Filter;

            Collection.UpdateOne(
                Builders<Book>.Filter.And(
                    Builders<Book>.Filter.Eq(b => b.Id, bookId),
                    Builders<Book>.Filter.ElemMatch(b => b.Loans, l => l.User == user)
                ),
                Builders<Book>.Update
                    .Set(x => x.Loans[-1].Returned, DateTime.Now)
            );
        }

        public void Update(Book book)
        {
            var validator = new UpdateBookValidation();
            if (!validator.Validate(book))
            {
                throw new Exception("Invalid.");
            }

            var builder = Builders<Book>.Update;
            var updateDefinition = builder
                .Set(b => b.Author, book.Author)
                .Set(b => b.Title, book.Title);

            Collection.FindOneAndUpdate<Book>(x => x.Id == book.Id, updateDefinition, new FindOneAndUpdateOptions<Book, Book>() { IsUpsert = false });
        }

        protected override int GetNextId()
        {
            var result = _db.Sequence.FindOneAndUpdate<Sequence>(
                Builders<Sequence>.Filter.Eq(s => s.Id, "book_id"),
                Builders<Sequence>.Update.Inc(s => s.SequenceValue, 1),
                new FindOneAndUpdateOptions<Sequence, Sequence>()
                {
                    ReturnDocument = ReturnDocument.After,
                    IsUpsert = true
                });

            return result.SequenceValue;
        }
    }
}