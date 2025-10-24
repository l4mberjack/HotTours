
using System.ComponentModel.DataAnnotations;
using HotToursRegister.Constants;

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
        /// [Required(ErrorMessage = "Выберите направление тура!")]
        [EnumDataType(typeof(Direction), ErrorMessage = "Некорректное направление тура!")]
        public Direction Direction { get; set; }

        /// <summary>
        /// Дата вылета
        /// </summary>
        [Required]
        [CustomValidation(typeof(Tour), nameof(ValidateDepartureDate))]
        public DateTime DepartureDate { get; set; }

        /// <summary>
        /// Количество ночей
        /// </summary>
        [Range(TourLimits.MinNights, TourLimits.MaxNights, ErrorMessage = "Количество ночей должно быть от 2 до 45")]
        public int NightsCount { get; set; }

        /// <summary>
        /// Стоимость за одного человека
        /// </summary>
        [Range((double)TourLimits.MinPricePerPerson, (double)TourLimits.MaxPricePerPerson, ErrorMessage = "Цена за отдыхающего должна быть от 5000 до 5 000 000")]
        public decimal PricePerPerson { get; set; }

        /// <summary>
        /// Количество отдыхающих
        /// </summary>
        [Range(TourLimits.MinTourists, TourLimits.MaxTourists, ErrorMessage = "Количество туристов должно быть от 1 до 10")]
        public int TouristCount { get; set; }

        /// <summary>
        /// Наличие Wi-Fi в отеле
        /// </summary>
        public bool HasWifi { get; set; }

        /// <summary>
        /// Доплаты 
        /// </summary>
        [Range(0, (double)TourLimits.MaxExtraCharges, ErrorMessage = "Доплаты не могут превышать 500 000")]
        public decimal ExtraCharges { get; set; }

        /// <summary>
        /// Общая стоимость тура
        /// </summary>
        public decimal TotalCost => (PricePerPerson * TouristCount) + ExtraCharges;

        /// <summary>
        /// Создание копии
        /// </summary>
        /// <returns></returns>
        public Tour Clone()
        {
            return (Tour)MemberwiseClone();
        }

        /// <summary>
        /// Валидация даты
        /// </summary>
        public static ValidationResult? ValidateDepartureDate(DateTime date)
        {
            return date < DateTime.Today
                ? new ValidationResult("Дата вылета не может быть в прошлом!")
                : ValidationResult.Success;
        }
    }
}
