using Coding_Challenge.Exceptions;
using Coding_Challenge.Interfaces;
using Coding_Challenge.Models;
using Coding_Challenge.Models.DTO;
using Microsoft.AspNetCore.Mvc;

namespace Coding_Challenge.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EventController : Controller
    {
        private readonly IEventService _eventService;

        public EventController(IEventService eventService)
        {
            _eventService = eventService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllEvent()
        {
            var members = await _eventService.GetAllEvent();
            return Ok(members);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetEvent(int id)
        {
            try
            {
                var member = await _eventService.GetEvent(id);
                return Ok(member);
            }
            catch (NoSuchEventException)
            {
                return NotFound();
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddEvent([FromBody] Event events)
        {
            var newEvent = await _eventService.AddEvent(events);
            return CreatedAtAction(nameof(GetEvent), new { id = newEvent.EventId }, newEvent);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateEvent(int id, [FromBody] EventUpdateDto eventDto)
        {
            try
            {
                var updatedEvent = await _eventService.UpdateEvent(id, eventDto);
                return Ok(updatedEvent);
            }
            catch (NoSuchEventException)
            {
                return NotFound();
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEvent(int id)
        {
            try
            {
                var deletedEvent = await _eventService.DeleteEvent(id);
                return Ok(deletedEvent);
            }
            catch (NoSuchEventException)
            {
                return NotFound();
            }
        }
    }
}
