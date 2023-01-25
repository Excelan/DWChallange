using AutoMapper;
using DWChallange.Domain.Models;
using DWChallange.ViewModels.Event;

namespace DWChallange.Mappings
{
    public class EventProfile : Profile
    {
        public EventProfile() {

            CreateMap<Event, ViewEvent>();
            CreateMap<Event, UpdateEvent>();

            CreateMap<CreateEvent, Event>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.Registrations, opt => opt.Ignore());

            CreateMap<UpdateEvent, Event>()
                .ForMember(dest => dest.Registrations, opt => opt.Ignore());

        }
    }
}
