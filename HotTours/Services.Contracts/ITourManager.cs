using Entities;
using Repository.Contracts;

namespace Services.Contracts
{
    /// <summary>
    /// Менеджер тура
    /// </summary>
    public interface ITourManager
    {
        /// <summary>
        /// Добавление тура
        /// </summary>
        Task Add(Tour tour, CancellationToken token);

        /// <summary>
        /// Удаление тура
        /// </summary>
        Task Delete(Guid id, CancellationToken token);

        /// <summary>
        /// Получение всех туров
        /// </summary>
        Task<ICollection<Tour>> GetAll(CancellationToken token);

        /// <summary>
        /// Получение по id тура
        /// </summary>
        Task<Tour?> GetById(Guid id, CancellationToken token);

        /// <summary>
        /// Обновление тура
        /// </summary>
        Task Update(Tour tour, CancellationToken token);

        /// <summary>
        /// Получение статистики туров
        /// </summary>
        Task<TourStatistics> GetStatistics(CancellationToken token);
    }
}
