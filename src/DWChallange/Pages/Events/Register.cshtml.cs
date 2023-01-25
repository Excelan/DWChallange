using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using AutoMapper;
using DWChallange.Services;
using DWChallange.ViewModels.Registration;
using DWChallange.ViewModels.Event;

namespace DWChallange.Pages.Events
{
    public class RegisterModel : PageModel
    {
        private readonly IMapper _mapper;
        private readonly IRegistrationService _service;
        private readonly IEventManagementService _eventService;

        [BindProperty]
        public CreateRegistration Registration { get; set; } = default!;

        [BindProperty]
        public ViewEvent Event { get; set; } = default!;


        public RegisterModel(IMapper mapper, IRegistrationService service, IEventManagementService eventService) {
            _mapper = mapper;
            _service = service;
            _eventService = eventService;
        }

        public async Task<IActionResult> OnGet(int id) {
            var publicEvent = await _eventService.Find(id);
            if (publicEvent is null) {
                ViewData["ErrorMessage"] = "The event you are trying to register to is not found.";
                return Page();
            }
            Event = _mapper.Map<ViewEvent>(publicEvent);
            return Page();
        }

        public async Task<IActionResult> OnPostAsync() {
            if (!ModelState.IsValid || Registration == null) {
                return Page();
            }

            await _service.Create(Registration);
            ViewData["Message"] = $"You have successfully registered.";
            return Page();
        }
    }
}
