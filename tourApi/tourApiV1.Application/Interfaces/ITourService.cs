using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tourApiV1.Application.DTOs.Request;
using tourApiV1.Application.DTOs.Response;
using tourApiV1.Domain.Entities;

namespace tourApiV1.Application.Interfaces
{
    public interface ITourService
    {
        //Task<IEnumerable<Tour>> GetAllAsync();
        //Task<TourResponseDTO> CreateAsync(CreateDTORequest tourDto);

        //Task<TourResponseDTO> UpdateAsync(UpdateDTORequest tourDto);
        //Task<TourResponseDTO> DeleteAsync(
        //Task<UpdateTourRequestDTO> GetTourByIdAsync(string id);
        //Task<UpdateTourResponseDTO> UpdateTourAsync(UpdateTourRequestDTO request);

        Task<IEnumerable<Tour>> GetAllAsync();
        Task<TourResponseDTO> CreateAsync(CreateDTORequest tourDto);
        Task<TourResponseDTO> GetTourDetailsByIdAsync(string id);
        Task<UpdateTourRequestDTO> GetTourForEditByIdAsync(string id);
        Task<UpdateTourResponseDTO> UpdateTourAsync(UpdateTourRequestDTO request);

        Task<bool> DeleteTourAsync(string id);

    }
}
