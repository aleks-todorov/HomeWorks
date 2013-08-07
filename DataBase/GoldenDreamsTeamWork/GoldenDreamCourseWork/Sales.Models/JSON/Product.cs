using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;

namespace Sales.Models.JSON
{
    public class Product
    {
        [BsonId]
        [JsonIgnore]
        public ObjectId Id { get; set; }

        public int ProductId { get; set; }

        public string ProductName { get; set; }

        public string VendorName { get; set; }

        public int TotalQuantitySold { get; set; }

        public decimal TotalIncomes { get; set; }
    }
}