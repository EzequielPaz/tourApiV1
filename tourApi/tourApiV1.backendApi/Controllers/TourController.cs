using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ActionConstraints;
using tourApiV1.Application.DTOs.Request;
using tourApiV1.Application.DTOs.Response;
using tourApiV1.Application.Interfaces;
using tourApiV1.Domain.Entities;

namespace tourApiV1.backendApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TourController : Controller
    {
        private readonly ITourService _tourService;
        
        public TourController(ITourService tourService)
        {
            _tourService = tourService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllTours()
        {
            var tours = await _tourService.GetAllAsync();
            return Ok(tours);
        }

        [HttpPost]
        public async Task<ActionResult<TourResponseDTO>> CreateTour([FromBody] CreateDTORequest tourDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var createdTour = await _tourService.CreateAsync(tourDto);
                return Ok(createdTour);
            }
            catch (InvalidOperationException ex)
            {
                return Conflict(new { message = ex.Message }); // 409 si ya existe
            }
        }

        // Ejemplo de GET por I

    }
}
