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
    public class TrailService : ITrailService
    {
        private readonly ITrailRepository _trailRepository;

        public TrailService(ITrailRepository trailRepository)
        {
            _trailRepository = trailRepository;
        }
        public List<Trail> GetList()
        {
            return _trailRepository.GetList();
        }
        public void Delete(int id)
        {
            _trailRepository.Delete(id);
        }
        public Trail GetById(int id)
        {
            return _trailRepository.GetById(id);
        }
        public Trail AddTrail(Trail trail)
        {
            return _trailRepository.AddTrail(trail);
        }
        public Trail UpdateTrail(Trail trail)
        {
            return _trailRepository.UpdateTrail(trail);
        }

        public Trail UpdateRate(int id, double rating)
        {
           return _trailRepository.UpdateRate(id, rating);
        }


    }
}