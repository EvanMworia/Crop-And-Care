﻿using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
    }
}
