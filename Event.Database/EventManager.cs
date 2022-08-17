using Event.Domain.Infrastructure;
using Event.Domain.Models;
using Mapster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Event.Database
{
    public class EventManager : IEventManager
    {
        private readonly ApplicationDbContext _ctx;

        public EventManager(ApplicationDbContext ctx)
        {
            _ctx = ctx;
        }

        public Task<int> CreateEvent(ScheduleEvent scheduleEvent)
        {
            _ctx.SEvents.Add(scheduleEvent);

            return _ctx.SaveChangesAsync();
        }

        public Task<int> DeleteEvent(int id)
        {
            var eventById = _ctx.SEvents.FirstOrDefault(p => p.Id == id);

            _ctx.SEvents.Remove(eventById);

            return _ctx.SaveChangesAsync();
        }

        public TResult GetEventById<TResult>(int id, Func<ScheduleEvent, TResult> selector)
        {
            return _ctx.SEvents
                .Where(p => p.Id == id)
                .Select(selector)
                .FirstOrDefault();
        }

        public IEnumerable<ScheduleEvent> GetEvents()
        {
            return _ctx.SEvents;
        }

        public Task<int> UpdateEvent(ScheduleEvent scheduleEvent, ScheduleEvent newEvent)
        {
            newEvent.BuildAdapter()
               .EntityFromContext(_ctx)
               .AdaptTo(scheduleEvent);

            _ctx.SEvents.Update(scheduleEvent);

            return _ctx.SaveChangesAsync();
        }
    }
}
