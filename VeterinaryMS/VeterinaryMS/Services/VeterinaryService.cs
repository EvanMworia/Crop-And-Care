using AutoMapper;
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

        public Task<List<Veterinary>> GetAllVets()
        {
            throw new NotImplementedException();
        }

        public Task<Veterinary> GetVetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Veterinary>> GetVetsByLocation(LocationDTO locationDTO)
        {
            throw new NotImplementedException();
        }

        public Task<Veterinary> UpdateVetDetails(AddVetDTO veterinaryDTO)
        {
            throw new NotImplementedException();
        }
    }
}
