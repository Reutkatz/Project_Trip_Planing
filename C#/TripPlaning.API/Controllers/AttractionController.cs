using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TripPlaning.Core.DTO;
using TripPlaning.Core.Model;
using TripPlaning.Core.Service;
using TripPlaning.Service;

namespace TripPlaning.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class AttractionController : ControllerBase
    {
        private readonly IAttractionService attractionService;

        public AttractionController(IAttractionService attractionService)
        {
            this.attractionService = attractionService;

        }                           
        // GET: api/<AttractionController>
        [HttpGet] 
        [Authorize(Roles = "User,BusinessManager")]
        public List<Attraction> Get()
        {
            return attractionService.GetList();
        }

        // GET api/<AttractionController>/5
        [HttpGet("{id}")]
        [Authorize(Roles = "User,BusinessManager")]
        public Attraction Get(int id)
        {
            var attraction = attractionService.GetById(id);
            return attraction;
        }

        //// POST api/<AttractionController>
        [HttpPost]
        [Authorize(Roles = "BusinessManager")]
        public Attraction Post([FromBody] Attraction attraction)
        {
            Console.WriteLine("sdgfsdgfdsfsf"+attraction);
            attractionService.AddAttraction(attraction);
            return attraction;

        }

        //// PUT api/<AttractionpController>/5
        [HttpPut("{id}")]
        [Authorize(Roles = "BusinessManager")]
        public void Put([FromBody] Attraction attraction)
        {
            attractionService.UpdateAttraction(attraction);
        }

        // DELETE api/<AttractionController>/5
        [HttpDelete("{id}")]
        [Authorize(Roles = "BusinessManager")]
        public void Delete(int id)
        {

            attractionService.Delete(id);
        }

        [HttpPut("rate/{id}")]
        [Authorize(Roles = "User")]
        public Attraction UpdateRate(int id, [FromBody] double rating)
        {
            return attractionService.UpdateRate(id, rating);
        }
    
    }
}
