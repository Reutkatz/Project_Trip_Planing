using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TripPlaning.Core.Model;

namespace TripPlaning.Core.DTO
{
    public class TripDTO
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string Title { get; set; }
        public int Budget { get; set; }
        //public Age AgeRange { get; set; }
        //public int MaxParticipants { get; set; }
        public IsraelRegion Area { get; set; }
        //public Season Season { get; set; }
        public TimeOnly StartTime { get; set; }
        public TimeOnly EndTime { get; set; }
        public int NumOfAttractions { get; set; }
        public int NumOfTrails { get; set; }
        public int NumOfStoppingPlaces { get; set; }
       
    }
}
