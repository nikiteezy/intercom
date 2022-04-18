using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Intercom.Data.Models;

[BsonIgnoreExtraElements]
public class Intercom
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    [BsonElement("_id")]
    public string? Id { get; set; }

    [BsonElement("location_latitude")]
    public double? Latitude { get; set; }

    [BsonElement("location_longitude")]
    public double? Longitude { get; set; }

    [BsonElement("address_city")]
    public string? City { get; set; }

    [BsonElement("address_street")]
    public string? Street { get; set; }

    [BsonElement("address_house")]
    public int? House { get; set; }

    [BsonElement("address_entrance")]
    public int? Entrance { get; set; }

    [BsonElement("address_doorcode")]
    public string? Doorcode { get; set; }
}