using Entities;
using Microsoft.Extensions.Logging;
using Repository.Contracts;
using Services.Contracts;

namespace Services
{
    /// <summary>
    /// Менеджер тура
    /// </summary>
    public class TourManager : ITourManager
    {
        private readonly ITourStorage storage;
        private readonly ILogger logger;
        public TourManager(ITourStorage storage, ILoggerFactory loggerFactory)
        {
            this.storage = storage;
            logger = loggerFactory.CreateLogger<TourManager>();
        }

        /// <summary>
        /// Получить все записи
        /// </summary>
        public Task<ICollection<Tour>> GetAll(CancellationToken token)
        => storage.GetAll(token);

        /// <summary>
        /// Получить запись по id
        /// </summary>
        public Task<Tour?> GetById(Guid id, CancellationToken token)
            => storage.GetById(id, token);

        /// <summary>
        /// Добавить
        /// </summary>
        public Task Add(Tour tour, CancellationToken token)
            => storage.Add(tour, token);

        /// <summary>
        /// Обновить
        /// </summary>
        public Task Update(Tour tour, CancellationToken token)
            => storage.Update(tour, token);

        /// <summary>
        /// Удалить
        /// </summary>
        public Task Delete(Guid id, CancellationToken token)
            => storage.Delete(id, token);

        /// <summary>
        /// Получить статистику
        /// </summary>
        public Task<TourStatistics> GetStatistics(CancellationToken token)
            => storage.GetStatistics(token);
    }
}
