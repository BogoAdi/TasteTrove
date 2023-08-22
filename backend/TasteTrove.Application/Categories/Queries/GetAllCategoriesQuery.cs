using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TasteTrove.Domain;

namespace TasteTrove.Application.Categories.Queries
{
    public class GetAllCategoriesQuery : IRequest<List<Category>>
    {
    }
}
