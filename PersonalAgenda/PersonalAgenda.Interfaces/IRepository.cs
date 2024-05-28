using PersonalAgenda.Interfaces;

namespace PersonalAgenda.EFDataAccess.Repositories
{
    public interface IRepository<IEntity> where IEntity : class
    {
        public Task<IEntity> AddAsync(IEntity errand);

        public Task<IEntity> DeleteAsync(IEntity errand);

        public Task<IQueryable<IEntity>> GetAllAsync();

        public Task<IEntity> GetByIdAsync(Guid Id);

        public Task<IEntity> UpdateAsync(IEntity errand);
    }
}