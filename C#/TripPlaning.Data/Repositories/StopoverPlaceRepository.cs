using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TripPlaning.Core.Model;
using TripPlaning.Core.Repositories;

namespace TripPlaning.Data.Repositories
{
    public class StopoverPlaceRepository: IStopoverPlaceRepository
    {
        private readonly DataContext _context;
        public StopoverPlaceRepository(DataContext context) { _context = context; }

        public List<StopoverPlace> GetList()
        {
            return _context.StopoverPlaces.Include(a => a.OpeningHours).ToList();
        }
        public void Delete(int id)
        {
            StopoverPlace s = GetById(id);
            _context.StopoverPlaces.Remove(s);
            _context.SaveChanges();
        }
        public StopoverPlace GetById(int id)
        {
            int index = _context.StopoverPlaces.ToList().FindIndex(x => x.Id == id);
            if (index == -1)
            {
                return null;
            }
            return _context.StopoverPlaces.ToList()[index];
        }

        public StopoverPlace AddStopoverPlace(StopoverPlace stopoverPlace)
        {
            _context.StopoverPlaces.Add(stopoverPlace);
            _context.SaveChanges(true);
            return stopoverPlace;
        }
        public StopoverPlace UpdateStopoverPlace(StopoverPlace stopoverPlace)
        {

            StopoverPlace s = GetById(stopoverPlace.Id);
            if (s != null)
            {
                s.Name = stopoverPlace.Name;
                s.Address = stopoverPlace.Address;
                s.Rating = stopoverPlace.Rating;
                s.ReviewsCount = stopoverPlace.ReviewsCount;
                s.Price = stopoverPlace.Price;
                s.OpeningHours = stopoverPlace.OpeningHours ?? new List<OpeningHours>();
                s.Website = stopoverPlace.Website;
                s.Region = stopoverPlace.Region;
            }
            _context.SaveChanges(true);
            return s;
        }

        public StopoverPlace UpdateRate(int id, double rating)
        {
            StopoverPlace s = GetById(id);
            double totalRate = s.ReviewsCount * s.Rating + rating;
            s.ReviewsCount += 1;
            s.Rating = totalRate / s.ReviewsCount;
            _context.SaveChanges(true);
            return s;
        }

    }
}


