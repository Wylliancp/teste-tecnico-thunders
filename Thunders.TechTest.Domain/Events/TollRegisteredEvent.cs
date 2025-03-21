using Thunders.TechTest.Domain.Entities;
using Thunders.TechTest.Domain.Enums;

namespace Thunders.TechTest.Domain.Events
{
    public class TollRegisteredEvent
    {
        public TollRegisteredEvent(Guid id, string place, string city, string state, decimal county, ETypeCar typeCar)
        {
            Id = id;
            DateCreate = DateTime.Now;
            Place = place;
            City = city;
            State = state;
            County = county;
            TypeCar = typeCar;
        }

        public Guid Id { get; set; }
        public DateTime DateCreate { get; set; }
        public string Place { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public decimal County { get; set; }
        public ETypeCar TypeCar { get; set; }
        public string EventType => GetType().AssemblyQualifiedName;
        
    }
}
