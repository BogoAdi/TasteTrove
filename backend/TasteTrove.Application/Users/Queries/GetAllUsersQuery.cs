using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TasteTrove.Domain;

namespace TasteTrove.Application.Users.Queries
{
    public class GetAllUsersQuery : IRequest<List<User>>
    {
    }
}
