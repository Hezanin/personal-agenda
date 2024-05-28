using MediatR;
using PersonalAgenda.Domain.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalAgenda.Business.Queries
{
    public record GetShoppingsQuery() : IRequest<IEnumerable<ShoppingDto>>;
}
