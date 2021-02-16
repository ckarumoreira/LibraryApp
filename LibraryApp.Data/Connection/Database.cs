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
            MongoCredential credential = MongoCredential.CreateCredential("admin", "root", "root");
            var settings = new MongoClientSettings
            {
                Credential = credential,
                Server = new MongoServerAddress("mongodb", 27017)
            };
            var client = new MongoClient(settings);
            _database = client.GetDatabase("library");
        }
    }
}