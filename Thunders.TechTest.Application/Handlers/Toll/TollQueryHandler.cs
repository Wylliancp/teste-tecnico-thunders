using Thunders.TechTest.Application.Queries;
using Thunders.TechTest.Application.Queries.Toll;
using Thunders.TechTest.Domain.Handlers;
using Thunders.TechTest.Domain.Queries;
using Thunders.TechTest.Domain.Repositories;

namespace Thunders.TechTest.Application.Handlers.Toll;

public class TollQueryHandler(ITollRepository tollRepository)
    : IQueryHandler<GetByIdTollQuery>, IQueryHandler<GetAllTollQuery>
{
    public async Task<IQueryResult> Handle(GetByIdTollQuery query)
    {
        var result = await tollRepository.GetByIdAsync(query.Id);
        return new GenericResultQuery(true, result);
    }

    public async Task<IQueryResult> Handle(GetAllTollQuery query)
    {
        var result = await tollRepository.GetAllAsync();
        return new GenericResultQuery(true, result);
    }
}
