using AutoMapper;
using AutoMapper.QueryableExtensions;
using DWChallange.Data;
using DWChallange.Domain.Models;
using DWChallange.ViewModels.Event;
using Microsoft.EntityFrameworkCore;

namespace DWChallange.Services
{
    public class EventManagementService : IEventManagementService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public EventManagementService(ApplicationDbContext dbContext, IMapper mapper) {
            _context = dbContext;
            _mapper = mapper;
        }

        public async Task<ViewEvent?> Create(CreateEvent publicEvent) {
            if (publicEvent is null) {
                return null;
            }
            var domainEvent = _mapper.Map<Event>(publicEvent);
            _context.Events.Add(domainEvent);
            await _context.SaveChangesAsync();
            return _mapper.Map<ViewEvent>(domainEvent);
        }

        public async Task Delete(ViewEvent viewEvent) {
            var domainEvent = await _context.Events.FindAsync(viewEvent.Id);

            if (domainEvent != null) {
                _context.Events.Remove(domainEvent);
                await _context.SaveChangesAsync();
            }
        }

        public bool Exists(int id) {
            return (_context.Events?.Any(e => e.Id == id)).GetValueOrDefault();
        }

        public async Task<ViewEvent?> Find(int id) {
            var domainEvent = await _context.Events.FirstOrDefaultAsync(e => e.Id == id);
            return _mapper.Map<ViewEvent>(domainEvent);
        }

        public async Task<UpdateEvent?> FindForUpdate(int id) {
            var domainEvent = await _context.Events.FirstOrDefaultAsync(e => e.Id == id);
            return _mapper.Map<UpdateEvent>(domainEvent);
        }

        public async Task<ViewEvent?> Update(UpdateEvent updateEvent) {
            var domainEvent = _mapper.Map<Event>(updateEvent);
            _context.Attach(domainEvent).State = EntityState.Modified;

            try {
                await _context.SaveChangesAsync();
            } catch (DbUpdateConcurrencyException) {
                if (!EventExists(updateEvent.Id)) {
                    return null;
                } else {
                    throw;
                }
            }
            return _mapper.Map<ViewEvent>(domainEvent);
        }

        public IQueryable<ViewEvent> GetAll() {
            return _context.Events.AsQueryable<Event>().ProjectTo<ViewEvent>(_mapper.ConfigurationProvider);
        }

        private bool EventExists(int id) {
            return (_context.Events?.Any(e => e.Id == id)).GetValueOrDefault();
        }

    }
}
