using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TasteTrove.Application.Recipies.Queries;
using TasteTrove.Domain;
using TasteTrove.Infrastructure;

namespace TasteTrove.Application.Recipies.QueryHandlers
{
    public class GetRecipeByNameQueryHandler : IRequestHandler<GetRecipeByNameQuery, List<Recipe>>
    {
        private readonly TasteTroveContext _context;
        public GetRecipeByNameQueryHandler(TasteTroveContext context)
        {
            _context = context;
        }

        public async Task<List<Recipe>> Handle(GetRecipeByNameQuery request, CancellationToken cancellationToken)
        {
            Expression<Func<Recipe, bool>> searchByNameExpression = r => r.Title.ToLower().Contains(request.Name.ToLower());
            var query = _context.Recipes.Include(x => x.User).Include(x => x.Category).Where(searchByNameExpression);
            return await query.ToListAsync(cancellationToken);
        }
    }
}
