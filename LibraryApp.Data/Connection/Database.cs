using LibraryApp.Data.Helper;
using LibraryApp.Domain.Models;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

namespace LibraryApp.Data.Connection
{
    public class Database
    {
        private IConfiguration _config;
        private IMongoDatabase _database;

        public Database(IConfiguration config)
        {
            _config = config;
            Configure();
        }

        public IMongoCollection<Book> Books { get { return _database.GetCollection<Book>("books"); } }
        internal IMongoCollection<Sequence> Sequence { get { return _database.GetCollection<Sequence>("sequences"); } }

        public TResult RunCommand<TResult>(Command<TResult> command)
        {
            return _database.RunCommand(command);
        }

        private void Configure()
        {
            var client = new MongoClient(_config.GetConnectionString("nosqldb"));
            _database = client.GetDatabase("library");
        }
    }
}