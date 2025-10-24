using System.ComponentModel.DataAnnotations;
using dataGridView.App.Infrostructure;
using HotToursRegister.Constants;
using HotToursRegister.Models;

namespace HotToursRegister.Forms
{
    public partial class EditOrAddForm : Form
    {
        /// <summary>
        ///  Текущий тур
        /// </summary>
        private readonly Tour targetTour;

        /// <summary>
        /// Свойство для текущего тура
        /// </summary>
        public Tour CurrentTour => targetTour;

        /// <summary>
        /// Форма добавления/редактирования записи
        /// </summary>
        public EditOrAddForm(Tour? sourceTour = null)
        {
            InitializeComponent();

            if (sourceTour == null)
            {
                targetTour = new Tour
                {
                    Id = Guid.NewGuid(),
                    Direction = Direction.Uknown,
                    DepartureDate = DateTime.Now,
                    NightsCount = 0,
                    PricePerPerson = 0m,
                    TouristCount = 0,
                    HasWifi = false,
                    ExtraCharges = 0m
                };

                Text = "Добавление тура";
                buttonAddOrEdit.Text = "Добавить";
            }
            else
            {
                targetTour = sourceTour.Clone();

                Text = "Редактирование тура";
                buttonAddOrEdit.Text = "Сохранить";
            }

            BindControls();
            SetUpFields();
        }

        /// <summary>
        /// Настройка полей ввода
        /// </summary>
        private void SetUpFields()
        {
            numericUpDownPrice.Maximum = TourLimits.MaxPricePerPerson;
            numericUpDownPrice.Increment = 1000;
            numericUpDownExtraCharge.Maximum = TourLimits.MaxExtraCharges;
            numericUpDownExtraCharge.Increment = 1000;

            numericUpDownTourists.Maximum = TourLimits.MaxTourists;
            numericUpDownNights.Maximum = TourLimits.MaxNights;

            comboBoxDirections.DataSource = Enum.GetValues(typeof(Direction));
        }

        private void BindControls()
        {
            comboBoxDirections.DataSource = Enum.GetValues(typeof(Direction));
            comboBoxDirections.AddBinding(x => x.SelectedItem!, targetTour, x => x.Direction, errorProvider);

            dateTimePicker.AddBinding(x => x.Value, targetTour, x => x.DepartureDate, errorProvider);
            numericUpDownNights.AddBinding(x => x.Value, targetTour, x => x.NightsCount, errorProvider);
            numericUpDownPrice.AddBinding(x => x.Value, targetTour, x => x.PricePerPerson, errorProvider);
            numericUpDownTourists.AddBinding(x => x.Value, targetTour, x => x.TouristCount, errorProvider);
            checkBoxWiFi.AddBinding(x => x.Checked, targetTour, x => x.HasWifi);
            numericUpDownExtraCharge.AddBinding(x => x.Value, targetTour, x => x.ExtraCharges, errorProvider);
        }


        private void buttonAddOrEdit_Click(object sender, EventArgs e)
        {

            errorProvider.Clear();

            var context = new ValidationContext(targetTour);
            var results = new List<ValidationResult>();

            bool isValid = Validator.TryValidateObject(targetTour, context, results, true);

            if (isValid)
            {
                DialogResult = DialogResult.OK;
                Close();
                return;
            }

            // Пробегаемся по ошибкам и отображаем их на нужных контролах
            foreach (var validationResult in results)
            {
                foreach (var memberName in validationResult.MemberNames)
                {
                    Control? control = memberName switch
                    {
                        nameof(Tour.Direction) => comboBoxDirections,
                        nameof(Tour.DepartureDate) => dateTimePicker,
                        nameof(Tour.NightsCount) => numericUpDownNights,
                        nameof(Tour.PricePerPerson) => numericUpDownPrice,
                        nameof(Tour.TouristCount) => numericUpDownTourists,
                        nameof(Tour.ExtraCharges) => numericUpDownExtraCharge,
                        _ => null
                    };

                    if (control != null)
                    {
                        errorProvider.SetError(control, validationResult.ErrorMessage);
                    }
                }
            }

            MessageBox.Show(
                "Пожалуйста, исправьте ошибки в форме перед сохранением.",
                "Ошибки валидации",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            var dialogRes = MessageBox.Show("Вы уверены что хотите выйти?", "Выход", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogRes == DialogResult.Yes)
            {
                Close();
            }
            else
            {
                return;
            }
        }
    }
}
