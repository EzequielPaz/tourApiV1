using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;
using tourApiV1.Domain.Entities;
using tourApiV1.Infrastructure.Interfaces;
using tourApiV1.Infrastructure.Persistence;

namespace tourApiV1.Infrastructure.Repository
{
    public class TourRepository : ITourRepository
    {
        private readonly IMongoCollection<Tour> _collection;

        public TourRepository(MongoContext context)
        {
            _collection = context.Tours;
        }

        public async Task<List<Tour>> GetAllAsync()
        {
            return await _collection.Find(_ => true).ToListAsync();
        }

        public async Task<Tour> GetByIdAsync(string id)
        {
            var filter = Builders<Tour>.Filter.Eq("Id", id);
            return await _collection.Find(filter).FirstOrDefaultAsync();
        }

        public async Task<Tour> CreateAsync(Tour tour)
        {
            if (tour == null) throw new ArgumentNullException(nameof(tour));

            // Asegurarse de que el Id sea null para que MongoDB lo genere
            tour.Id = null;
            await _collection.InsertOneAsync(tour);
            return tour;
        }

        public async Task UpdateAsync(string id, Tour tour)
        {
            var filter = Builders<Tour>.Filter.Eq("Id", id);
            await _collection.ReplaceOneAsync(filter, tour);
        }

        public async Task DeleteAsync(string id)
        {
            var filter = Builders<Tour>.Filter.Eq("Id", id);
            await _collection.DeleteOneAsync(filter);
        }
    }
}
