using Thunders.TechTest.Domain.Queries;

namespace Thunders.TechTest.Application.Queries.Toll;

public class GetByIdTollQuery : IQuery
{
    public Guid Id { get; set; }
}

