using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class ExampleController : ControllerBase
{
    private readonly ExampleService _exampleService;

    public ExampleController(ExampleService exampleService)
    {
        _exampleService = exampleService;
    }

    // GET api/example
    [HttpGet]
    public IActionResult GetAllExamples()
    {
        var examples = _exampleService.GetAllExamples();
        if (examples == null || !examples.Any())
        {
            return NotFound(new { Message = "No examples found" });
        }

        return Ok(examples);
    }

    // GET api/example/5
    [HttpGet("{id}")]
    public IActionResult GetExampleById(int id)
    {
        var example = _exampleService.GetExampleById(id);
        if (example == null)
        {
            return NotFound(new { Message = $"Example with ID {id} not found" });
        }

        return Ok(example);
    }

    // POST api/example
    [HttpPost]
    public IActionResult CreateExample([FromBody] ExampleModel example)
    {
        if (example == null || string.IsNullOrEmpty(example.Name) || string.IsNullOrEmpty(example.Description))
        {
            return BadRequest(new { Message = "Invalid input data" });
        }

        _exampleService.AddExample(example);

        return CreatedAtAction(nameof(GetExampleById), new { id = example.Id }, example);
    }
}
