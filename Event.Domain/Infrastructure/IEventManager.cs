using Event.Domain.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Event.Domain.Infrastructure
{
    public interface IEventManager
    {
        Task<int> CreateEvent(ScheduleEvent scheduleEvent);

        Task<int> UpdateEvent(ScheduleEvent scheduleEvent, ScheduleEvent newEvent);

        Task<int> DeleteEvent(int id);

        TResult GetEventById<TResult>(int id, Func<ScheduleEvent, TResult> selector);

        IEnumerable<ScheduleEvent> GetEvents();
    }
}
