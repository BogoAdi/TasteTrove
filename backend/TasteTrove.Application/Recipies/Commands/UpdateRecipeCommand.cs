using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TasteTrove.Domain;

namespace TasteTrove.Application.Recipies.Commands
{
    public class UpdateRecipeCommand : IRequest<Recipe?>
    {
        public Recipe Recipe { get; set; }
        public UpdateRecipeCommand(Recipe recipe)
        {
            Recipe = recipe;
        }
    }
}
