using Thunders.TechTest.Domain.Queries;

namespace Thunders.TechTest.Application.Queries.Toll;

public class GetTotalValueByStateQuery : IQuery
{
    public string State { get; set; }
}

