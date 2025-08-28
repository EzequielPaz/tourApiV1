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

        //public async Task UpdateTourAsync(string id, Tour tour)
        //{
        //    await _tourRepository.UpdateAsync(id, tour);
        //}

        // Obtener datos del tour por ID
        public async Task<TourResponseDTO> GetTourByIdAsync(string id)
        {
            var tour = await _tourRepository.GetByIdAsync(id);
            if (tour == null) return null;

            return new TourResponseDTO
            {
                Id = tour.Id,
                Name = tour.Name,
                Description = tour.Description,
                Destination = tour.Destination,
                Price = tour.Price,
                DurationDays = tour.DurationDays,
                AvailableSeats = tour.AvailableSeats
            };
        }

        public async Task<TourResponseDTO> GetTourDetailsByIdAsync(string id)
        {
            var tour = await _tourRepository.GetByIdAsync(id);
            if (tour == null) return null;

            return new TourResponseDTO
            {
                Id = tour.Id,
                Name = tour.Name,
                Description = tour.Description,
                Destination = tour.Destination,
                Price = tour.Price,
                DurationDays = tour.DurationDays,
                AvailableSeats = tour.AvailableSeats
            };
        }

        public async Task<UpdateTourRequestDTO> GetTourForEditByIdAsync(string id)
        {
            var tour = await _tourRepository.GetByIdAsync(id);
            if (tour == null) return null;

            return new UpdateTourRequestDTO
            {
                Name = tour.Name,
                Description = tour.Description,
                Destination = tour.Destination,
                Price = tour.Price,
                DurationDays = tour.DurationDays,
                AvailableSeats = tour.AvailableSeats
            };
        }

        public async Task<UpdateTourResponseDTO> UpdateTourAsync(UpdateTourRequestDTO request)
        {
            if (string.IsNullOrEmpty(request.Id))
                throw new ArgumentException("El ID del tour no puede ser nulo.");

            var tour = await _tourRepository.GetByIdAsync(request.Id);
            if (tour == null)
                return null;

            tour.Name = request.Name;
            tour.Description = request.Description;
            tour.Destination = request.Destination;
            tour.Price = request.Price;
            tour.DurationDays = request.DurationDays;
            tour.AvailableSeats = request.AvailableSeats;
            tour.StartTime = request.StartTime;

            await _tourRepository.UpdateAsync(tour);

            return new UpdateTourResponseDTO
            {
                Id = tour.Id,
                Name = tour.Name,
                Description = tour.Description,
                Destination = tour.Destination,
                Price = tour.Price,
                DurationDays = tour.DurationDays,
                AvailableSeats = tour.AvailableSeats,
                StartTime = tour.StartTime
            };
        }

        public async Task<bool> DeleteTourAsync(string id)
        {
            var tour = await _tourRepository.GetByIdAsync(id);
            if (tour == null) return false;

            await _tourRepository.DeleteAsync(id);
            return true;
        }



    }
}
