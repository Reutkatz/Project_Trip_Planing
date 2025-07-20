using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace TripPlaning.Core.Model
{
    public enum DayOfWeek
    {
        Sunday, Monday, Tuesday, Wednsday, Thursday, Friday, Suterday
    }
    public class OpeningHours
    {
        public int Id { get; set; }
        public DayOfWeek Day { get; set; }  // Enum to represent the day of the week
        public string OpeningTime { get; set; }  // Opening time (e.g., "9:00 AM")
        public string ClosingTime { get; set; }  // Closing time (e.g., "5:00 PM")
        public int? PlaceId { get; set; }  // Foreign Key to Attraction

        // Navigation property
        [JsonIgnore]
        [ForeignKey("PlaceId")]

        public Place? place { get; set; }
    }

}
