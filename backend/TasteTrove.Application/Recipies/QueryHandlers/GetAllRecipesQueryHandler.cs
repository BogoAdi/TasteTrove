using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TasteTrove.Application.Recipies.Queries;
using TasteTrove.Domain;
using TasteTrove.Infrastructure;

namespace TasteTrove.Application.Recipies.QueryHandlers
{
    public class GetAllRecipesQueryHandler : IRequestHandler<GetAllRecipesQuery, List<Recipe>>
    {
        private readonly TasteTroveContext _context;
        public GetAllRecipesQueryHandler(TasteTroveContext context)
        {
            _context = context;
        }

        public async Task<List<Recipe>> Handle(GetAllRecipesQuery request, CancellationToken cancellationToken)
        {
            var query = _context.Recipes.Include(x => x.User).Include(x => x.Category);
            return await query.ToListAsync(cancellationToken);
        }
    }
}
