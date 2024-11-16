using AutoMapper;
using CropMS.Models;
using CropMS.Models.DTOs;
using CropMS.Services.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CropMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FarmController : ControllerBase
    {
        private readonly IFarmService _farmService;
        private readonly ResponseDTO _response;
        private readonly IMapper _mapper;

        public FarmController(IFarmService farmService, IMapper mapper)
        {
            _farmService = farmService;
            _mapper = mapper;
            _response = new ResponseDTO();
        }

        [HttpPost]
        public async Task<ActionResult<ResponseDTO>> AddNewFarm(AddFarmerDTO addFarmerDTO)
        {
            try
            {
                var result = await _farmService.AddFarm(addFarmerDTO);

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
        public async Task<ActionResult<List<Farmer>>> GetAllFarms()
        {
            try
            {
                var result = await _farmService.GetAllFarms();
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
        [HttpGet("GetSpecificFarm/{id:guid}")]
        public async Task<ActionResult<Farmer>> GetFarmById(Guid id)
        {
            try
            {
                var farmFound = await _farmService.GetFarmById(id);

                return Ok(farmFound);

            }
            //The exception that was thrown in the service layer is bein handled here
            catch (KeyNotFoundException ex)
            {

                return NotFound(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message, innerException = ex.InnerException?.Message });
            }

        }

        [HttpGet("GetFarmsOfAFarmer/{idNumber:int}")]
        public async Task<ActionResult<List<Farmer>>> GetFarmersFarms(string idNumber)
        {
            try
            {
                var farmsFound = await _farmService.GetFarmerByNationalId(idNumber);

                return Ok(farmsFound);

            }
            //The exception that was thrown in the service layer is bein handled here
            catch (KeyNotFoundException ex)
            {

                return NotFound(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message, innerException = ex.InnerException?.Message });
            }

        }
        [HttpGet("GetFarmsInSpecificLocation/{location:alpha}")]
        public async Task<ActionResult<List<Farmer>>> GetFarmsByLocation(string location)
        {
            try
            {
                var farms = await _farmService.GetFarmByLocation(location);

                if (farms == null || farms.Count == 0)
                {
                    return NotFound(new { message = "No Farms found for the specified location." });
                }

                return Ok(farms);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "An unexpected error occurred.", details = ex.Message });
            }
        }
        [HttpGet("GetFarmsByProduce/{product:alpha}")]
        public async Task<ActionResult<List<Farmer>>> GetFarmsByProduce(string product)
        {
            try
            {
                var farms = await _farmService.GetFarmByProduce(product);

                if (farms == null || farms.Count == 0)
                {
                    return NotFound(new { message = "No Farms were found with the product you are looking for." });
                }

                return Ok(farms);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "An unexpected error occurred.", details = ex.Message });
            }
        }
    }
}
