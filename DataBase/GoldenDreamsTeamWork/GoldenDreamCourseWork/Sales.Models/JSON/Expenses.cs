using System;
using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;

namespace Sales.Models.JSON
{
    public class Expenses
    {
        [BsonId]
        [JsonIgnore]
        public ObjectId Id { get; set; }

        public string Vendor { get; set; }

        public IList<KeyValuePair<DateTime, decimal>> List { get; set; }

        public Expenses()
        {
            this.List = new List<KeyValuePair<DateTime, decimal>>();
        }
    }
}
