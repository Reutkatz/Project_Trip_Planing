using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TripPlaning.Core.Model
{
    public enum IsraelRegion
    {
        North,         // גליל עליון ורמת הגולן
        LowerGalilee,  // גליל תחתון ועמק יזרעאל
        Haifa,         // חיפה והכרמל
        Sharon,        // השרון
        GushDan,       // גוש דן
        Jerusalem,     // השפלה וירושלים
        Negev,         // באר שבע והנגב
        Eilat          // אילת והערבה
    }

    public class Trip
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string Title { get; set; }
        public int Budget { get; set; }
        public IsraelRegion Region { get; set; }
        public TimeOnly StartTime { get; set; }
        public TimeOnly EndTime { get; set; }
        public int NumOfAttractions { get; set; }
        public int NumOfTrails {  get; set; }
        public int NumOfStoppingPlaces {  get; set; }
    }
}
