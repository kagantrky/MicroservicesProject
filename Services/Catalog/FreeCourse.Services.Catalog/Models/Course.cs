using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System;

namespace FreeCourse.Services.Catalog.Models
{
    public class Course
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)] //tipi bize hazır bir şekilde string dönecek. objectıd yazacak
        public string Id { get; set; }
        public string Name{ get; set; }
        public string Description { get; set; } 

        [BsonRepresentation(BsonType.Decimal128)]
        public decimal Price { get; set; }
        public string UserId { get; set; }  //identity bize guid olanı string tutacak. random deger
        public string Picture { get; set; }

        [BsonRepresentation(BsonType.DateTime)]
        public DateTime CreatedTime { get; set; }

        public Feature Feature { get; set; }

        [BsonRepresentation(BsonType.ObjectId)]  //attribute neyin hangi işlevi olacağını gösterir.
        public string CategoryId { get; set; }

        [BsonIgnore] //mongodb'de collectionlara satır olarak yansıtırken bunu gözardı et. serialize etme gibi
        public Category Category { get; set; }  
    }
}
