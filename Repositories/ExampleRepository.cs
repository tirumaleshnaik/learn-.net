public interface IExampleRepository
{
    Task<List<ExampleModel>> GetAllAsync();
}

public class ExampleRepository : IExampleRepository
{
    private readonly ApplicationDbContext _context;

    public ExampleRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<ExampleModel>> GetAllAsync()
    {
        return await _context.Examples.ToListAsync();
    }
}
