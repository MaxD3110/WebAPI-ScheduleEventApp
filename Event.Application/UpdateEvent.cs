using Event.Domain.Infrastructure;
using Event.Domain.Models;
using Mapster;
using System.Threading.Tasks;

namespace Event.Application
{
    [Service]
    public class UpdateEvent
    {
        private readonly IEventManager _eventManager;

        public UpdateEvent(IEventManager eventManager)
        {
            _eventManager = eventManager;
        }



        public async Task<ScheduleEvent> Do(Request request)
        {
            var OldEvent = _eventManager.GetEventById(request.Id, p => p);

            if (OldEvent == null)
                return null;

            var newEvent = request.Adapt<ScheduleEvent>();

            await _eventManager.UpdateEvent(OldEvent, newEvent);

            return newEvent;
        }

        public class Request : ScheduleEvent { }
    }
}
