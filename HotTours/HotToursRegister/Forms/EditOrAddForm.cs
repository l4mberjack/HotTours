using HotToursRegister.Models;

namespace HotToursRegister.Forms
{
    public partial class EditOrAddForm : Form
    {
        /// <summary>
        /// Таргетный тур в классе
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
                targetTour = new Tour(
                    direction: Direction.Uknown,
                    departureDate: DateTime.Now,
                    nightsCount: 0,
                    pricePerPerson: 0m,
                    touristCount: 0,
                    hasWifi: false,
                    extraCharges: 0m
                );

                Text = "Добавление тура";
                buttonAddOrEdit.Text = "Добавить";
            }
            else
            {
                targetTour = new Tour(
                    direction: sourceTour.Direction,
                    departureDate: sourceTour.DepartureDate,
                    nightsCount: sourceTour.NightsCount,
                    pricePerPerson: sourceTour.PricePerPerson,
                    touristCount: sourceTour.TouristCount,
                    hasWifi: sourceTour.HasWifi,
                    extraCharges: sourceTour.ExtraCharges
                )
                {
                    Id = sourceTour.Id,
                    TotalCost = sourceTour.TotalCost
                };

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
            // Максимальные цены и доплаты за тур
            numericUpDownPrice.Maximum = 5_000_000m;
            numericUpDownExtraCharge.Maximum = 500_00m;

            // Число туристов и ночей
            numericUpDownTourists.Maximum = 10;
            numericUpDownNights.Maximum = 45;
        }

        private void BindControls()
        {
            comboBoxDirections.DataSource = Enum.GetValues(typeof(Direction));
            comboBoxDirections.DataBindings.Add("SelectedItem", targetTour, nameof(Tour.Direction));

            dateTimePicker.DataBindings.Add("Value", targetTour, nameof(Tour.DepartureDate));
            numericUpDownNights.DataBindings.Add("Value", targetTour, nameof(Tour.NightsCount));
            numericUpDownPrice.DataBindings.Add("Text", targetTour, nameof(Tour.PricePerPerson));
            numericUpDownTourists.DataBindings.Add("Value", targetTour, nameof(Tour.TouristCount));
            checkBoxWiFi.DataBindings.Add("Checked", targetTour, nameof(Tour.HasWifi));
            numericUpDownExtraCharge.DataBindings.Add("Text", targetTour, nameof(Tour.ExtraCharges));
        }

        private bool ValidateForm()
        {
            bool isValid = true;
            errorProvider.Clear();

            if (targetTour.Direction == Direction.Uknown)
            {
                errorProvider.SetError(comboBoxDirections, "Выберите направление тура!");
                isValid = false;
            }

            if (targetTour.DepartureDate < DateTime.Today)
            {
                errorProvider.SetError(dateTimePicker, "Дата не может быть прошедшей!");
                isValid = false;
            }

            if (targetTour.NightsCount < 2)
            {
                errorProvider.SetError(numericUpDownNights, "Количество ночей должно быть больше 2!");
                isValid = false;
            }

            if (targetTour.PricePerPerson < 5000m)
            {
                errorProvider.SetError(numericUpDownPrice, "Цена за отдыхающего должна быть больше 5000 рубчиков!");
                isValid = false;
            }

            if (targetTour.TouristCount < 1)
            {
                errorProvider.SetError(numericUpDownTourists, "Количество туристов должно быть не менее 1!");
                isValid = false;
            }

            return isValid;
        }

        private void buttonAddOrEdit_Click(object sender, EventArgs e)
        {
            if (!ValidateForm())
            {
                return;
            }

            targetTour.TotalCost = targetTour.CalculateTotalCost();
            DialogResult = DialogResult.OK;
            Close();
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
