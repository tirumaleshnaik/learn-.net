public interface IExampleService
{
    string GetExampleData();
}

public class ExampleService : IExampleService
{
    public string GetExampleData() => "Example data from service";
}
