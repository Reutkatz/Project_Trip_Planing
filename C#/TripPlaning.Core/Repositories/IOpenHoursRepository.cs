using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TripPlaning.Core.Model;

namespace TripPlaning.Core.Repositories
{
    public interface IOpenHoursRepository
    {
        public List<OpeningHours> GetList();
        public void Delete(int id);
        public OpeningHours GetById(int id);

        public OpeningHours AddOpeningHours(OpeningHours openingHours);
        public void UpdateOpeningHours(OpeningHours openingHours);
        public List<OpeningHours> addList(List<OpeningHours> openingHours);

    }
}
