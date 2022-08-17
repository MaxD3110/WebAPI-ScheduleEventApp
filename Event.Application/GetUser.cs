using Event.Domain.Infrastructure;
using Event.Domain.Models;
using Mapster;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Event.Application
{
    [Service]
    public class GetUser
    {
        private readonly ITokenManager _tm;

        public GetUser(ITokenManager tokenManager)
        {
            _tm = tokenManager;
        }

        public Users Do(string name, string password)
        {
            var existingUser = _tm.GetUser(name, password, p => p);

            if (existingUser == null)
                return null;

            var request = new Request
            {
                Name = name,
                Password = password
            };

            var newUser = request.Adapt<Users>();

            return newUser;
        }

        public class Request
        {
            [Required]
            public string Name { get; set; }
            [Required]
            public string Password { get; set; }
        }
    }
}
