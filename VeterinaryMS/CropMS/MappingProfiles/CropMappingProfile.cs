using AutoMapper;
using CropMS.Models;
using CropMS.Models.DTOs;

namespace CropMS.MappingProfiles
{
    public class CropMappingProfile:Profile
    {
        public CropMappingProfile()
        {
            CreateMap<AddFarmerDTO, Farmer>().ReverseMap();
        }
    }
}
