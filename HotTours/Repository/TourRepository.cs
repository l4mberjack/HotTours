using Entities;
using HotTourRegister.Context;
using Repository.Contracts;
using Microsoft.EntityFrameworkCore;

namespace Repository
{
    /// <summary>
    /// Репозиторий для доступа к турам
    /// </summary>
    public class TourRepository(TourContext context) : IStorage
    {
        public async Task Add(Tour tour, CancellationToken token)
        {
            context.Add(tour);
            await context.SaveChangesAsync(token);
        }
        public async Task Delete(Tour tour, CancellationToken token)
        {
            context.Remove(tour);
            await context.SaveChangesAsync(token);
        }
        public async Task<ICollection<Tour>> GetAll(CancellationToken token)
        {
            return await context.Set<Tour>().ToListAsync(token);
        }
        public async Task<Tour?> GetById(Guid id, CancellationToken token)
        {
            return await context.Set<Tour>().FirstOrDefaultAsync(x => x.Id == id, token);
        }
        public async Task<TourStatistics> GetStatistics(CancellationToken token)
        {
            var tourSet = context.Set<Tour>();

            var tourCount = await tourSet.CountAsync(token);
            var totalPriceAllTours = await tourSet
                .SumAsync(x => x.PricePerPerson * x.TouristCount + x.ExtraCharges, token);
            var tourCountCharge = await tourSet
                .CountAsync(x => x.ExtraCharges > 0, token);
            var tourSumCharge = await tourSet
                .SumAsync(x => x.ExtraCharges, token);

            var statistics = new TourStatistics
            {
                TourCount = tourCount,
                TotalPriceAllTours = totalPriceAllTours,
                TourCountCharge = tourCountCharge,
                TourSumCharge = tourSumCharge
            };

            return statistics;
        }
        public async Task Update(Tour tour, CancellationToken token)
        {
            context.Update(tour);
            await context.SaveChangesAsync(token);
        }
    }
}
