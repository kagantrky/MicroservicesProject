using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace FreeCourse.Services.Catalog.Models
{
    public class Category
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)] //tipi bize hazır bir şekilde string dönecek. objectıd yazacak
        public string Id { get; set; }
        public string  Name { get; set; }
    }
}
