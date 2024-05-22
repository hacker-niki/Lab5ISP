namespace Senko_253505.Domain.Entities;

public sealed record Vehicle
{
    public string Model { get; set; }

    public int Year { get; set; }
    public int Horsepower { get; set; }
}
// Виды транспорта транспортной компании – автомобили
//  (обязательное свойство – дата прохождения техосмотра)