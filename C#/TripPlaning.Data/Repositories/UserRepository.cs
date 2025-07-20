using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TripPlaning.Core.Model;
using TripPlaning.Core.Repositories;

namespace TripPlaning.Data.Repositories
{
    public class UserRepository: IUserRepository
    {
        private readonly DataContext _context;
        public UserRepository(DataContext context)
        {
            _context = context;
        }
        public List<User> GetList()
        {
            return _context.Users.ToList();
        }
        public void Delete(int id)
        {
            User u = GetById(id);
            _context.Users.Remove(u);
            _context.SaveChanges();
        }
        public User GetById(int id)
        {
            int index = _context.Users.ToList().FindIndex(x => x.Id == id);
            if (index == -1)
            {
                return null;
            }
            return _context.Users.ToList()[index];
        }

        public void AddUser(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges(true);
        }
        public User UpdateUser(User user)
        {

            User u = GetById(user.Id);
            if (u != null)
            {
                u.Name = user.Name;
                u.Email = user.Email;
                u.Password= user.Password;
            }
            _context.SaveChanges(true);
            return u;
        }
        public User GetUserByEmail(string email)
        {
            List<User> users = GetList();
            User user = users.Find(u => u.Email == email);
            return user;
        }
        public User SignUp(User user)
        {

            User u = _context.Users.FirstOrDefault(u => u.Email == user.Email);
            if (u == null)
            {
                _context.Users.Add(user);
                _context.SaveChanges();
                return user;
            }
            else
                return null;
        }

    }
}

