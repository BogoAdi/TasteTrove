using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TasteTrove.Domain;

namespace TasteTrove.Application.Recipies.Queries
{
    public class GetRecipeByNameQuery : IRequest<List<Recipe>>
    {
        public string Name { get; set; }
        public GetRecipeByNameQuery(string name)
        {
            Name = name;
        }
    }
}
