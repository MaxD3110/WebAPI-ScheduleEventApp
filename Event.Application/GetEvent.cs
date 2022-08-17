using Event.Domain.Infrastructure;
using Event.Domain.Models;
namespace Event.Application
{
    [Service]
    public class GetEvent
    {
        private readonly IEventManager _eventManager;

        public GetEvent(IEventManager eventManager)
        {
            _eventManager = eventManager;
        }

        public ScheduleEvent Do(int id)
        {
            return _eventManager.GetEventById(id, p => p);
        }
    }
}
