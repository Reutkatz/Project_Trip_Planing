using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TripPlaning.Core.Model;

namespace TripPlaning.Core.Repositories
{
    public interface ITrailRepository
    {
        public List<Trail> GetList();
        public void Delete(int id);
        public Trail GetById(int id);

        public Trail AddTrail(Trail trail);
        public Trail UpdateTrail(Trail trail);

        public Trail UpdateRate(int id,double rating);
    }
}
