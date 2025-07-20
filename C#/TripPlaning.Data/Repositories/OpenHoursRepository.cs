using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TripPlaning.Core.Model;
using TripPlaning.Core.Repositories;

namespace TripPlaning.Data.Repositories
{
    public class OpenHoursRepository : IOpenHoursRepository
    {
        private readonly DataContext _context;
        public OpenHoursRepository(DataContext context)
        {
            _context = context;
        }
        public List<OpeningHours> GetList()
        {
            return _context.OpeningHours.ToList();
        }
        public void Delete(int id)
        {
            OpeningHours t = GetById(id);
            _context.OpeningHours.Remove(t);
            _context.SaveChanges();
        }
        public OpeningHours GetById(int id)
        {
            int index = _context.OpeningHours.ToList().FindIndex(x => x.Id == id);
            if (index == -1)
            {
                return null;
            }
            return _context.OpeningHours.ToList()[index];
        }

        public OpeningHours AddOpeningHours(OpeningHours openingHours)
        {
            _context.OpeningHours.Add(openingHours);
            _context.SaveChanges(true);
            return openingHours;
        }
        public void UpdateOpeningHours(OpeningHours openingHours)
        {

            OpeningHours o = GetById(openingHours.Id);
            if (o != null)
            {
                o.Id = openingHours.Id;
                o.PlaceId = openingHours.PlaceId;
                o.Day = openingHours.Day;
                o.OpeningTime = openingHours.OpeningTime;
                o.ClosingTime = openingHours.ClosingTime;
                o.place = openingHours.place;

            }
            _context.SaveChanges(true);
        }
        public List<OpeningHours> addList(List<OpeningHours> openingHours)
        {
            List<OpeningHours> listRes = new List<OpeningHours>();
            foreach(OpeningHours openingHour in openingHours)
            {
                OpeningHours res=AddOpeningHours(openingHour);
                listRes.Add(res);
            }
            return listRes;
        }
    }
}



