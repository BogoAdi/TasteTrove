using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TasteTrove.Application.Recipies.Commands
{
    public class RemoveRecipeCommand : IRequest<bool>
    {
        public Guid Id { get; set; }
    }
}
