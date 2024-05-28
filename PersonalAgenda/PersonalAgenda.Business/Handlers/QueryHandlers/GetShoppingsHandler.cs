using AutoMapper;
using MediatR;
using PersonalAgenda.Business.Queries;
using PersonalAgenda.Domain.Dtos;
using PersonalAgenda.Domain.Entities;
using PersonalAgenda.EFDataAccess.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalAgenda.Business.Handlers.QueryHandlers
{
    public class GetShoppingsHandler : IRequestHandler<GetShoppingsQuery, IEnumerable<ShoppingDto>>
    {
        private readonly IRepository<Shopping> shoppingRepository;
        private readonly IMapper mapper;

        public GetShoppingsHandler(IRepository<Shopping> shoppingRepository, IMapper mapper)
        {
            this.shoppingRepository = shoppingRepository ?? throw new ArgumentNullException(nameof(shoppingRepository));
            this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<IEnumerable<ShoppingDto>> Handle(GetShoppingsQuery request, CancellationToken cancellationToken)
        {
            IEnumerable<ShoppingDto> shoppingDtos = mapper.Map<IEnumerable<ShoppingDto>>
                (await this.shoppingRepository.GetAllAsync());

            return shoppingDtos;
        }
    }
}
