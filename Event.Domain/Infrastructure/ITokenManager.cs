using Event.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Event.Domain.Infrastructure
{
    public interface ITokenManager
    {
        TResult GetUser<TResult>(string name, string password, Func<Users, TResult> selector);
    }
}
