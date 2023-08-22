using MediatR;
using Microsoft.EntityFrameworkCore;
using TasteTrove.Application.Recipies.Commands;
using TasteTrove.Infrastructure;

namespace TasteTrove.Application.Recipies.CommandHandlers
{
    public class RemoveRecipeCommandHandler : IRequestHandler<RemoveRecipeCommand, bool>
    {
        private readonly TasteTroveContext _context;
        public RemoveRecipeCommandHandler(TasteTroveContext context)
        {
            _context = context;
        }

        public async Task<bool> Handle(RemoveRecipeCommand request, CancellationToken cancellationToken)
        {
            var found = await _context.Recipes.FirstOrDefaultAsync(x => x.Id == request.Id,cancellationToken);
            if (found == null) return false;
            _context.Recipes.Remove(found);
            await _context.SaveChangesAsync(cancellationToken);
            return true;
        }
    }
}
