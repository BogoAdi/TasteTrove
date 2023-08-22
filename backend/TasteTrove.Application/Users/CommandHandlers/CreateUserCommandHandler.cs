using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TasteTrove.Application.Users.Commands;
using TasteTrove.Domain;
using TasteTrove.Infrastructure;

namespace TasteTrove.Application.Users.CommandHandlers
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, User>
    {
        private readonly TasteTroveContext _context;
        public CreateUserCommandHandler(TasteTroveContext context)
        {
            _context = context;
        }
        public async Task<User> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var newUser = new User
            {
                Id = Guid.NewGuid(),
                Email = request.User.Email,
                Name = request.User.Name,
                Recipes = new List<Recipe>()
            };
            _context.Users.Add(newUser);
            await _context.SaveChangesAsync(cancellationToken);

            return newUser;

        }
    }
}

