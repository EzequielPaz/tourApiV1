using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tourApiV1.Application.DTOs.Request;
using tourApiV1.Application.DTOs.Response;
using tourApiV1.Application.Interfaces;
using tourApiV1.Domain.Entities;
using tourApiV1.Infrastructure.Interfaces;

namespace tourApiV1.Application.Services
{
    public class TourService: ITourService
    {
        private readonly ITourRepository _tourRepository;
        public TourService(ITourRepository tourRepository)
        {
            _tourRepository = tourRepository;
        }

        public async Task<TourResponseDTO> CreateAsync(CreateDTORequest tourDto)
        {
            if (tourDto == null)
                throw new ArgumentNullException(nameof(tourDto));

            var tour = new Tour
            {
                Name = tourDto.Name,
                Description = tourDto.Description,
                Destination = tourDto.Destination,
                Price = tourDto.Price,
                DurationDays = tourDto.DurationDays
            };

            try
            {
                var createdTour = await _tourRepository.CreateAsync(tour);

                return new TourResponseDTO
                {
                    Id = createdTour.Id,
                    Name = createdTour.Name,
                    Destination = createdTour.Destination,
                    Price = createdTour.Price
                };
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("duplicate"))
                    throw new InvalidOperationException("El nombre del tour ya está en uso.", ex);

                throw;
            }
        }

        // Mostrar todos los tours
        public async Task<IEnumerable<Tour>> GetAllAsync()
        {
            return await _tourRepository.GetAllAsync();
        }


    }
}
