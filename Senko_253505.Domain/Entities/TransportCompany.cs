namespace Senko_253505.Domain.Entities;

public class TransportCompany : Entity
{
    private readonly List<Car> _cars = new();

    public TransportCompany()
    {
    }

    public TransportCompany(string name, string owner)
    {
        Name = name;
        Owner = owner;
    }

    public string Name { get;  set; }
    public string Owner { get;  set; }

    public IReadOnlyList<Car> Cars => _cars.AsReadOnly();
}