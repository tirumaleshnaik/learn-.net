public class ExampleService
{
    private readonly ApplicationDbContext _context;

    public ExampleService(ApplicationDbContext context)
    {
        _context = context;
    }

    // Fetch all examples from the database
    public IEnumerable<ExampleModel> GetAllExamples()
    {
        return _context.Examples.ToList();
    }

    // Add a new example to the database
    public void AddExample(ExampleModel example)
    {
        _context.Examples.Add(example);
        _context.SaveChanges();
    }

    // Fetch an example by ID
    public ExampleModel GetExampleById(int id)
    {
        return _context.Examples.FirstOrDefault(e => e.Id == id);
    }
}
