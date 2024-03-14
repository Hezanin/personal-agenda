using Microsoft.EntityFrameworkCore;
using PersonalAgenda.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalAgenda.EFDataAccess.Repositories
{
    public abstract class Repository<T> : IRepository<IEntity> where T : class, IEntity
    {
        protected readonly PersonalAgendaContext personalAgendaContext;

        public Repository(PersonalAgendaContext personalAgendaContext)
        {
            this.personalAgendaContext = personalAgendaContext ??
                throw new ArgumentNullException(nameof(personalAgendaContext));
        }

        public async Task<IEntity> AddAsync(IEntity errand)
        {
            if (errand == null)
            {
                throw new ArgumentNullException(nameof(errand));
            }

            await this.personalAgendaContext.Set<IEntity>().AddAsync(errand);
            await this.personalAgendaContext.SaveChangesAsync();

            return errand;
        }

        public Task<IQueryable<IEntity>> GetAllAsync()
        {
            return Task.FromResult(this.personalAgendaContext.Set<IEntity>().AsNoTracking().AsQueryable());
        }

        public async Task<IEntity> GetByIdAsync(Guid Id)
        {
            return await this.personalAgendaContext.Set<IEntity>().FindAsync(Id);
        }
         
        public async Task<IEntity> UpdateAsync(IEntity errand)
        {
            if (errand == null)
            {
                throw new ArgumentNullException(nameof(errand));
            }

            this.personalAgendaContext.Set<IEntity>().Update(errand);
            await personalAgendaContext.SaveChangesAsync();

            return errand;
        }

        public async Task DeleteAsync(IEntity errand)
        {
            if (errand == null)
            {
                throw new ArgumentNullException(nameof(errand));
            }

            this.personalAgendaContext.Set<IEntity>().Remove(errand);
            await this.personalAgendaContext.SaveChangesAsync();
        }
    }
}
