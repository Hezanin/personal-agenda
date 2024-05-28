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
    public class MeetupController : ControllerBase
    {
        private readonly IMediator mediator;
        public MeetupController(IMediator mediator)
        {
            this.mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }
        // GET: api/<MeetupController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await this.mediator.Send(new GetMeetupsQuery()));
        }

        // POST api/<MeetupController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] MeetupDto value)
        {
            return Created("",await this.mediator.Send(new PostMeetupCommand(value)));
        }

        // DELETE api/<MeetupController>/name
        [HttpDelete("{name}")]
        public void Delete(string name)
        {
        }
    }
}
