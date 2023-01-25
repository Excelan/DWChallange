using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using DWChallange.Services;
using DWChallange.ViewModels.Event;

namespace DWChallange.Pages.EventManagement
{
    [Authorize]
    public class DetailsModel : PageModel
    {
        private readonly IEventManagementService _service;

        public DetailsModel(IEventManagementService service) {
            _service = service;
        }

        public ViewEvent Event { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var viewEvent = await _service.Find(id.Value);
            if (viewEvent == null)
            {
                return NotFound();
            }
            else 
            {
                Event = viewEvent;
            }
            return Page();
        }
    }
}
