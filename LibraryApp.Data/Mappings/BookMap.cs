using LibraryApp.Domain.Models;
using MongoDB.Bson.Serialization;

namespace LibraryApp.Data.Mappings
{
    public class BookMap
    {
        public BookMap()
        {
            BsonClassMap.RegisterClassMap<Book>(m =>
            {
                m.MapIdProperty(book => book.Id)
                    .SetElementName("id");
                m.MapProperty(book => book.Title)
                    .SetElementName("title");
                m.MapProperty(book => book.Author)
                    .SetElementName("author");
                m.MapProperty(book => book.Loans)
                    .SetElementName("loans")
                    .SetIgnoreIfNull(true);
                m.SetIgnoreExtraElements(true);
            });
        }
    }
}