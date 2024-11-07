using Microsoft.AspNetCore.Mvc;
using EventMicroservice.Models;
using EventMicroservice.Services;
using System.Collections.Generic;

namespace EventMicroservice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventsController : ControllerBase
    {
        private readonly EventService _eventService;

        public EventsController(EventService eventService)
        {
            _eventService = eventService;
        }

        [HttpGet]
        public ActionResult<List<Event>> GetEvents()
        {
            return Ok(_eventService.GetAllEvents());
        }

        [HttpPost]
        public ActionResult CreateEvent([FromBody] Event newEvent)
        {
            if (ModelState.IsValid)
            {
                _eventService.AddEvent(newEvent);
                return Ok(new { message = "!" });
            }
            return BadRequest(ModelState);
        }
    }
}
