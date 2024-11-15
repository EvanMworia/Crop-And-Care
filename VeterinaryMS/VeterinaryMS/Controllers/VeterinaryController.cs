using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VeterinaryMS.Models;
using VeterinaryMS.Models.DTOs;
using VeterinaryMS.Services.IService;

namespace VeterinaryMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VeterinaryController : ControllerBase
    {
        private readonly IVeterinaryService _vetService;
        private readonly ResponseDTO _response;
        private readonly IMapper _mapper;

        public VeterinaryController(IVeterinaryService vetService, IMapper mapper)
        {
            _vetService = vetService;
            _mapper = mapper;
            _response = new ResponseDTO();
        }

        [HttpPost]
        public async Task<ActionResult<ResponseDTO>> AddNewVet(AddVetDTO addVetDTO)
        {
            try
            {
                var result = await _vetService.AddVet(addVetDTO);

                if (result.IsSuccess == true)
                {
                    return Created("", result);
                }
                return BadRequest(result);

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }

        }

        [HttpGet]
        public async Task<ActionResult<List<Veterinary>>> GetAllVets()
        {
            try
            {
                var result = await _vetService.GetAllVets();
                return Ok(result);

            }
            catch (ApplicationException ex)
            {

                return StatusCode(500, new
                {
                    message = ex.Message,
                    innerException = ex.InnerException?.Message // Safely access the inner exception
                });
            }
            catch (Exception ex)
            { 
                return StatusCode(500, new { message = ex.Message, innerException = ex.InnerException?.Message });
            }

        }
        [HttpGet("GetSpecificVet/{id:guid}")]
        public async Task<ActionResult<Veterinary>> GetVetById(Guid id)
        {
            try
            {
                var vetFound = await _vetService.GetVetById(id);
                
                return Ok(vetFound);

            }
            //The exception that was thrown in the service layer is bein handled here
            catch (KeyNotFoundException ex)
            {

                return NotFound(new {message = ex.Message});
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message, innerException = ex.InnerException?.Message });
            }

        }
    }
}
