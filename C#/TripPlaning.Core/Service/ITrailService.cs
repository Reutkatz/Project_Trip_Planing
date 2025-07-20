using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TripPlaning.Core.Model;

namespace TripPlaning.Core.Service
{
    public interface ITrailService
    {
        public List<Trail> GetList();
        public void Delete(int id);
        public Trail GetById(int id);

        public Trail AddTrail(Trail trail);
        public Trail UpdateTrail(Trail trail);
        public Trail UpdateRate(int id, double rating);

    }
}
