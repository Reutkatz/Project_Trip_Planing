using AutoMapper;
using Google.Apis.Gmail.v1;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TripPlaning.Core.Model;
using TripPlaning.Core.Service;
using TripPlaning.Service;

namespace TripPlaning.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class StopoverPlaceController : ControllerBase
    {
        private readonly IStopoverPlaceService stopoverPlaceService;

        public StopoverPlaceController(IStopoverPlaceService stopoverPlaceService)
        {
            this.stopoverPlaceService = stopoverPlaceService;

        }
        // GET: api/<StopoverPlaceController>
        [HttpGet]
        [Authorize(Roles = "User,BusinessManager")]
        public List<StopoverPlace> Get()
        {
            return stopoverPlaceService.GetList();
        }

        // GET api/<StopoverPlaceController>/5
        [HttpGet("{id}")]
        [Authorize(Roles = "User,BusinessManager")]
        public StopoverPlace Get(int id)
        {
            var stopoverPlace = stopoverPlaceService.GetById(id);
            return stopoverPlace;
        }

        //// POST api/<StopoverPlaceController>
        [HttpPost]
        [Authorize(Roles = "BusinessManager")]
        public StopoverPlace Post([FromBody] StopoverPlace stopoverPlace)
        {
            return stopoverPlaceService.AddStopoverPlace(stopoverPlace);
        }

        //// PUT api/<StopoverPlaceController>/5
        [HttpPut("{id}")]
        [Authorize(Roles = "BusinessManager")]
        public void Put([FromBody] StopoverPlace stopoverPlace)
        {
            stopoverPlaceService.UpdateStopoverPlace(stopoverPlace);
        }

        // DELETE api/<StopoverPlaceController>/5
        [HttpDelete("{id}")]
        [Authorize(Roles = "BusinessManager")]
        public void Delete(int id)
        {

            stopoverPlaceService.Delete(id);
        }

        [HttpPut("rate/{id}")]
        [Authorize(Roles = "User")]
        public StopoverPlace UpdateRate(int id, [FromBody] double rating)
        {
            return stopoverPlaceService.UpdateRate(id, rating);
        }

    }
}
