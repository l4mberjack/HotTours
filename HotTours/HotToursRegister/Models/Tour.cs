
namespace HotToursRegister.Models
{
    /// <summary>
    /// Класс, описывающий туристическую поездку
    /// </summary>
    public class Tour
    {
        /// <summary>
        /// Уникальный идентификатор тура
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Направление тура
        /// </summary>
        public Direction Direction { get; set; }

        /// <summary>
        /// Дата вылета
        /// </summary>
        public DateTime DepartureDate { get; set; }

        /// <summary>
        /// Количество ночей
        /// </summary>
        public int NightsCount { get; set; }

        /// <summary>
        /// Стоимость за одного человека
        /// </summary>
        public decimal PricePerPerson { get; set; }

        /// <summary>
        /// Количество отдыхающих
        /// </summary>
        public int TouristCount { get; set; }

        /// <summary>
        /// Наличие Wi-Fi в отеле
        /// </summary>
        public bool HasWifi { get; set; }

        /// <summary>
        /// Доплаты 
        /// </summary>
        public decimal ExtraCharges { get; set; }

        /// <summary>
        /// Общая стоимость тура
        /// </summary>
        public decimal TotalCost { get; set; }

        /// <summary>
        /// Расчёт общей стоимости тура
        /// </summary>
        public decimal CalculateTotalCost()
        {
            TotalCost = (PricePerPerson * TouristCount) + ExtraCharges;
            return TotalCost;
        }

        /// <summary>
        /// Конструктор класса Tour
        /// </summary>
        public Tour(
            Direction direction,
            DateTime departureDate,
            int nightsCount,
            decimal pricePerPerson,
            int touristCount,
            bool hasWifi,
            decimal extraCharges)
        {
            Id = Guid.NewGuid();
            Direction = direction;
            DepartureDate = departureDate;
            NightsCount = nightsCount;
            PricePerPerson = pricePerPerson;
            TouristCount = touristCount;
            HasWifi = hasWifi;
            ExtraCharges = extraCharges;
            TotalCost = CalculateTotalCost();
        }
    }
}
