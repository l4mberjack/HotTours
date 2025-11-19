namespace HotTours.Entities.Contracts
{
    /// <summary>
    /// Лимиты значений в тур
    /// </summary>
    public class TourLimits
    {
        /// <summary>
        /// Максимальная цена за человека
        /// </summary>
        public const decimal MaxPricePerPerson = 5_000_000m;

        /// <summary>
        /// Максимальная 
        /// </summary>
        public const decimal MaxExtraCharges = 500_000m;
        public const decimal MinPricePerPerson = 5_000m;

        // Количество
        public const int MaxTourists = 10;
        public const int MaxNights = 45;
        public const int MinNights = 2;
        public const int MinTourists = 1;
    }
}
