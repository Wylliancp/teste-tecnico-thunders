using Thunders.TechTest.Domain.Queries;

namespace Thunders.TechTest.Application.Queries.Toll;

public class GetQuantityVehiclesByPlacesQuery : IQuery
{
    public string Places { get; set; }
}

