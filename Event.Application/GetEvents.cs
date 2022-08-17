using Event.Domain.Infrastructure;
using Event.Domain.Models;
using System.Collections.Generic;

namespace Event.Application
{
    [Service]
    public class GetEvents
    {
        private readonly IEventManager _eventManager;

        public GetEvents(IEventManager eventManager)
        {
            _eventManager = eventManager;
        }

        public IEnumerable<ScheduleEvent> Do() => _eventManager.GetEvents();
    }
}
