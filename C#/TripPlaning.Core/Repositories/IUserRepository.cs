using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TripPlaning.Core.Model;

namespace TripPlaning.Core.Repositories
{
    public interface IUserRepository
    {
        public List<User> GetList();
        public void Delete(int id);
        public User GetById(int id);

        public void AddUser(User user);
        public User UpdateUser(User user);
        public User GetUserByEmail(string email);
        public User SignUp(User user);

    }
}
