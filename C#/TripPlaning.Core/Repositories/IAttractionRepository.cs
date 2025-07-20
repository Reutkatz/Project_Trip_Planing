using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TripPlaning.Core.Model;

namespace TripPlaning.Core.Repositories
{
    public interface IAttractionRepository
    {
        public List<Attraction> GetList();
        public void Delete(int id);
        public Attraction GetById(int id);

        public Attraction AddAttraction(Attraction attraction);
        public Attraction UpdateAttraction(Attraction attraction);

        public Attraction UpdateRate(int id, double rating);
    }
}
