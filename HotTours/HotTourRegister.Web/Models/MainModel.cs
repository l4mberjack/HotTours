using Entities;
using Repository.Contracts;

namespace HotTourRegister.Web.Models
{
    /// <summary>
    /// Модель главной страницы
    /// </summary>
    public class MainModel
    {
        /// <summary>
        /// Список туров
        /// </summary>
        public required IEnumerable<Tour> Tours { get; set; }

        /// <summary>
        /// Статистика туров
        /// </summary>
        public TourStatistics Statistics { get; set; }
    }
}
