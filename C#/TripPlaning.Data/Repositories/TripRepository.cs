using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TripPlaning.Core.Model;
using TripPlaning.Core.Repositories;

namespace TripPlaning.Data.Repositories
{
    public class TripRepository:ITripRepository
    {
        private readonly DataContext _context;
        public TripRepository(DataContext context) {
            _context = context; 
        }
        public List<Trip> GetList()
        {
            return _context.Trips.ToList();
        }
        public void Delete(int id)
        {
            Trip t = GetById(id);
            _context.Trips.Remove(t);
            _context.SaveChanges();
        }
        public Trip GetById(int id)
        {
            int index = _context.Trips.ToList().FindIndex(x => x.Id == id);
            if (index == -1)
            {
                return null;
            }
            return _context.Trips.ToList()[index];
        }

        public void AddTrip(Trip trip)
        {
            _context.Trips.Add(trip);
            _context.SaveChanges(true);
        }
        public void UpdateTrip(Trip trip)
        {

            Trip t = GetById(trip.Id);
            if (t != null)
            {
                t.Date = trip.Date;
                t.Title = trip.Title;
                t.Budget = trip.Budget;
                //t.AgeRange = trip.AgeRange;
                //t.MaxParticipants = trip.MaxParticipants;
                t.Region = trip.Region;
                //t.Season = trip.Season;
                t.StartTime = trip.StartTime;
                t.EndTime = trip.EndTime;
                t.NumOfAttractions = trip.NumOfAttractions;
                t.NumOfTrails = trip.NumOfTrails;
                t.NumOfStoppingPlaces = trip.NumOfStoppingPlaces;
               
            }
            _context.SaveChanges(true);
        }
    }
}
