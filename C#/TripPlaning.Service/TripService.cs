using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TripPlaning.Core.Model;
using TripPlaning.Core.Repositories;
using TripPlaning.Core.Service;
using TripPlaning.Data.Repositories;

namespace TripPlaning.Service
{
    public class TripService : ITripService
    {
        private readonly ITripRepository _tripRepository;

        public TripService(ITripRepository tripRepository)
        {
            _tripRepository = tripRepository;
        }
        public List<Trip> GetList()
        {
            return _tripRepository.GetList();
        }
        public void Delete(int id)
        {
            _tripRepository.Delete(id);
        }
        public Trip GetById(int id)
        {
            return _tripRepository.GetById(id);
        }
        public void AddTrip(Trip trip)
        {
            _tripRepository.AddTrip(trip);
        }
        public void UpdateTrip(Trip trip)
        {
            _tripRepository.UpdateTrip(trip);
        }
    }
}
