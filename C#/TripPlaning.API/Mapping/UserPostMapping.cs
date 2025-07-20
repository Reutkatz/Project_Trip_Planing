using AutoMapper;
using TripPlaning.API.DTO;
using TripPlaning.Core.Model;

namespace TripPlaning.API.Mapping
{

    public class UserPostMapping : Profile
    {
        public UserPostMapping()
        {
            //CreateMap<User, UserPostModel>().ReverseMap();
            CreateMap<UserPostModel, User>();
        }
    }
}
