using Entities;
using Services.Contracts;

namespace Services
{
    /// <summary>
    /// Сервис для доступа к турам в памяти
    /// </summary>
    public class InMemoryStorage : ITourStorage
    {
        private List<Tour> tours;

        /// <summary>
        /// Инициализация экземпляра хранилища
        /// </summary>
        public InMemoryStorage(IEnumerable<Tour>? initialData = null)
        {
            tours = initialData?.ToList() ?? new List<Tour>();
        }

        Task<ICollection<Tour>> ITourStorage.GetAll(CancellationToken token)
        {
            return Task.FromResult<ICollection<Tour>>(tours);
        }

        Task<Tour?> ITourStorage.GetById(Guid id, CancellationToken token)
        {
            return Task.FromResult(tours.FirstOrDefault(x => x.Id == id));
        }

        Task ITourStorage.Add(Tour tour, CancellationToken token)
        {
            tours.Add(tour);
            return Task.CompletedTask;
        }

        Task ITourStorage.Update(Tour tour, CancellationToken token)
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

        Task ITourStorage.Delete(Guid id, CancellationToken token)
        {
            var tour = tours.FirstOrDefault(x => x.Id == id);
            if (tour != null)
            {
                tours.Remove(tour);
            }
            return Task.CompletedTask;
        }

        Task<TourStatistics> ITourStorage.GetStatistics(CancellationToken token)
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
