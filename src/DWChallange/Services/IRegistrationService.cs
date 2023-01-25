using DWChallange.ViewModels;
using DWChallange.ViewModels.Registration;

namespace DWChallange.Services
{
    public interface IRegistrationService
    {
        Task<ViewRegistration> Create(CreateRegistration registration);

        IQueryable<ViewRegistration> GetAll();

    }
}
