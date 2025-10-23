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

        private void buttonAddOrEdit_Click(object sender, EventArgs e)
        {
            targetTour.TotalCost = targetTour.CalculateTotalCost();
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
