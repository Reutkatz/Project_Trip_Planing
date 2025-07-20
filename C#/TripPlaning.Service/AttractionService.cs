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
    public class AttractionService :IAttractionService
    {
        private readonly IAttractionRepository _attractionRepository;

        public AttractionService(IAttractionRepository attractionRepository)
        {
            _attractionRepository = attractionRepository;
        }
        public List<Attraction> GetList()
        {
            return _attractionRepository.GetList();
        }
        public void Delete(int id)
        {
            _attractionRepository.Delete(id);
        }
        public Attraction GetById(int id)
        {
            return _attractionRepository.GetById(id);
        }
        public Attraction AddAttraction(Attraction attraction)
        {
            return _attractionRepository.AddAttraction(attraction);
        }
        public Attraction UpdateAttraction(Attraction attraction)
        {
            return _attractionRepository.UpdateAttraction(attraction);
        }
        public Attraction UpdateRate(int id, double rating)
        {
            return _attractionRepository.UpdateRate(id, rating);
        }

    }
}
