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
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public List<User> GetList()
        {
            return _userRepository.GetList();
        }
        public void Delete(int id)
        {
            _userRepository.Delete(id);
        }
        public User GetById(int id)
        {
            return _userRepository.GetById(id);
        }
        public void AddUser(User user)
        {
            _userRepository.AddUser(user);
        }
        public User UpdateUser(User user)
        {
           return _userRepository.UpdateUser(user);
        }
        public User SignUp(User user)
        {
           return _userRepository.SignUp(user);
        }
        public User GetUserByEmail(string email)
        {
            return _userRepository.GetUserByEmail(email);
        }


    }
}

