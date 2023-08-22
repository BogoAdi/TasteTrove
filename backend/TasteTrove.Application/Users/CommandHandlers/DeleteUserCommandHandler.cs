using MediatR;
using Microsoft.EntityFrameworkCore;
using TasteTrove.Application.Users.Commands;
using TasteTrove.Infrastructure;

namespace TasteTrove.Application.Users.CommandHandlers
{
    public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand, bool>
    {
        private readonly TasteTroveContext _context;
        public DeleteUserCommandHandler(TasteTroveContext context)
        {
            _context = context;
        }
        public async Task<bool> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            var found = await _context.Users.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);
            if (found == null) return false;

            _context.Users.Remove(found);
            await _context.SaveChangesAsync(cancellationToken);
            return true;
        }
    }
}