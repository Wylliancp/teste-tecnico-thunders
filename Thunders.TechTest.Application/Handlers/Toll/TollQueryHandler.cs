using Microsoft.EntityFrameworkCore.Update;
using QuestPDF.Fluent;
using Thunders.TechTest.Application.Queries;
using Thunders.TechTest.Application.Queries.Toll;
using Thunders.TechTest.Domain.Handlers;
using Thunders.TechTest.Domain.Queries;
using Thunders.TechTest.Domain.Repositories;
using Thunders.TechTest.infrastructure.Reports;

namespace Thunders.TechTest.Application.Handlers.Toll;

public class TollQueryHandler(ITollRepository tollRepository)
    : IQueryHandler<GetByIdTollQuery>, IQueryHandler<GetAllTollQuery>, IQueryHandler<GetQuantityVehiclesByPlacesQuery>,
        IQueryHandler<GetRankingBillingPlacesMonthQuery>, IQueryHandler<GetTotalValueByStateQuery>
{
    public async Task<IQueryResult> Handle(GetByIdTollQuery query)
    {
        var result = await tollRepository.GetByIdAsync(query.Id);
        return new GenericResultQuery(true, result);
    }

    public async Task<IQueryResult> Handle(GetAllTollQuery query)
    {
        var result = await tollRepository.GetAllAsync();
        if (result != null) return new GenericResultQuery(true, result);
        return new GenericResultQuery(false, null);
    }

    public async Task<IQueryResult> Handle(GetQuantityVehiclesByPlacesQuery query)
    {
        var result = await tollRepository.QuantityVehiclesByPlaces(query.Places);
        var report = new QuantityVehiclesByPlacesReport(result, query.Places);
        return new GenericResultQuery(true, result, report.GeneratePdf());    
    }

    public async Task<IQueryResult> Handle(GetRankingBillingPlacesMonthQuery query)
    {
        var result = await tollRepository.RankingBillingPlacesMonth(query.Month);
        var report = new RankingBillingPlacesMonthReport(result);
        return new GenericResultQuery(true, result, report.GeneratePdf());
    }

    public async Task<IQueryResult> Handle(GetTotalValueByStateQuery query)
    {
        var result = await tollRepository.TotalValueByState(query.State);
        var report = new TotalValueByStateReport(result, query.State);

        return new GenericResultQuery(true, result, report.GeneratePdf());
    }
}
