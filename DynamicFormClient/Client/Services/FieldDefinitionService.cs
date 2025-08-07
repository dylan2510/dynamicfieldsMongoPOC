using DynamicFormClient.Models;
using System.Net.Http.Json;
using System.Text.Json;

namespace DynamicFormClient.Services;

public class FieldDefinitionService
{
    private readonly HttpClient _http;

    public FieldDefinitionService(HttpClient http)
    {
        _http = http;
    }

    public async Task<List<FieldDefinition>> GetFieldDefinitionsAsync()
    {
        return await _http.GetFromJsonAsync<List<FieldDefinition>>("api/fielddefinitions") ?? new();
    }

    public async Task CreateFieldDefinitionAsync(FieldDefinition field)
    {
        // For debugging
        var json = JsonSerializer.Serialize(field);
        Console.WriteLine($"[Blazor] Payload: {json}");
        
        await _http.PostAsJsonAsync("api/fielddefinitions", field);
    }

}
