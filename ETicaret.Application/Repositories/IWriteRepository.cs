using ETicaretAPI.Domain.Entities.Common;

namespace ETicaretAPI.Application.Repositories
{
    public interface IWriteRepository<T> : IRepository<T> where T : BaseEntity<Guid>
    {
        Task<bool> AddAsync(T model);
        Task<bool> AddRangeAsync(List<T> model);
        bool Remove(T model);
        Task<bool> RemoveAsync(Guid id);
        bool RemoveRangeAsync(List<T> datas);
        bool Update(T model);
        bool UpdateRange(List<T> model);
        Task<int> SaveAsync();
    }
}
