using System.ComponentModel.DataAnnotations;

namespace HotTours.Entities.Validators
{
    /// <summary>
    /// Проверка, что дата вылета не раньше текущей даты
    /// </summary>
    public class DepartureDateAttribute : ValidationAttribute
    {
        public DepartureDateAttribute()
        {
            ErrorMessage = "Дата вылета не может быть в прошлом!";
        }

        /// <summary>
        /// Валидация даты
        /// </summary>
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value is DateTime date && date < DateTime.Today)
            {
                return new ValidationResult(ErrorMessage);
            }

            return ValidationResult.Success;
        }
    }
}
