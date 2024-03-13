using Microsoft.EntityFrameworkCore;
using PersonalAgenda.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalAgenda.EFDataAccess.Repositories
{
    public abstract class Repository<T> : IRepository<IErrand> where T : class, IErrand
    {
        protected readonly PersonalAgendaContext personalAgendaContext;

        public Repository(PersonalAgendaContext personalAgendaContext)
        {
            this.personalAgendaContext = personalAgendaContext ??
                throw new ArgumentNullException(nameof(personalAgendaContext));
        }

        public async Task<IErrand> AddAsync(IErrand errand)
        {
            if (errand == null)
            {
                throw new ArgumentNullException(nameof(errand));
            }

            await this.personalAgendaContext.Set<IErrand>().AddAsync(errand);
            await this.personalAgendaContext.SaveChangesAsync();

            return errand;
        }

        public Task<IQueryable<IErrand>> GetAllAsync()
        {
            return Task.FromResult(this.personalAgendaContext.Set<IErrand>().AsNoTracking().AsQueryable());
        }

        public async Task<IErrand> GetByIdAsync(Guid Id)
        {
            return (IErrand)Task.FromResult(this.personalAgendaContext.Set<IErrand>().FindAsync(Id));
        }

        public async Task<IErrand> UpdateAsync(IErrand errand)
        {
            if (errand == null)
            {
                throw new ArgumentNullException(nameof(errand));
            }

            this.personalAgendaContext.Set<IErrand>().Update(errand);
            await personalAgendaContext.SaveChangesAsync();

            return errand;
        }

        public async Task DeleteAsync(IErrand errand)
        {
            if (errand == null)
            {
                throw new ArgumentNullException(nameof(errand));
            }

            this.personalAgendaContext.Set<IErrand>().Remove(errand);
            await this.personalAgendaContext.SaveChangesAsync();
        }
    }
}
