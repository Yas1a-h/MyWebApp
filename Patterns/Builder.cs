public class ExampleModel
{
    public string Name { get; set; } = string.Empty;
    public int Age { get; set; }
}
    public class ExampleModelBuilder
    {
        private readonly ExampleModel _model = new();

        public ExampleModelBuilder WithName(string name)
        {
            _model.Name = name;
            return this;
        }

        public ExampleModelBuilder WithAge(int age)
        {
            _model.Age = age;
            return this;
        }

        public ExampleModel Build()
        {
            return _model;
        }
    }

    public class ExampleUsage
    {
        public void Run()
        {
            var builder = new ExampleModelBuilder();
            var model = builder.WithName("John Doe").WithAge(30).Build();

            Console.WriteLine($"Name: {model.Name}, Age: {model.Age}");
        }
    }

    public class Programs
    {
        public static void Main(string[] args)
        {
            var example = new ExampleUsage();
            example.Run();
        }
    }