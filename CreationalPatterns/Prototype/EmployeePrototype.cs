namespace CreationalPatterns.Prototype;

public interface IPrototype<T>
{
    T Clone();
}

public class Address
{
    public string Street { get; set; } = string.Empty;
    public string City { get; set; } = string.Empty;
    public string ZipCode { get; set; } = string.Empty;

    public Address Clone()
    {
        return new Address
        {
            Street = Street,
            City = City,
            ZipCode = ZipCode
        };
    }

    public override string ToString()
    {
        return $"{Street}, {City} {ZipCode}";
    }
}

public class Employee : IPrototype<Employee>
{
    public string Name { get; set; } = string.Empty;
    public string Department { get; set; } = string.Empty;
    public decimal Salary { get; set; }
    public Address Address { get; set; } = new();

    public Employee Clone()
    {
        return new Employee
        {
            Name = Name,
            Department = Department,
            Salary = Salary,
            Address = Address.Clone()
        };
    }

    public void DisplayInfo()
    {
        Console.WriteLine($"Name: {Name}");
        Console.WriteLine($"Department: {Department}");
        Console.WriteLine($"Salary: {Salary:C}");
        Console.WriteLine($"Address: {Address}");
    }
}

public class EmployeePrototypeRegistry
{
    private readonly Dictionary<string, Employee> _prototypes = new();

    public void RegisterPrototype(string key, Employee prototype)
    {
        _prototypes[key] = prototype;
    }

    public Employee? CreateEmployee(string key)
    {
        return _prototypes.TryGetValue(key, out var prototype) 
            ? prototype.Clone() 
            : null;
    }
}
