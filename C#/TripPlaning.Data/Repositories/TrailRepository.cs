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
    public class TrailRepository : ITrailRepository
    {
        private readonly DataContext _context;
        public TrailRepository(DataContext context) { _context = context; }

        public List<Trail> GetList()
        {
            return _context.Trails.Include(a => a.OpeningHours).ToList();
        }
        public void Delete(int id)
        {
            Trail t = GetById(id);
            _context.Trails.Remove(t);
            _context.SaveChanges();
        }
        public Trail GetById(int id)
        {
            int index = _context.Trails.ToList().FindIndex(x => x.Id == id);
            if (index == -1)
            {
                return null;
            }
            return _context.Trails.ToList()[index];
        }

        public Trail AddTrail(Trail trail)
        {
            _context.Trails.Add(trail);
            _context.SaveChanges(true);
            return trail;
        }
        public Trail UpdateTrail(Trail trail)
        {

            Trail t = GetById(trail.Id);
            if (t != null)
            {
                t.Name = trail.Name;
                t.Address = trail.Address;
                t.Rating = trail.Rating;
                t.ReviewsCount = trail.ReviewsCount;
                t.Price = trail.Price;
                t.OpeningHours = trail.OpeningHours ?? new List<OpeningHours>();
                t.Website = trail.Website;
                t.Region = trail.Region;
            }
            _context.SaveChanges(true);
            return t;
        }

        public Trail UpdateRate(int id, double rating) { 
            Trail t= GetById(id);
            double totalRate =t.ReviewsCount*t.Rating +rating;
            t.ReviewsCount +=1;
            t.Rating = totalRate/t.ReviewsCount;
            _context.SaveChanges(true);
            return t;
        }


    }



}
