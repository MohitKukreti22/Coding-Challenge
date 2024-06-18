using Coding_Challenge.Interfaces;
using Coding_Challenge.Models;
using Coding_Challenge.Models.DTO;

namespace Coding_Challenge.Services
{
    public class EventService : IEventService
    {

        private readonly IRepository<int, Event> _repository;

        public EventService(IRepository<int, Event> repository)
        {
            _repository = repository;
        }


        public Task<Event> AddEvent(Event events)
        {
            return _repository.Add(events);
        }

        public Task<Event> DeleteEvent(int id)
        {
            return _repository.Delete(id);
        }

        public Task<List<Event>> GetAllEvent()
        {
            return _repository.GetAll();
        }


        public Task<Event> GetEvent(int id)
        {
            return _repository.Get(id);
        }



        public async Task<Event> UpdateEvent(int id, EventUpdateDto eventdto)
        {
            var events = await _repository.Get(id);
            if (events == null)
            {
                throw new NotImplementedException();
            }

            // Map DTO to entity
            if (eventdto.Title != null) events.Title = eventdto.Title;

            if (eventdto.Description != null) events.Description = eventdto.Description;
         
            if (eventdto.EventData.HasValue) events.EventData = eventdto.EventData.Value;
            if (eventdto.Location != null) events.Location = eventdto.Location;
            if (eventdto.MaxAttendees != null) events.MaxAttendees = eventdto.MaxAttendees;
            if (eventdto.Fees != null) events.Fees = eventdto.Fees;
            return await _repository.Update(events);
        }
    }
      
}
