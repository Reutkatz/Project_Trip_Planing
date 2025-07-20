using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TripPlaning.Core.Model;
using TripPlaning.Core.Repositories;
using TripPlaning.Core.Service;

namespace TripPlaning.Service
{
    public class OpenHoursService : IOpenHoursService
    {
        private readonly IOpenHoursRepository _openHoursRepository;

        public OpenHoursService(IOpenHoursRepository openHoursRepository)
        {
            _openHoursRepository = openHoursRepository;
        }
        public List<OpeningHours> GetList()
        {
            return _openHoursRepository.GetList();
        }
        public void Delete(int id)
        {
            _openHoursRepository.Delete(id);
        }
        public OpeningHours GetById(int id)
        {
            return _openHoursRepository.GetById(id);
        }
        public OpeningHours AddOpeningHours(OpeningHours openingHours)
        {
            return _openHoursRepository.AddOpeningHours(openingHours);
        }
        public void UpdateOpeningHours(OpeningHours openingHours)
        {
            _openHoursRepository.UpdateOpeningHours(openingHours);
        }
        public List<OpeningHours> addList(List<OpeningHours> openingHours)
        {
            return _openHoursRepository.addList(openingHours);
        }

    }
}
