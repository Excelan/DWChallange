using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using DWChallange.Services;
using DWChallange.ViewModels.Event;

namespace DWChallange.Pages.EventManagement
{
    [Authorize]
    public class EditModel : PageModel
    {
        private readonly IEventManagementService _service;

        public EditModel(IEventManagementService service) {
            _service = service;
        }

        [BindProperty]
        public UpdateEvent Event { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id) {
            if (id == null) {
                return NotFound();
            }

            var updateEvent = await _service.FindForUpdate(id.Value);
            if (updateEvent == null) {
                return NotFound();
            }
            Event = updateEvent;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync() {
            if (!ModelState.IsValid) {
                return Page();
            }
            var updatedEvent = await _service.Update(Event);
            if (updatedEvent == null) {
                return NotFound();
            }
            return RedirectToPage("./Index");
        }

    }
}
