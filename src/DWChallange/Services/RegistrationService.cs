using System.Data;
using AutoMapper.QueryableExtensions;
using AutoMapper;
using DWChallange.Data;
using DWChallange.Domain.Models;
using DWChallange.ViewModels.Registration;

namespace DWChallange.Services
{
    public class RegistrationService : IRegistrationService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public RegistrationService(ApplicationDbContext context, IMapper mapper) {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ViewRegistration> Create(CreateRegistration createRegistration) {
            if (createRegistration is null) {
                throw new ArgumentNullException(nameof(createRegistration));
            }
            var publicEvent = await _context.FindAsync<Event>(createRegistration.EventId);
            if (publicEvent is null) {
                throw new DataException("The event you are trying to register to is not found.");
            }
            var domainModel = _mapper.Map<Registration>(createRegistration);
            domainModel.Event = publicEvent;
            _context.Registrations.Add(domainModel);
            await _context.SaveChangesAsync();
            var viewModel = _mapper.Map<ViewRegistration>(domainModel);
            return viewModel;
        }

        public IQueryable<ViewRegistration> GetAll() {
            return _context.Registrations.AsQueryable<Registration>().ProjectTo<ViewRegistration>(_mapper.ConfigurationProvider);
        }
    }
}
