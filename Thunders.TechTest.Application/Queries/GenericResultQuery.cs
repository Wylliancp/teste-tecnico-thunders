using Thunders.TechTest.Domain.Queries;

namespace Thunders.TechTest.Application.Queries
{
    public class GenericResultQuery(bool success, object data) : IQueryResult

    {
        public bool Success { get; private set; } = success;
       public object Data { get; private set; } = data;
    }
}