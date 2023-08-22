using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TasteTrove.Domain;

namespace TasteTrove.Application.Users.Commands
{
    public class CreateUserCommand : IRequest<User>
    {
        public User User { get; set; }
        public CreateUserCommand(User user)
        {
            User = user;
        }
    }
}
