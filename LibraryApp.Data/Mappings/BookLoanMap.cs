using LibraryApp.Domain.Models;
using MongoDB.Bson.Serialization;

namespace LibraryApp.Data.Mappings
{
    public class BookLoanMap
    {
        public BookLoanMap()
        {
            BsonClassMap.RegisterClassMap<BookLoan>(m =>
            {
                m.MapProperty(loan => loan.User)
                    .SetElementName("user");
                m.MapProperty(loan => loan.Borrowed)
                    .SetElementName("borrowed");
                m.MapProperty(loan => loan.Returned)
                    .SetElementName("returned")
                    .SetIgnoreIfNull(true);
            });
        }
    }
}