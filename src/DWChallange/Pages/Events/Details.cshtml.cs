using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using AutoMapper;
using DWChallange.Services;
using DWChallange.ViewModels.Event;

namespace DWChallange.Pages.Events
{
    public class DetailsModel : PageModel
    {
        private readonly IEventManagementService _service;
        private readonly IMapper _mapper;

        public DetailsModel(IEventManagementService service, IMapper mapper) {
            _service = service;
            _mapper = mapper;
        }

        public ViewEvent Event { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id) {
            if (id == null) {
                return NotFound();
            }

            var publicEvent = await _service.Find(id.Value);
            if (publicEvent == null) {
                return NotFound();
            } else {
                Event = _mapper.Map<ViewEvent>(publicEvent);
            }
            return Page();
        }
    }
}

