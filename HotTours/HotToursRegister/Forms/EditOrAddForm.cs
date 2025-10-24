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
            comboBoxDirections.DataBindings.Add("SelectedItem", targetTour, nameof(Tour.Direction));

            dateTimePicker.DataBindings.Add("Value", targetTour, nameof(Tour.DepartureDate));
            numericUpDownNights.DataBindings.Add("Value", targetTour, nameof(Tour.NightsCount));
            numericUpDownPrice.DataBindings.Add("Value", targetTour, nameof(Tour.PricePerPerson));
            numericUpDownTourists.DataBindings.Add("Value", targetTour, nameof(Tour.TouristCount));
            checkBoxWiFi.DataBindings.Add("Checked", targetTour, nameof(Tour.HasWifi));
            numericUpDownExtraCharge.DataBindings.Add("Value", targetTour, nameof(Tour.ExtraCharges));
        }

        private bool ValidateForm()
        {
            return true;
        }

        private void buttonAddOrEdit_Click(object sender, EventArgs e)
        {
            if (!ValidateForm())
            {
                return;
            }

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
