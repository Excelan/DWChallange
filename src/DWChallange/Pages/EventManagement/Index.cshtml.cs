using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DWChallange.Services;
using Microsoft.AspNetCore.Authorization;
using DWChallange.ViewModels.Event;

namespace DWChallange.Pages.EventManagement
{
    [Authorize]
    public class IndexModel : PageModel
    {
        private readonly IEventManagementService _service;

        public IList<ViewEvent> Events { get; set; } = default!;

        public IndexModel(IEventManagementService service) {
            _service = service;
        }

        public async Task OnGetAsync() {
            Events = await _service.GetAll().ToListAsync();
        }
    }
}
