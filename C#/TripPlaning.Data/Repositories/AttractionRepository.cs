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
    public class AttractionRepository: IAttractionRepository
    {
        private readonly DataContext _context;
        public AttractionRepository(DataContext context) { _context = context; }
        public List<Attraction> GetList()
        {
            return _context.Attractions.Include(a => a.OpeningHours).ToList();
        }
        public void Delete(int id)
        {
            Attraction a = GetById(id);
            _context.Attractions.Remove(a);
            _context.SaveChanges();
        }
        public Attraction GetById(int id)
        {
            int index = _context.Attractions.ToList().FindIndex(x => x.Id == id);
            if (index == -1)
            {
                return null;
            }
            return _context.Attractions.ToList()[index];
        }

        public Attraction AddAttraction(Attraction attraction)
        {
            _context.Attractions.Add(attraction);
            _context.SaveChanges(true);
            return attraction;
        }
        public Attraction UpdateAttraction(Attraction attraction)
        {

            Attraction a = GetById(attraction.Id);
            if (a != null)
            {
                a.Name = attraction.Name;
               a.Address = attraction.Address;
                a.Rating = attraction.Rating;
                a.ReviewsCount = attraction.ReviewsCount;
                a.Price = attraction.Price;  
                a.OpeningHours = attraction.OpeningHours ?? new List<OpeningHours>();
                a.Website = attraction.Website;
                a.Region = attraction.Region;
            }
            _context.SaveChanges(true);
            return a;
        }

        public Attraction UpdateRate(int id, double rating)
        {
            Attraction a = GetById(id);
            double totalRate = a.ReviewsCount * a.Rating + rating;
            a.ReviewsCount += 1;
            a.Rating = totalRate / a.ReviewsCount;
            _context.SaveChanges(true);
            return a;
        }

    }
}

