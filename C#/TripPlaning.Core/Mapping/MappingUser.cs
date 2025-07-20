using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using TripPlaning.Core.DTO;
using TripPlaning.Core.Model;

namespace TripPlaning.Core.Mapping
{
    public class MappingUser: Profile
    {
        public MappingUser()
        {
            CreateMap<User, UserDto>().ReverseMap();
        }
    }
}
