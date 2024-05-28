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
    public class DeleteShoppingHandler : IRequestHandler<DeleteShoppingCommand, ShoppingDto>
    {
        private readonly IRepository<Shopping> shoppingRepository;
        private readonly IMapper mapper;

        public DeleteShoppingHandler(IRepository<Shopping> shoppingRepository, IMapper mapper)
        {
            this.shoppingRepository = shoppingRepository ?? throw new ArgumentNullException(nameof(shoppingRepository));
            this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<ShoppingDto> Handle(DeleteShoppingCommand request, CancellationToken cancellationToken)
        {
            IEnumerable<Shopping> shopping = await this.shoppingRepository.GetAllAsync();
            Shopping shoppingToDelete = shopping.FirstOrDefault(shopping => shopping.Name == request.shoppingName);

            if (shoppingToDelete == null)
            {
                throw new ArgumentNullException(nameof(shoppingToDelete));
            }

            return this.mapper.Map<ShoppingDto>(await this.shoppingRepository.DeleteAsync(shoppingToDelete));
        }
    }
}
