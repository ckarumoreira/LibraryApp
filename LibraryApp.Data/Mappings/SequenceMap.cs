using LibraryApp.Data.Helper;
using MongoDB.Bson.Serialization;

namespace LibraryApp.Data.Mappings
{
    public class SequenceMap
    {
        public SequenceMap()
        {
            BsonClassMap.RegisterClassMap<Sequence>(m =>
            {
                m.MapIdProperty(s => s.Id)
                    .SetElementName("id");
                m.MapProperty(s => s.SequenceValue)
                    .SetElementName("sequence_value");
            });
        }
    }
}