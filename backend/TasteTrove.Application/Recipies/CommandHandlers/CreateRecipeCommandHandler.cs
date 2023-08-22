using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TasteTrove.Application.Recipies.Commands;
using TasteTrove.Domain;
using TasteTrove.Infrastructure;

namespace TasteTrove.Application.Recipies.CommandHandlers
{
    public class CreateRecipeCommandHandler : IRequestHandler<CreateRecipeCommand, Recipe>
    {
        private readonly TasteTroveContext _context;
        public CreateRecipeCommandHandler(TasteTroveContext context)
        {
            _context = context;
        }
        public async Task<Recipe> Handle(CreateRecipeCommand request, CancellationToken cancellationToken)
        {
            var recipe = new Recipe
            {
                Description = request.Recipe.Description,
                Id = Guid.NewGuid(),
                OwnerId = request.Recipe.OwnerId,
                Title = request.Recipe.Title,
                CategoryId = request.Recipe.CategoryId
            };
            _context.Recipes.Add(recipe);
            await _context.SaveChangesAsync(cancellationToken);
            return recipe;
        }
    }
}
