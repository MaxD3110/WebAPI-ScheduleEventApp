using Event.Domain.Infrastructure;
using System.Threading.Tasks;

namespace Event.Application
{
    [Service]
    public class DeleteEvent
    {
        private readonly IEventManager _eventManager;

        public DeleteEvent(IEventManager eventManager)
        {
            _eventManager = eventManager;
        }

        public Task<int> Do(int id)
        {
            return _eventManager.DeleteEvent(id);
        }
    }
}
