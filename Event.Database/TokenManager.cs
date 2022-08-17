using Event.Domain.Infrastructure;
using Event.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Event.Database
{
    public class TokenManager : ITokenManager
    {
        private readonly ApplicationDbContext _ctx;

        public TokenManager(ApplicationDbContext ctx)
        {
            _ctx = ctx;
        }

        public TResult GetUser<TResult>(string name, string password, Func<Users, TResult> selector)
        {
            return _ctx.JwtUsers
                .Where(n => n.Name == name && n.Password == password)
                .Select(selector)
                .FirstOrDefault();
        }
    }
}
