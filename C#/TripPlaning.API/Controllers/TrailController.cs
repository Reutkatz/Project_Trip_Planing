using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TripPlaning.Core.Model;
using TripPlaning.Core.Service;

namespace TripPlaning.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]


    public class TrailController : ControllerBase
    {
        private readonly ITrailService trailService;
       

        public TrailController(ITrailService trailService)
        {
            this.trailService = trailService;

        }
        // GET: api/<TrailController>
        [HttpGet]
        [Authorize(Roles = "User,BusinessManager")]
        public List<Trail> Get()
        {
            return trailService.GetList();
        }

        // GET api/<AttractionController>/5
        [HttpGet("{id}")]
        [Authorize(Roles = "User,BusinessManager")]
        public Trail Get(int id)
        {
            var trail = trailService.GetById(id);
            return trail;
        }

        //// POST api/<TrailController>
        [HttpPost]
        [Authorize(Roles = "BusinessManager")]
        public Trail Post([FromBody] Trail trail)
        {
            return trailService.AddTrail(trail);
        }

        //// PUT api/<TrailController>/5
        [HttpPut("{id}")]
        [Authorize(Roles = "BusinessManager")]
        public void Put([FromBody] Trail trail)
        {
            trailService.UpdateTrail(trail);
        }

        // DELETE api/<TrailController>/5
        [HttpDelete("{id}")]
        [Authorize(Roles = "BusinessManager")]
        public void Delete(int id)
        {

            trailService.Delete(id);
        }

        [HttpPut("rate/{id}")]
        [Authorize(Roles = "User")]
        public Trail UpdateRate(int id, [FromBody] double rating)
        {
            return trailService.UpdateRate(id,rating);
        }

    }
}