using Coding_Challenge.Context;
using Coding_Challenge.Interfaces;
using Coding_Challenge.Models;
using Microsoft.EntityFrameworkCore;

namespace Coding_Challenge.Repositories
{
    public class EventRepository:IRepository<int,Event>
    {

        private readonly AppDbContext _context;
        public EventRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<Event> Add(Event item)
        {
           _context.Add(item);
            await _context.SaveChangesAsync();
            return item;
        }

        public async Task<Event?> Delete(int key)
        {
            var events = await Get(key);
            if (events != null)
            {
                _context.Events.Remove(events);
                await _context.SaveChangesAsync();
            }
            return events;
          
        }

        public async Task<Event?> Get(int key)
        {
            var events = await _context.Events.FindAsync(key);
            if (events == null)
                throw new NotImplementedException();
            return events;
        }

        public async Task<List<Event>?> GetAll()
        {
            return await _context.Events.ToListAsync();
        }

        public Task<List<User>> GetAsync()
        {
            throw new NotImplementedException();
        }

        public Task<User> GetAsync(int userId)
        {
            throw new NotImplementedException();
        }

        public async Task<Event> Update(Event item)
        {
            var events = await Get(item.EventId);
            if (events != null)
            {
                _context.Entry(item).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
            return item;
        }
    }
    }

