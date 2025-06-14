using Ardalis.Specification;

namespace RestFullApiForBank.Core.Application.Interfaces
{
    public interface IRepositoryAsync<T> : IRepositoryBase<T> where T : class
    { }
    public interface IReadRepository<T> : IReadRepositoryBase<T> where T : class
    { }
}
