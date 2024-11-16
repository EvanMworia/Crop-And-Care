using AutoMapper;
using CropMS.Data;
using CropMS.Models;
using CropMS.Models.DTOs;
using CropMS.Services.IServices;
using Microsoft.EntityFrameworkCore;

namespace CropMS.Services
{
    public class FarmService : IFarmService
    {
        private readonly CropDbContext _context;
        private readonly IMapper _mapper;
        private readonly ResponseDTO _responseDTO;

        public FarmService(CropDbContext applicationDbContext, IMapper mapper)
        {
            _context = applicationDbContext;
            _mapper = mapper;
            _responseDTO = new ResponseDTO();
        }
        public async Task<ResponseDTO> AddFarm(AddFarmerDTO addFarmDTO)
        {
            try
            {
                var mappedFarm = _mapper.Map<Farmer>(addFarmDTO);
                await _context.Farmers.AddAsync(mappedFarm);
                await _context.SaveChangesAsync();
                _responseDTO.Message = $"Organic farmer {mappedFarm.FullNames} has been Vetted and Added";
                _responseDTO.Result = mappedFarm;
                _responseDTO.IsSuccess = true;
                return _responseDTO;

            }
            catch (Exception ex)
            {

                _responseDTO.Message = ex.Message;
                _responseDTO.IsSuccess = false;
                return _responseDTO;
            }
        }

        public Task<string> DeleteFarmRecord(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Farmer>> GetAllFarms()
        {
            try
            {
                return await _context.Farmers.ToListAsync();

            }
            catch (Exception ex)
            {

                throw new ApplicationException("An Error Occurred in the Service layer while Fetching Farms", ex.InnerException);
            }
        }

        public async Task<Farmer> GetFarmById(Guid id)
        {
            var result = await _context.Farmers.FindAsync(id);
            if (result == null)
            {
                //tests for a null result, if result is null throw an exception that will bubble up to the controller and handled there
                throw new KeyNotFoundException($"No Farm was found with the id '{id}' you provided.");
            }
            return result;
        }

        public async Task<List<Farmer>> GetFarmByLocation(string location)
        {
            if (string.IsNullOrWhiteSpace(location))
            {
                throw new ArgumentException("Location cannot be null or empty", nameof(location));
            }
            var trimmedLocation = location.Trim();
            return await _context.Farmers.Where(farm => farm.FarmLocation.ToLower() == location.ToLower()).ToListAsync();
        }

        public async Task<List<Farmer>> GetFarmByProduce(string produce)
        {
            if (string.IsNullOrWhiteSpace(produce))
            {
                throw new ArgumentException("Produce cannot be null or empty", nameof(produce));
            }
            var trimmedLocation = produce.Trim();
            return await _context.Farmers.Where(produceLookup => produceLookup.ProduceExpected.ToLower() == produce.ToLower()).ToListAsync();
        }

        public async Task<List<Farmer>> GetFarmerByNationalId(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                throw new ArgumentException("Id Number cannot be null or empty", nameof(id));
            }
            var trimmedLocation = id.Trim();
            return await _context.Farmers.Where(farmer => farmer.IdNumber.ToLower() == id.ToLower()).ToListAsync();
        }

        public Task<Farmer> UpdateFarmDetails(AddFarmerDTO updatedFarmDTO)
        {
            throw new NotImplementedException();
        }
    }
}
