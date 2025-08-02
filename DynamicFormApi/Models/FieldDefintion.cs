using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace DynamicFormApi.Models;

public class FieldDefinition
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; }

    public string FieldKey { get; set; }      // e.g. "Color"
    public string Label { get; set; }         // e.g. "Asset Color"
    public string Type { get; set; }          // e.g. "text", "number", "select"
    public bool Required { get; set; } = false;

    public string Section { get; set; }       // e.g. "Specifications"
    public List<string>? Options { get; set; } // for dropdown/select
}
