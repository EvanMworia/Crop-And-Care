using AutoMapper;
using Microsoft.EntityFrameworkCore;
using VeterinaryMS.Data;
using VeterinaryMS.Models;
using VeterinaryMS.Models.DTOs;
using VeterinaryMS.Services.IService;

namespace VeterinaryMS.Services
{
    public class VeterinaryService : IVeterinaryService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly ResponseDTO _responseDTO;

        public VeterinaryService(ApplicationDbContext applicationDbContext, IMapper mapper)
        {
            _context = applicationDbContext;
            _mapper = mapper;
            _responseDTO = new ResponseDTO();
        }
        public async Task<ResponseDTO> AddVet(AddVetDTO veterinaryDTO)
        {
            try
            {
                var mappedVet = _mapper.Map<Veterinary>(veterinaryDTO);
                await _context.Veterinaries.AddAsync(mappedVet);
                await _context.SaveChangesAsync();
                _responseDTO.Message = $"Veterinary {mappedVet.FullNames} has been Vetted and Added";
                _responseDTO.Result = mappedVet;
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

        public Task<string> DeleteVetRecord(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Veterinary>> GetAllVets()
        {
            try
            {
                return await _context.Veterinaries.ToListAsync();

            }
            catch (Exception ex)
            {

                throw new ApplicationException("An Error Occurred in the Service layer while Fetching Vets", ex.InnerException);
            }
        }

        public async Task<Veterinary> GetVetById(Guid id)
        {
            
                var result = await _context.Veterinaries.FindAsync(id);
                if (result == null)
                {
                //tests for a null result, if result is null throw an exception that will bubble up to the controller and handled there
                    throw new KeyNotFoundException($"No Vet was found with the id '{id}' you provided.");
                }
                return result;

            
        }

        public async Task<List<Veterinary>> GetVetsByLocation(string locationDTO)
        {
            if (string.IsNullOrWhiteSpace(locationDTO))
            {
                throw new ArgumentException("Location cannot be null or empty", nameof(locationDTO));
            }
            var trimmedLocation = locationDTO.Trim();
            return await _context.Veterinaries.Where(vet => vet.PrimaryLocation.ToLower() == locationDTO.ToLower()).ToListAsync();
        }

        public Task<Veterinary> UpdateVetDetails(AddVetDTO veterinaryDTO)
        {
            throw new NotImplementedException();
        }
    }
}
