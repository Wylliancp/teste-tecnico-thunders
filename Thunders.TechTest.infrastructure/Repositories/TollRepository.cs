using Microsoft.EntityFrameworkCore;
using Thunders.TechTest.Domain.Entities;
using Thunders.TechTest.Domain.Repositories;

namespace Thunders.TechTest.infrastructure.Repositories;

public class TollRepository : ITollRepository
{
    private readonly DefaultContext _context;

    public TollRepository(DefaultContext context)
    {
        _context = context;
    }

    public async Task<Toll?> CreateAsync(Toll? toll, CancellationToken cancellationToken = default)
    {
        await _context.Tolls.AddAsync(toll, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
        return toll;
    }
    public async Task<Toll?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return await _context.Tolls.FirstOrDefaultAsync(o=> o.Id == id, cancellationToken);
    }

    public async Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var toll = await GetByIdAsync(id, cancellationToken);
        if (toll == null)
            return false;

        _context.Tolls.Remove(toll);
        await _context.SaveChangesAsync(cancellationToken);
        return true;
    }

    public async Task<List<Toll>?> GetAllAsync(CancellationToken cancellationToken = default)
    {
        return (await _context.Tolls.AsQueryable().ToListAsync(cancellationToken))!;
    }

    public async Task<Toll?> UpdateAsync(Toll? toll, CancellationToken cancellationToken = default)
    {
        _context.Tolls.Update(toll);
        await _context.SaveChangesAsync(cancellationToken);
        return toll;
        }

    public async Task<decimal> TotalValueByState(string state, CancellationToken cancellationToken = default)
    {
        return await _context.Tolls.Where(x => x.State == state).SumAsync(x => x.County, cancellationToken: cancellationToken);
    }

    public async Task<Toll?> RankingBillingPlacesMonth(DateTime month, CancellationToken cancellationToken = default)
    {
        return await _context.Tolls.Where(x=> x.dateCreate.Month == month.Month).OrderByDescending(x=> x.County).FirstOrDefaultAsync(cancellationToken);
    }

    public async Task<int> QuantityVehiclesByPlaces(string places, CancellationToken cancellationToken = default)
    {
        return await _context.Tolls.Where(x => x.Place == places).CountAsync(cancellationToken);
    }
}
