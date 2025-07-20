using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TripPlaning.Core.DTO;
using TripPlaning.Core.Model;
using TripPlaning.Core.Service;
using TripPlaning.Service;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TripPlaning.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]


    public class TripController : ControllerBase
    {
        private readonly ITripService tripService;
        private readonly TripAlgo tripAlgo;
        private readonly IMapper mapper;

        public TripController(ITripService tripService,IMapper mapper, TripAlgo tripAlgo)
        {
            this.tripService = tripService;
            this.mapper = mapper;
            this.tripAlgo = tripAlgo;
        }
        // GET: api/<TripController>
        [HttpGet]
        [Authorize(Roles = "User,BusinessManager")]
        public List<Trip> Get()
        {
            return tripService.GetList();
        }

        // GET api/<TripController>/5
        [HttpGet("{id}")]
        [Authorize]
        public TripDTO Get(int id)
        {
            var trip= tripService.GetById(id);
            var userDTO = mapper.Map<TripDTO>(trip);
            return userDTO;
        }

        //// POST api/<TripController>
        [HttpPost]
        [Authorize]
        public void Post([FromBody] Trip trip)
        {
            tripService.AddTrip(mapper.Map<Trip>(trip));
        }

        //// PUT api/<TripController>/5
        [HttpPut("{id}")]
        [Authorize(Roles = "User,BusinessManager")]
        public void Put([FromBody] Trip trip)
        {
            tripService.UpdateTrip(trip);
        }

        // DELETE api/<TripController>/5
        [HttpDelete("{id}")]
        [Authorize(Roles = "User,BusinessManager")]
        public void Delete(int id)
        {

            tripService.Delete(id);
        }
       
        [HttpPost("getBestTrip")]
        [Authorize(Roles = "User,BusinessManager")]
        public List<Place> GetBestTrip([FromBody] Trip trip)
        {
            tripService.AddTrip(mapper.Map<Trip>(trip));
            return tripAlgo.SelectBestCombination(trip);
        }


    }
}
