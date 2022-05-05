using AutoMapper;
using Timely_v1.Models;
using Timely_v1.ViewModels;

namespace Timely_v1.MappingProfile
{
    public class SessionProfile : Profile
    {
        public SessionProfile() 
        {
            CreateMap<Session, SessionViewModel>()
                .ForMember(vm => vm.StartDate, m => m.MapFrom(s => s.StartDate.ToString("MM/dd/yyyy HH:mm")))
                .ForMember(vm => vm.EndDate, m => m.MapFrom(s => s.EndDate.ToString("MM/dd/yyyy HH:mm")))
                .ForMember(vm => vm.DiffTime, m => m.MapFrom(s => s.EndDate.Subtract(s.StartDate).ToString()));
        }
    }
}