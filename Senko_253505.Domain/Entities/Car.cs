namespace Senko_253505.Domain.Entities;

public class Car : Entity
{
    public Car()
    {
    }

    public Car(Vehicle characteristic, int transportCompanyId)
    {
        Characteristic = characteristic;
        Date = DateOnly.FromDateTime(DateTime.Today);
        TransportCompanyId = transportCompanyId;
    }

    public Car(Vehicle characteristic, DateOnly date, int transportCompany)
    {
        Characteristic = characteristic;
        Date = date;
        TransportCompanyId = transportCompany;
    }

    public string Name { get; set; }

    public DateOnly Date { get; set; }

    public Vehicle Characteristic { get; set; }

    public int TransportCompanyId { get; set; }

    public void UpdateDate(DateOnly date)
    {
        Date = date;
    }

    public void BoostHorsepower(int horsepower)
    {
        if (horsepower <= 0)
            return;
        Characteristic.Horsepower = horsepower;
    }
}