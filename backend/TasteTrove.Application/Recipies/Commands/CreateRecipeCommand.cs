using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TasteTrove.Domain;

namespace TasteTrove.Application.Recipies.Commands
{
    public class CreateRecipeCommand : IRequest<Recipe>
    {
        public Recipe Recipe { get; set; }
        public CreateRecipeCommand(Recipe recipe)
        {
            Recipe = recipe;
        }
    }
}
