using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TasteTrove.Domain;

namespace TasteTrove.Application.Categories.Commands
{
    public class CreateCategoryCommand : IRequest<Category>
    {
        public Category Category { get; set; }
        public CreateCategoryCommand(Category category)
        {
                Category = category;
        }
    }
}
