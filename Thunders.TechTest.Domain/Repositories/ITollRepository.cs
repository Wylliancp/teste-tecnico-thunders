using Thunders.TechTest.Domain.Entities;

namespace Thunders.TechTest.Domain.Repositories;

public interface ITollRepository
{
    Task<Toll?> CreateAsync(Toll? toll, CancellationToken cancellationToken = default);
    Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken = default);
    Task<Toll?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
    Task<List<Toll>?> GetAllAsync(CancellationToken cancellationToken = default);
    Task<Toll?> UpdateAsync(Toll? toll, CancellationToken cancellationToken = default);
    
    Task<decimal> TotalValueByState(string state, CancellationToken cancellationToken = default);
    Task<Toll?> RankingBillingPlacesMonth(DateTime month, CancellationToken cancellationToken = default);
    Task<int> QuantityVehiclesByPlaces(string places, CancellationToken cancellationToken = default);
}
