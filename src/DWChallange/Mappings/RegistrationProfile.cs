using AutoMapper;
using DWChallange.Domain.Models;
using DWChallange.ViewModels.Registration;


namespace DWChallange.Mappings
{
    public class RegistrationProfile : Profile
    {
        public RegistrationProfile() {

            CreateMap<Registration, ViewRegistration>()
                .ForMember(dest => dest.EventId, opt => opt.MapFrom(src => src.Event!.Id));

            CreateMap<Registration, CreateRegistration>()
                .ForMember(dest => dest.EventId, opt => opt.MapFrom(src => src.Event!.Id));

            CreateMap<CreateRegistration, Registration>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.Event, opt => opt.MapFrom(src => new Event { Id = src.EventId }));

        }
    }
}
