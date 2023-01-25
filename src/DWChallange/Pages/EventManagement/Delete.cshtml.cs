using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using DWChallange.Services;
using DWChallange.ViewModels.Event;

namespace DWChallange.Pages.EventManagement
{
    public class DeleteModel : PageModel
    {
        private readonly IEventManagementService _service;

        [BindProperty]
        public ViewEvent Event { get; set; } = default!;

        public DeleteModel(IEventManagementService service) {
            _service = service;
        }

        public async Task<IActionResult> OnGetAsync(int? id) {
            if (id == null) {
                return NotFound();
            }

            var viewEvent = await _service.Find(id.Value);

            if (viewEvent == null) {
                return NotFound();
            }

            Event = viewEvent;
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id) {
            if (id == null) {
                return NotFound();
            }
            var viewEvent = await _service.Find(id.Value);

            if (viewEvent != null) {
                await _service.Delete(viewEvent);
            }

            return RedirectToPage("./Index");
        }
    }
}
