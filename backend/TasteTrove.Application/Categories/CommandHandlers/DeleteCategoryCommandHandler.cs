using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TasteTrove.Application.Categories.Commands;
using TasteTrove.Infrastructure;

namespace TasteTrove.Application.Categories.CommandHandlers
{
    public class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommand, bool>
    {
        private readonly TasteTroveContext _context;
        public DeleteCategoryCommandHandler(TasteTroveContext context)
        {
            _context = context;
        }

        public async Task<bool> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
        {
            var found = await _context.Categories.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);
            if (found == null)
            {
                return false;
            }
            _context.Categories.Remove(found);
            await _context.SaveChangesAsync(cancellationToken);
            return true;
        }
    }
}
