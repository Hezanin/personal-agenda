using PersonalAgenda.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalAgenda.EFDataAccess.Repositories
{
    public class ShoppingRepository : Repository<Shopping>
    {
        public ShoppingRepository(PersonalAgendaContext personalAgendaContext) : base(personalAgendaContext)
        {
        }
    }
}
