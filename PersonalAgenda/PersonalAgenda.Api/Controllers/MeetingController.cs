using MediatR;
using Microsoft.AspNetCore.Mvc;
using PersonalAgenda.Business.Queries;
using PersonalAgenda.Domain.Dtos;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PersonalAgenda.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MeetingController : ControllerBase
    {
        private readonly IMediator mediator;

        public MeetingController(IMediator mediator)
        {
            this.mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await mediator.Send(new GetMeetingsQuery()));
        }
            
        [HttpPost]
        public void Post([FromBody] MeetingDto value)
        {
        }

        [HttpDelete("{name}")]
        public void Delete(string name)
        {
        }
    }
}
