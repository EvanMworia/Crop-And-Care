using VeterinaryMS.Models;
using VeterinaryMS.Models.DTOs;

namespace VeterinaryMS.Services.IService
{
    public interface IVeterinaryService
    {
        Task<ResponseDTO> AddVet(AddVetDTO veterinaryDTO);
        Task<List<Veterinary>> GetAllVets();
        Task<Veterinary> GetVetById(Guid id);
        Task<List<Veterinary>> GetVetsByLocation(string locationDTO);
        Task<Veterinary> UpdateVetDetails(AddVetDTO veterinaryDTO);
        Task <string> DeleteVetRecord(Guid id);
    }
}
