using MediatR;
using PersonalAgenda.Domain.Dtos;
using PersonalAgenda.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalAgenda.Business.Commands
{
    public record PostShoppingCommand(ShoppingDto Shopping) : IRequest<ShoppingDto>;

}
