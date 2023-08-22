using MediatR;
using Microsoft.EntityFrameworkCore;
using TasteTrove.Application.Recipies.Commands;
using TasteTrove.Domain;
using TasteTrove.Infrastructure;

namespace TasteTrove.Application.Recipies.CommandHandlers
{
    public class UpdateRecipeCommandHandler : IRequestHandler<UpdateRecipeCommand, Recipe?>
    {
        private readonly TasteTroveContext _context;
        public UpdateRecipeCommandHandler(TasteTroveContext context)
        {
            _context = context;
        }
        public async Task<Recipe?> Handle(UpdateRecipeCommand request, CancellationToken cancellationToken)
        {
            if (request.Recipe.CategoryId != Guid.Empty)
            {
                var categoryExists = await _context.Categories.AnyAsync(x => x.Id == request.Recipe.CategoryId, cancellationToken);
                if (categoryExists is false) return null;
            }

            var found = await _context.Recipes.Include(x => x.User).Include(x => x.Category).FirstOrDefaultAsync(x => x.Id == request.Recipe.Id, cancellationToken);

            if (found == null) return null;

            if (!string.IsNullOrEmpty(request.Recipe.Title) && request.Recipe.Title != found.Title)
            {
                found.Title = request.Recipe.Title;
            }
            if (!string.IsNullOrEmpty(request.Recipe.Description) && request.Recipe.Description != found.Description)
            {
                found.Description = request.Recipe.Description;
            }
            if (request.Recipe.CategoryId != Guid.Empty && request.Recipe.CategoryId != found.CategoryId)
            {
                found.CategoryId = request.Recipe.CategoryId;
            }
            await _context.SaveChangesAsync(cancellationToken);
            return found;
        }
    }
}
