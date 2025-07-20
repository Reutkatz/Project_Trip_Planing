using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace TripPlaning.Core.Model
{
    public abstract class Place
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public double Rating { get; set; }
        public int ReviewsCount { get; set; }
        public double Price { get; set; }

        public string Website { get; set; }
        public IsraelRegion Region { get; set; }

        public List<OpeningHours> OpeningHours { get; set; }=new List<OpeningHours>();

    }
}
