using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TasteTrove.Application.Categories.Commands;
using TasteTrove.Domain;
using TasteTrove.Infrastructure;

namespace TasteTrove.Application.Categories.CommandHandlers
{
    public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, Category>
    {
        private readonly TasteTroveContext _context;
        public CreateCategoryCommandHandler(TasteTroveContext context)
        {
            _context = context;
        }
        public async Task<Category> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            var newCategory = new Category
            {
                Description = request.Category.Description,
                Id = Guid.NewGuid(),
                Name = request.Category.Name,
                Recipies = new List<Recipe>()
            };
            _context.Categories.Add(newCategory);
            await _context.SaveChangesAsync(cancellationToken);

            return newCategory;
        }
    }
}
