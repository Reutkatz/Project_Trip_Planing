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
    public class OpeningHoursController : ControllerBase
    {
        private readonly IOpenHoursService openHoursService;


        public OpeningHoursController(IOpenHoursService openHoursService)
        {
            this.openHoursService = openHoursService;
        }
       
        [HttpGet]
        [Authorize(Roles = "User,BusinessManager")]
        public List<OpeningHours> Get()
        {
            return openHoursService.GetList();
        }

      
        [HttpGet("{id}")]
        [Authorize(Roles = "User,BusinessManager")]
        public OpeningHours Get(int id)
        {
            var openingHours = openHoursService.GetById(id);
            return openingHours;
        }

      
        [HttpPost]
        [Authorize(Roles = "BusinessManager")]
        public OpeningHours Post([FromBody] OpeningHours openingHours)
        {
            return openHoursService.AddOpeningHours(openingHours);
        }

   
        [HttpPut("{id}")]
        [Authorize(Roles = "BusinessManager")]
        public void Put([FromBody] OpeningHours openingHours)
        {
            openHoursService.UpdateOpeningHours(openingHours);
        }

        
        [HttpDelete("{id}")]
        [Authorize(Roles = "BusinessManager")]
        public void Delete(int id)
        {

            openHoursService.Delete(id);
        }
        [HttpPost("list")]
        [Authorize(Roles = "BusinessManager")]
        public List<OpeningHours> addList(List<OpeningHours> openingHours)
        {
            return openHoursService.addList(openingHours);
        }



    }
}
