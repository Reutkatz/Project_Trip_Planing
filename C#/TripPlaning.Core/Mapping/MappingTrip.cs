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
    public class MappingTrip: Profile
    {
        public MappingTrip() {
            CreateMap<Trip, TripDTO>().ReverseMap();
        }
    }
}
