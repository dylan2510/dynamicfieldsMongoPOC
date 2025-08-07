using DynamicFormApi.Models;
using DynamicFormApi.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace DynamicFormApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class FieldDefinitionsController : ControllerBase
{
    private readonly IMongoRepository<FieldDefinition> _repository;

    public FieldDefinitionsController(IMongoRepository<FieldDefinition> repository)
    {
        _repository = repository;
    }

    // GET: api/FieldDefinitions
    [HttpGet]
    public async Task<ActionResult<IEnumerable<FieldDefinition>>> Get() =>
        await _repository.GetAllAsync();

    // POST: api/FieldDefinitions
    [HttpPost]
    public async Task<IActionResult> Post([FromBody] FieldDefinition field)
    {
        if (!ModelState.IsValid)
        {
            var errors = string.Join("; ", ModelState.Values
                .SelectMany(x => x.Errors)
                .Select(x => x.ErrorMessage));

            Console.WriteLine($"[Model Error] {errors}");
            return BadRequest(ModelState);
        }

        Console.WriteLine($"[API] Received field: {field.FieldKey}");
        await _repository.CreateAsync(field);
        return Ok();
    }
}
