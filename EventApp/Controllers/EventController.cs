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
            var existingEvent = await updateEvent.Do(request);

            if (existingEvent == null)
                return NotFound($"Cannot find event with id {request.Id}");

            return Ok(existingEvent);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEvent(int id, [FromServices] DeleteEvent deleteEvent) =>
            await deleteEvent.Do(id) <= 0 ? NotFound($"Cannot find event with id {id}") : Ok("Deleted!");

        [HttpGet("")]
        public IActionResult GetEvents([FromServices] GetEvents getEvents) => Ok(getEvents.Do());

        [HttpGet("{id}")]
        public IActionResult GetEvent(int id, [FromServices] GetEvent getEvent) 
        {
            var existingEvent = getEvent.Do(id);

            if (existingEvent == null)
                return NotFound($"Cannot find event with id {id}");

            return Ok(existingEvent);
        } 
    }
}
