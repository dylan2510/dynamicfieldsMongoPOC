using DynamicFormApi.Models;
using MongoDB.Driver;

namespace DynamicFormApi.Repositories;

public class FieldDefinitionRepository : IMongoRepository<FieldDefinition>
{
    private readonly IMongoCollection<FieldDefinition> _collection;

    public FieldDefinitionRepository(IMongoDatabase database)
    {
        _collection = database.GetCollection<FieldDefinition>("field_definitions");
    }

    public Task<List<FieldDefinition>> GetAllAsync() =>
        _collection.Find(_ => true).ToListAsync();

    public Task<FieldDefinition?> GetByIdAsync(string id) =>
        _collection.Find(x => x.Id == id).FirstOrDefaultAsync();

    public Task CreateAsync(FieldDefinition entity) =>
        _collection.InsertOneAsync(entity);

    public Task UpdateAsync(string id, FieldDefinition entity) =>
        _collection.ReplaceOneAsync(x => x.Id == id, entity);

    public Task DeleteAsync(string id) =>
        _collection.DeleteOneAsync(x => x.Id == id);
}
