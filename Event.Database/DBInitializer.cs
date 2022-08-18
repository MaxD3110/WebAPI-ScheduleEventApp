using Event.Domain.Infrastructure;
using Event.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Event.Database
{
    public class DBInitializer : IDBInitializer
    {
        private readonly ApplicationDbContext _ctx;

        public DBInitializer(ApplicationDbContext ctx)
        {
            _ctx = ctx;
        }

        public void Initialize()
        {
            if (_ctx.Database.GetPendingMigrations().Any())
            {
                _ctx.Database.Migrate();
            }

            if (!_ctx.JwtUsers.Any() && !_ctx.SEvents.Any()) //Sample objects on first creation
            {
                _ctx.JwtUsers.Add(new Users
                {
                    Name = "admin",
                    Password = "admin"
                });

                _ctx.SEvents.Add(new ScheduleEvent
                {
                    Topic = "Sample topic",
                    Details = "Sample details",
                    Speaker = "Sample speaker",
                    WhereNWnen = "Sample time&place"
                });

                _ctx.SaveChangesAsync();
            }
        }
    }
}
