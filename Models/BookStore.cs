using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MongoCSharp_BookStore.model
{
    [BsonIgnoreExtraElements]
    public class BookStore
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        [BsonElement("isbn")]
        public string ISBN { get; set; } = null!;

        [BsonElement("bookTitle")]
        public string BookTitle { get; set; } = null!;

        [BsonElement("author")]
        public string Author { get; set; } = null!;

        [BsonElement("category")]
        public string Category { get; set; } = null!;

        [BsonElement("price")]
        public decimal Price { get; set; }

        [BsonIgnoreIfNull]
        [BsonElement("totalPages")]
        public int? TotalPages { get; set; }
    }
}