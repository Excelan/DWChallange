using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using DWChallange.Services;
using DWChallange.ViewModels.Registration;

namespace DWChallange.Pages.EventManagement
{
    [Authorize]
    public class RegistrationsModel : PageModel
    {
        private readonly IRegistrationService _service;

        public RegistrationsModel(IRegistrationService service) {
            _service = service;
        }

        public IList<ViewRegistration> Registrations { get; set; } = default!;

        public async Task OnGetAsync(int? id) {
            if (id != null) {
                Registrations = await _service.GetAll()
                    .Where(r => r.EventId == id)
                    .ToListAsync();
            }
        }
    }
}
