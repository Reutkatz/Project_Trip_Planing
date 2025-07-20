using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TripPlaning.Core.Model;

namespace TripPlaning.Core.Repositories
{
    public interface ITripRepository
    {
       public List<Trip> GetList();
        public void Delete(int id);
        public Trip GetById(int id);

        public void AddTrip(Trip trip);
        public void UpdateTrip(Trip trip);
    }
}
