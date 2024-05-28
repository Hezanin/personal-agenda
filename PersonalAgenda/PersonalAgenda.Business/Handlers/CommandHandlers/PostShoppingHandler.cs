using AutoMapper;
using MediatR;
using PersonalAgenda.Business.Commands;
using PersonalAgenda.Domain.Dtos;
using PersonalAgenda.Domain.Entities;
using PersonalAgenda.EFDataAccess.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalAgenda.Business.Handlers.CommandHandlers
{
    public class PostShoppingHandler : IRequestHandler<PostShoppingCommand, ShoppingDto>
    {
        private readonly IRepository<Shopping> shoppingRepository;
        private readonly IMapper mapper;

        public PostShoppingHandler(IRepository<Shopping> shoppingRepository, IMapper mapper)
        {
            this.shoppingRepository = shoppingRepository ?? throw new ArgumentNullException(nameof(shoppingRepository));
            this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<ShoppingDto> Handle(PostShoppingCommand request, CancellationToken cancellationToken)
        {
            if (request.Shopping == null)
            {
                throw new ArgumentNullException(nameof(request.Shopping));
            }

            return mapper.Map<ShoppingDto>(await this.shoppingRepository
                .AddAsync(this.mapper.Map<Shopping>(request.Shopping)));
        }
    }
}
