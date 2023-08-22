using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TasteTrove.Application.Categories.Queries;
using TasteTrove.Domain;
using TasteTrove.Infrastructure;

namespace TasteTrove.Application.Categories.QueryHandlers
{
    public class GetAllCategoriesQueryHandler : IRequestHandler<GetAllCategoriesQuery, List<Category>>
    {
        private readonly TasteTroveContext _context;
        public GetAllCategoriesQueryHandler(TasteTroveContext context)
        {
            _context = context;
        }

        public async Task<List<Category>> Handle(GetAllCategoriesQuery request, CancellationToken cancellationToken)
        {
            var query = _context.Categories.Include(x => x.Recipies);
            return await query.ToListAsync(cancellationToken);
        }
    }
}
