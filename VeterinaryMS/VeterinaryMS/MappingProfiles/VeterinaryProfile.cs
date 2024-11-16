using AutoMapper;
using VeterinaryMS.Models;
using VeterinaryMS.Models.DTOs;

namespace VeterinaryMS.MappingProfiles
{
    public class VeterinaryProfile : Profile
    {
        public VeterinaryProfile()
        {
            CreateMap<AddVetDTO, Veterinary>().ReverseMap();
        }
    }
}
