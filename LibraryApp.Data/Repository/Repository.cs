using LibraryApp.Data.Connection;
using LibraryApp.Domain.Interfaces;
using MongoDB.Driver;

namespace LibraryApp.Data.Repository
{
    public abstract class Repository<T> : IRepository<T>
    {
        protected Database _db;

        public Repository(Database db)
        {
            _db = db;
        }

        protected abstract IMongoCollection<T> Collection { get; }

        protected abstract int GetNextId();
    }
}