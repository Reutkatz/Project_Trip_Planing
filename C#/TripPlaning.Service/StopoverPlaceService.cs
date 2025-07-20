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
    public class StopoverPlaceService : IStopoverPlaceService
    {
        private readonly IStopoverPlaceRepository _stopoverPlaceRepository;

        public StopoverPlaceService(IStopoverPlaceRepository stopoverPlaceRepository)
        {
            _stopoverPlaceRepository = stopoverPlaceRepository;
        }
        public List<StopoverPlace> GetList()
        {
            return _stopoverPlaceRepository.GetList();
        }
        public void Delete(int id)
        {
            _stopoverPlaceRepository.Delete(id);
        }
        public StopoverPlace GetById(int id)
        {
            return _stopoverPlaceRepository.GetById(id);
        }
        public StopoverPlace AddStopoverPlace(StopoverPlace stopoverPlace)
        {
            return _stopoverPlaceRepository.AddStopoverPlace(stopoverPlace);
        }
        public StopoverPlace UpdateStopoverPlace(StopoverPlace stopoverPlace)
        {
            return _stopoverPlaceRepository.UpdateStopoverPlace(stopoverPlace);
        }
        public StopoverPlace UpdateRate(int id, double rating)
        {
            return _stopoverPlaceRepository.UpdateRate(id, rating);
        }

    }
}
