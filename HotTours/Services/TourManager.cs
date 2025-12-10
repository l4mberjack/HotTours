using System.Diagnostics;
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
        private readonly IStorage storage;
        private readonly ILogger logger;
        public TourManager(IStorage storage, ILoggerFactory loggerFactory)
        {
            this.storage = storage;
            logger = loggerFactory.CreateLogger<TourManager>();
        }

        /// <summary>
        /// Получить все записи
        /// </summary>
        public async Task<ICollection<Tour>> GetAll(CancellationToken token)
        {
            var sw = Stopwatch.StartNew();
            try
            {
                return await storage.GetAll(token);
            }
            finally
            {
                sw.Stop();
                logger.LogInformation($"GetAll выполнен за {sw.ElapsedMilliseconds} мс");
            }
        }

        /// <summary>
        /// Получить запись по id
        /// </summary>
        public async Task<Tour?> GetById(Guid id, CancellationToken token)
        {
            var sw = Stopwatch.StartNew();
            try
            {
                return await storage.GetById(id, token);
            }
            finally
            {
                sw.Stop();
                logger.LogInformation($"GetById выполнен за {sw.ElapsedMilliseconds} мс");
            }
        }

        /// <summary>
        /// Добавить
        /// </summary>
        public async Task Add(Tour tour, CancellationToken token)
        {
            var sw = Stopwatch.StartNew();
            try
            {
                await storage.Add(tour, token);
            }
            finally
            {
                sw.Stop();
                logger.LogInformation($"Add выполнен за {sw.ElapsedMilliseconds} мс");
            }
        }

        /// <summary>
        /// Обновить
        /// </summary>
        public async Task Update(Tour tour, CancellationToken token)
        {
            var sw = Stopwatch.StartNew();
            try
            {
                await storage.Update(tour, token);
            }
            finally
            {
                sw.Stop();
                logger.LogInformation($"Update выполнен за {sw.ElapsedMilliseconds} мс");
            }
        }

        /// <summary>
        /// Удалить
        /// </summary>
        public async Task Delete(Tour tour, CancellationToken token)
        {
            var sw = Stopwatch.StartNew();
            try
            {
                await storage.Delete(tour, token);
            }
            finally
            {
                sw.Stop();
                logger.LogInformation($"Delete выполнен за {sw.ElapsedMilliseconds} мс");
            }
        }

        /// <summary>
        /// Получить статистику
        /// </summary>
        public async Task<TourStatistics> GetStatistics(CancellationToken token)
        {
            var sw = Stopwatch.StartNew();
            try
            {
                return await storage.GetStatistics(token);
            }
            finally
            {
                sw.Stop();
                logger.LogInformation($"GetStatistics выполнен за {sw.ElapsedMilliseconds} мс");
            }
        }
    }
}
