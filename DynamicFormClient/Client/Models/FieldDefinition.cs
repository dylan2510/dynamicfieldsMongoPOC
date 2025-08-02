namespace DynamicFormClient.Models;

public class FieldDefinition
{
    public string? Id { get; set; }
    public string FieldKey { get; set; }
    public string Label { get; set; }
    public string Type { get; set; } = "text";
    public bool Required { get; set; }
    public string? Section { get; set; }
    public List<string>? Options { get; set; }
}
