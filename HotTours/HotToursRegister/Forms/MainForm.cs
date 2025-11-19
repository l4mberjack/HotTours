using System.ComponentModel;
using HotToursRegister.Forms;
using HotToursRegister.Models;

namespace HotToursRegister.Forms
{
    public partial class MainForm : Form
    {
        /// <summary>
        /// Список туров
        /// </summary>
        private BindingList<Tour> tourList = new();

        private BindingSource toursBinding = new();

        public MainForm()
        {
            InitializeComponent();

            LoadTours();
            SetupDataGrid();

            SetStatistics();
        }

        /// <summary>
        /// Обновление статистики
        /// </summary>
        private void SetStatistics()
        {
            toolStripStatusLabelToursCount.Text = $"Количество всех туров: {tourList.Count}";
            toolStripStatusLabelSumOfTours.Text = $"Общая сумма за все туры: {tourList.Sum(x => x.TotalCost)}";
            toolStripStatusLabelToursWithExtraCharge.Text = $"Количество туров с доплатой: {tourList.Where(x => x.ExtraCharges > 0).Count()}";
            toolStripStatusLabelSumOfExtraCharge.Text = $"Общая сумма доплат: {tourList.Sum(x => x.ExtraCharges)}";
        }

        /// <summary>
        /// Настройка грида
        /// </summary>
        private void SetupDataGrid()
        {
            mainGrid.AutoGenerateColumns = false;

            ColumnDirection.DataPropertyName = nameof(Tour.Direction);
            ColumnDepartureDate.DataPropertyName = nameof(Tour.DepartureDate);
            ColumnCountNights.DataPropertyName = nameof(Tour.NightsCount);
            ColumnPricePerPerson.DataPropertyName = nameof(Tour.PricePerPerson);
            ColumnTouristsCount.DataPropertyName = nameof(Tour.TouristCount);
            ColumnWiFi.DataPropertyName = nameof(Tour.HasWifi);
            ColumnExtraCharges.DataPropertyName = nameof(Tour.ExtraCharges);
            ColumnTotalCost.DataPropertyName = nameof(Tour.TotalCost);

            ColumnDirection.DataSource = Enum.GetValues(typeof(Direction));

            toursBinding.DataSource = tourList;
            mainGrid.DataSource = toursBinding;
        }

        /// <summary>
        /// Загрузка туров/записей
        /// </summary>
        private void LoadTours()
        {
            tourList.Add(new Tour { Direction = Direction.Turkey, DepartureDate = new DateTime(2025, 6, 10), NightsCount = 7, PricePerPerson = 55000m, TouristCount = 2, HasWifi = true, ExtraCharges = 5000m });
            tourList.Add(new Tour { Direction = Direction.Spain, DepartureDate = new DateTime(2025, 7, 5), NightsCount = 10, PricePerPerson = 72000m, TouristCount = 3, HasWifi = true, ExtraCharges = 8000m });
            tourList.Add(new Tour { Direction = Direction.Italy, DepartureDate = new DateTime(2025, 8, 12), NightsCount = 5, PricePerPerson = 48000m, TouristCount = 1, HasWifi = false, ExtraCharges = 2000m });
            tourList.Add(new Tour { Direction = Direction.France, DepartureDate = new DateTime(2025, 9, 3), NightsCount = 12, PricePerPerson = 95000m, TouristCount = 4, HasWifi = true, ExtraCharges = 10000m });
            tourList.Add(new Tour { Direction = Direction.Sushari, DepartureDate = new DateTime(2025, 10, 1), NightsCount = 3, PricePerPerson = 999m, TouristCount = 5, HasWifi = false, ExtraCharges = 0m });
        }


        private void DeleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (mainGrid.SelectedRows.Count == 0)
            {
                MessageBox.Show("Выберите тур для удаления!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var selectedTour = (Tour)mainGrid.SelectedRows[0].DataBoundItem;

            var confirm = MessageBox.Show(
                $"Удалить тур в \"{selectedTour.Direction}\"?",
                "Удаление тура",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (confirm == DialogResult.Yes)
            {
                tourList.Remove(selectedTour);
                SetStatistics();
            }
        }

        private void AddToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var AddOrEditForm = new EditOrAddForm();

            if (AddOrEditForm.ShowDialog(this) == DialogResult.OK)
            {
                tourList.Add(AddOrEditForm.CurrentTour);

                SetStatistics();
            }
        }

        private void EditToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (mainGrid.SelectedRows.Count == 0)
            {
                MessageBox.Show("Выберите тур для редактирования.", "Редактирование", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var selectedTour = (Tour)mainGrid.SelectedRows[0].DataBoundItem;

            var editForm = new EditOrAddForm(selectedTour);

            if (editForm.ShowDialog(this) == DialogResult.OK)
            {
                var index = tourList.IndexOf(selectedTour);

                if (index >= 0)
                {
                    tourList[index] = editForm.CurrentTour;

                    SetStatistics();
                }
            }
        }
    }
}
