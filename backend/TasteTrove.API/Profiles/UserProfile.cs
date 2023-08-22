using AutoMapper;
using TasteTrove.API.DTOs;
using TasteTrove.Application.Users.Commands;
using TasteTrove.Domain;

namespace TasteTrove.API.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<CreateUserDTO, User>()
                .ReverseMap();
        }

    }
}
