using Coding_Challenge.Models;
using Coding_Challenge.Models.DTO;

namespace Coding_Challenge.Interfaces
{
    public interface IEventService
    {
        Task<List<Event>> GetAllEvent();
        Task<Event> GetEvent(int id);
        Task<Event> AddEvent(Event events);
        Task<Event> UpdateEvent(int id, EventUpdateDto eventdto);
        Task<Event> DeleteEvent(int id);


    }
}
