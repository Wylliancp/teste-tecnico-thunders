using Thunders.TechTest.Domain.Enums;

namespace Thunders.TechTest.Domain.Entities;

public class Toll
{
    public Toll(string place, string city, string state, decimal county, ETypeCar typeCar)
    {
        Id = Guid.NewGuid();
        dateCreate = DateTime.UtcNow;
        Place = place;
        City = city;
        State = state;
        County = county;
        TypeCar = typeCar;
    }
    
    // public Toll(){}
    public Guid Id { get; set; }
    public DateTime dateCreate { get; set; }
    public string Place { get; set; }
    public string City { get; set; }
    public string State { get; set; }
    public decimal County { get; set; }
    public ETypeCar TypeCar { get; set; }
    public DateTime DateUpdate { get; set; }

    
    public void Update(string place, string city, string state, decimal county, ETypeCar typeCar)
    {
        Place = place;
        City = city;
        State = state;
        County = county;
        TypeCar = typeCar;
        DateUpdate = DateTime.UtcNow;
    }
}