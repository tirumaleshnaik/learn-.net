public class ExampleController : ControllerBase
{
    [HttpGet]
    public IActionResult GetExample()
    {
        return Ok("Example response");
    }
}
