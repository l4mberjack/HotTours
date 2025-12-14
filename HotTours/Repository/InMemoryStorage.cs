using Entities;
using Repository.Contracts;

namespace Repository
{
    /// <summary>
    /// Сервис для доступа к турам в памяти
    /// </summary>
    public class InMemoryStorage : IStorage
    {
        private List<Tour> tours;

        /// <summary>
        /// Инициализация экземпляра хранилища
        /// </summary>
        public InMemoryStorage(IEnumerable<Tour>? initialData = null)
        {
            tours = initialData?.ToList() ?? new List<Tour>();
        }

        Task<ICollection<Tour>> IStorage.GetAll(CancellationToken token)
        {
            return Task.FromResult<ICollection<Tour>>(tours);
        }

        Task<Tour?> IStorage.GetById(Guid id, CancellationToken token)
        {
            return Task.FromResult(tours.FirstOrDefault(x => x.Id == id));
        }

        Task IStorage.Add(Tour tour, CancellationToken token)
        {
            tours.Add(tour);
            return Task.CompletedTask;
        }

        Task IStorage.Update(Tour tour, CancellationToken token)
        {
            var exitsTour = tours.FirstOrDefault(x => x.Id == tour.Id);
            if (exitsTour != null)
            {
                exitsTour.Id = tour.Id;
                exitsTour.PricePerPerson = tour.PricePerPerson;
                exitsTour.DepartureDate = tour.DepartureDate;
                exitsTour.HasWifi = tour.HasWifi;
                exitsTour.NightsCount = tour.NightsCount;
                exitsTour.Direction = tour.Direction;
                exitsTour.ExtraCharges = tour.ExtraCharges;
                exitsTour.TouristCount = tour.TouristCount;
            }
            return Task.CompletedTask;
        }

        Task IStorage.Delete(Tour tour, CancellationToken token)
        {
            var record = tours.FirstOrDefault(x => x.Id == tour.Id);
            if (record != null)
            {
                tours.Remove(record);
            }
            return Task.CompletedTask;
        }

        Task<TourStatistics> IStorage.GetStatistics(CancellationToken token)
        {
            var statistics = new TourStatistics
            {
                TourCount = tours.Count(),
                TotalPriceAllTours = tours.Sum(x => x.PricePerPerson * x.TouristCount + x.ExtraCharges),
                TourCountCharge = tours.Where(x => x.ExtraCharges > 0).Count(),
                TourSumCharge = tours.Sum(x => x.ExtraCharges)
            };
            return Task.FromResult(statistics);
        }
    }
}
