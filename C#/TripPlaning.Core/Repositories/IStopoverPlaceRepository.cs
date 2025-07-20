using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TripPlaning.Core.Model;

namespace TripPlaning.Core.Repositories
{
    public interface IStopoverPlaceRepository
    {
        public List<StopoverPlace> GetList();
        public void Delete(int id);
        public StopoverPlace GetById(int id);

        public StopoverPlace AddStopoverPlace(StopoverPlace stopoverPlace);
        public StopoverPlace UpdateStopoverPlace(StopoverPlace stopoverPlace);

        public StopoverPlace UpdateRate(int id, double rating);
    }
}