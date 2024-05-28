using MediatR;
using Microsoft.AspNetCore.Mvc;
using PersonalAgenda.Business.Commands;
using PersonalAgenda.Business.Queries;
using PersonalAgenda.Domain.Dtos;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PersonalAgenda.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShoppingController : ControllerBase
    {
        private readonly IMediator mediator;

        public ShoppingController(IMediator mediator)
        {
            this.mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        // GET: api/<ShoppingController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await this.mediator.Send(new GetShoppingsQuery()));
        }

        // POST api/<ShoppingController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ShoppingDto value)
        {
            return Created("",await this.mediator.Send(new PostShoppingCommand(value)));
        }

        // DELETE api/<ShoppingController>/name
        [HttpDelete("{name}")]
        public async Task<IActionResult> Delete(string name)
        {
            await this.mediator.Send(new DeleteShoppingCommand(name));
            return NoContent();
        }
    }
}
