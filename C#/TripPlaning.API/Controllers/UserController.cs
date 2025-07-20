using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TripPlaning.Core.Model;
using TripPlaning.Core.Service;
using TripPlaning.Service;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TripPlaning.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UserController : ControllerBase
    {
        private readonly IUserService userService;

        public UserController(IUserService userService)
        {
            this.userService = userService;
        }
        // GET: api/<UserController>
        [HttpGet]
        [Authorize]
        public List<User> Get()
        {
            return userService.GetList();
        }

        // GET api/<UserController>/5
        [HttpGet("{id}")]
        [Authorize]
        public User Get(int id)
        {
            return userService.GetById(id);
        }

        //// POST api/<UserController>
        [HttpPost]
        [Authorize(Roles = "User,BusinessManager")]
        public void Post([FromBody] User user)
        {
            userService.AddUser(user);
        }

        //// PUT api/<UserController>/5
        [HttpPut("{id}")]
        [Authorize(Roles = "User,BusinessManager")]
        public User Put([FromBody] User user)
        {
           return userService.UpdateUser(user);
        }

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        [Authorize(Roles = "User,BusinessManager")]
        public void Delete(int id)
        {

            userService.Delete(id);
        }
        [HttpGet("getUserByMail/{email}")]
        public User GetUserByEmail(string email)
        {
            User res= userService.GetUserByEmail(email);
            Console.WriteLine(res);
            return res;
        }



    }
}

