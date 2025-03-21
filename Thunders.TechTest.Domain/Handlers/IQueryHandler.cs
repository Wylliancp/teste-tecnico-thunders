using Thunders.TechTest.Domain.Queries;

namespace Thunders.TechTest.Domain.Handlers
{
    public interface IQueryHandler<T> where T : IQuery
    {
        Task<IQueryResult> Handle(T query);
    }
}
