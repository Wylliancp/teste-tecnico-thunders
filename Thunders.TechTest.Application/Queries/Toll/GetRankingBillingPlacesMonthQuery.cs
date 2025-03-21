using Thunders.TechTest.Domain.Queries;

namespace Thunders.TechTest.Application.Queries.Toll;

public class GetRankingBillingPlacesMonthQuery : IQuery
{
    public DateTime Month { get; set; }
}

