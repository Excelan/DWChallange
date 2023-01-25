using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using DWChallange.Services;
using DWChallange.ViewModels.Event;

namespace DWChallange.Pages.Events
{
    public class IndexModel : PageModel
    {
        private readonly IEventManagementService _service;
        private readonly IMapper _mapper;

        public IndexModel(IEventManagementService service, IMapper mapper) {
            _service = service;
            _mapper = mapper;
        }

        public IList<ViewEvent> Events { get; set; } = default!;

        public async Task OnGetAsync() {
            Events = await _service.GetAll().Select(e => _mapper.Map<ViewEvent>(e)).ToListAsync();
        }
    }
}
