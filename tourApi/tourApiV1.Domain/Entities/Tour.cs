using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace tourApiV1.Domain.Entities
{
    public class Tour
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }  

        [BsonElement("name")]
        [BsonRequired]

        public string Name { get; set; }

        [BsonElement("description")]
        public string Description { get; set; }

        [BsonElement("destination")]
        public string Destination { get; set; }

        [BsonElement("price")]
        [BsonRequired]

        public decimal Price { get; set; }

        [BsonElement("durationDays")]
        public int DurationDays { get; set; }

        [BsonElement("startTime")]
        public DateTime StartTime { get; set; }

        [BsonElement("availableSeats")]
        public int AvailableSeats { get; set; }

    }
}
