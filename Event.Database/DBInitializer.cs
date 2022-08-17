using Event.Domain.Infrastructure;
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

            if (!_ctx.JwtUsers.Any())
            {
                _ctx.JwtUsers.Add(new Domain.Models.Users
                {
                    Name = "admin",
                    Password = "admin"
                });

                _ctx.SaveChangesAsync();
            }
        }
    }
}
