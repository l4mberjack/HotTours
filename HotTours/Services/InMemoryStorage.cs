using HotTours.Entities;
using HotTours.Services.Contracts;
using Services.Contracts;

namespace HotTours.Services
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
        public InMemoryStorage()
        {
            tours = new List<Tour>();
            tours.Clear();
            tours.Add(new Tour { Direction = Direction.Turkey, DepartureDate = new DateTime(2025, 6, 10), NightsCount = 7, PricePerPerson = 55000m, TouristCount = 2, HasWifi = true, ExtraCharges = 5000m });
            tours.Add(new Tour { Direction = Direction.Spain, DepartureDate = new DateTime(2025, 7, 5), NightsCount = 10, PricePerPerson = 72000m, TouristCount = 3, HasWifi = true, ExtraCharges = 8000m });
            tours.Add(new Tour { Direction = Direction.Italy, DepartureDate = new DateTime(2025, 8, 12), NightsCount = 5, PricePerPerson = 48000m, TouristCount = 1, HasWifi = false, ExtraCharges = 2000m });
            tours.Add(new Tour { Direction = Direction.France, DepartureDate = new DateTime(2025, 9, 3), NightsCount = 12, PricePerPerson = 95000m, TouristCount = 4, HasWifi = true, ExtraCharges = 10000m });
            tours.Add(new Tour { Direction = Direction.Sushari, DepartureDate = new DateTime(2025, 10, 1), NightsCount = 3, PricePerPerson = 999m, TouristCount = 5, HasWifi = false, ExtraCharges = 0m });
        }

        public Task<ICollection<Tour>> GetAll(CancellationToken token)
        {
            return Task.FromResult<ICollection<Tour>>(tours);
        }

        public Task<Tour?> GetById(Guid id, CancellationToken token)
        {
            return Task.FromResult(tours.FirstOrDefault(x => x.Id == id));
        }

        public Task Add(Tour tour, CancellationToken token)
        {
            tours.Add(tour);
            return Task.CompletedTask;
        }

        public Task Update(Tour tour, CancellationToken token)
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

        public Task Delete(Guid id, CancellationToken token)
        {
            var tour = tours.FirstOrDefault(x => x.Id == id);
            if (tour != null)
            {
                tours.Remove(tour);
            }
            return Task.CompletedTask;
        }

        public Task<TourStatistics> GetStatistics(CancellationToken token)
        {
            var statistics = new TourStatistics
            {
                TourCount = tours.Count(),
                TotalPriceAllTours = tours.Sum(x => (x.PricePerPerson * x.TouristCount) + x.ExtraCharges),
                TourCountCharge = tours.Where(x => x.ExtraCharges > 0).Count(),
                TourSumCharge = tours.Sum(x => x.ExtraCharges)
            };
            return Task.FromResult(statistics);
        }
    }
}
