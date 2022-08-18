using Event.Domain.Infrastructure;
using Event.Domain.Models;
using Mapster;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace Event.Application
{
    [Service]
    public class CreateEvent
    {
        private readonly IEventManager _eventManager;

        public CreateEvent(IEventManager eventManager)
        {
            _eventManager = eventManager;
        }

        

    public async Task<ScheduleEvent> Do(Request request)
        {
            var newEvent = request.Adapt<ScheduleEvent>();

            await _eventManager.CreateEvent(newEvent);

            return newEvent;
        }

        public class Request
        {
            [Required]
            public string Topic { get; set; }

            public string Details { get; set; }

            public string Speaker { get; set; }

            [Required]
            public string WhereNWnen { get; set; }
        };
    }
}
