using PersonalAgenda.Interfaces;

namespace PersonalAgenda.EFDataAccess.Repositories
{
    public interface IRepository<T>
    {
        public Task<T> AddAsync(T errand);

        public Task DeleteAsync(T errand);

        public Task<IQueryable<T>> GetAllAsync();

        public Task<T> GetByIdAsync(Guid Id);

        public Task<T> UpdateAsync(T errand);
    }
}