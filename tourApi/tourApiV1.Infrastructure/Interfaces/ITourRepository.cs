using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tourApiV1.Domain.Entities;

namespace tourApiV1.Infrastructure.Interfaces
{
    public interface ITourRepository
    {
        Task<List<Tour>> GetAllAsync();
        Task<Tour> GetByIdAsync(string id);
        Task<Tour> CreateAsync(Tour tour);
        Task UpdateAsync(Tour tour);
        Task DeleteAsync(string id);

        //Task<Tour> GetByIdAsync(int id);
        //Task<Tour> GetByIdAsync(tourApiV1.Application.DTOs.Request.UpdateTourRequestDTO request);
        //Task<Tour> GetByIdAsync(tourApiV1.Application.DTOs.Request.UpdateTourRequestDTO request);
    }
}
