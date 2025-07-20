using AutoMapper;
using TripPlaning.API.DTO;
using TripPlaning.Core.DTO;
using TripPlaning.Core.Model;

namespace TripPlaning.API.Mapping
{
    public class SignInMapping : Profile
    {
        public SignInMapping()
        {
            CreateMap<User, SignInModel>().ReverseMap();
        }
    }
}
