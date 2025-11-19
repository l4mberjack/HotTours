namespace Services.Contracts
{
    /// <summary>
    /// Класс хранения статистики туров
    /// </summary>
    public class TourStatistics
    {
        /// <summary>
        /// Количество туров
        /// </summary>
        public int TourCount { get; set; }

        /// <summary>
        /// Общая сумма за все туры
        /// </summary>
        public decimal TotalPriceAllTours { get; set; }

        /// <summary>
        /// Количество туров с доплатой
        /// </summary>
        public int TourCountCharge { get; set; }

        /// <summary>
        /// Сумма доплат
        /// </summary>
        public decimal TourSumCharge { get; set; }
    }
}
