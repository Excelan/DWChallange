using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using DWChallange.Services;
using DWChallange.ViewModels.Event;

namespace DWChallange.Pages.EventManagement
{
    [Authorize]
    public class CreateModel : PageModel
    {
        private readonly IEventManagementService _service;

        [BindProperty]
        public CreateEvent Event { get; set; } = default!;

        public CreateModel(IEventManagementService service) {
            _service = service;
        }

        public IActionResult OnGet() {
            return Page();
        }


        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync() {
            if (!ModelState.IsValid || Event == null) {
                return Page();
            }
            await _service.Create(Event);
            return RedirectToPage("./Index");
        }
    }
}
