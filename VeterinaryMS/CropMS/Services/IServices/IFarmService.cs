using CropMS.Models;
using CropMS.Models.DTOs;

namespace CropMS.Services.IServices
{
    public interface IFarmService
    {
        Task<ResponseDTO> AddFarm(AddFarmerDTO addFarmDTO);
        Task<List<Farmer>> GetAllFarms();
        Task<Farmer> GetFarmById(Guid id);
        Task<List<Farmer>> GetFarmerByNationalId(string id);
        Task<List<Farmer>> GetFarmByProduce(string produce);
        Task<List<Farmer>> GetFarmByLocation(string location);
        Task<Farmer> UpdateFarmDetails(AddFarmerDTO updatedFarmDTO);
        Task<string> DeleteFarmRecord(Guid id);
    }
}
