using Event.Application;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace EventApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize ]
    public class EventController : Controller
    {
        [HttpPost("")]
        public async Task<IActionResult> CreateEvent([FromForm] CreateEvent.Request request,
            [FromServices] CreateEvent createEvent) => Ok(await createEvent.Do(request));

        [HttpPut("")]
        public async Task<IActionResult> UpdateEvent([FromForm] UpdateEvent.Request request,
            [FromServices] UpdateEvent updateEvent)
        {
            var correctEvent = await updateEvent.Do(request);

            if (correctEvent == null)
                return BadRequest($"Cannot find event with id {request.Id}");

            return Ok(correctEvent);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEvent(int id,
           [FromServices] DeleteEvent deleteEvent) => Ok(await deleteEvent.Do(id));

        [HttpGet("")]
        public IActionResult GetEvents([FromServices] GetEvents getEvents) => Ok(getEvents.Do());

        [HttpGet("{id}")]
        public IActionResult GetEvent(int id, [FromServices] GetEvent getEvent) => Ok(getEvent.Do(id));
    }
}
