using AutoMapper;
using Newtonsoft.Json.Linq;
using VMSCore.API.EntityModels.Models;

namespace VMSCore.API
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<JObject, Staff>();
            CreateMap<Staff, Staff>()
                    .ForMember(dest => dest.Id, act => act.Ignore());
            CreateMap<JObject, Button>();
            CreateMap<Button, Button>()
                    .ForMember(dest => dest.Id, act => act.Ignore());
            CreateMap<JObject, Barcode>();
            CreateMap<Barcode, Barcode>()
                    .ForMember(dest => dest.Id, act => act.Ignore());
            CreateMap<JObject, Shift>();
            CreateMap<Shift, Shift>()
                    .ForMember(dest => dest.Id, act => act.Ignore());
        }
    }
}
