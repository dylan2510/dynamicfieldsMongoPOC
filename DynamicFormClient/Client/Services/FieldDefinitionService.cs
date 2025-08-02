using DynamicFormClient.Models;
using System.Net.Http.Json;

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
}
