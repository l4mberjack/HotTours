using Entities;
using Repository.Contracts;
using Services.Contracts;

namespace HotToursRegister.Forms
{
    public partial class MainForm : Form
    {
        private ITourManager tourManager;
        private BindingSource bindingSource = new();

        /// <summary>
        /// Главная форма
        /// </summary>
        public MainForm(ITourManager tourManager)
        {
            InitializeComponent();
            this.tourManager = tourManager;
            SetupDataGrid();
            LoadTestData();
        }

        private async void LoadTestData()
        {
            var tours = new List<Tour> {
            new() { Direction = Direction.Turkey, DepartureDate = new DateTime(2025, 6, 10), NightsCount = 7, PricePerPerson = 55000m, TouristCount = 2, HasWifi = true, ExtraCharges = 5000m },
            new() { Direction = Direction.Spain, DepartureDate = new DateTime(2025, 7, 5), NightsCount = 10, PricePerPerson = 72000m, TouristCount = 3, HasWifi = true, ExtraCharges = 8000m },
            new() { Direction = Direction.Italy, DepartureDate = new DateTime(2025, 8, 12), NightsCount = 5, PricePerPerson = 48000m, TouristCount = 1, HasWifi = false, ExtraCharges = 2000m },
            new() { Direction = Direction.France, DepartureDate = new DateTime(2025, 9, 3), NightsCount = 12, PricePerPerson = 95000m, TouristCount = 4, HasWifi = true, ExtraCharges = 10000m },
            new() { Direction = Direction.Sushari, DepartureDate = new DateTime(2025, 10, 1), NightsCount = 3, PricePerPerson = 999m, TouristCount = 5, HasWifi = false, ExtraCharges = 0m }
            };

            foreach (var tour in tours)
            {
                await tourManager.Add(tour, CancellationToken.None);
            }
        }

        /// <summary>
        /// Обновление статистики
        /// </summary>
        private async Task SetStatistics()
        {
            var statistics = await tourManager.GetStatistics(CancellationToken.None);
            toolStripStatusLabelSumOfExtraCharge.Text = $"Сумма доплат: {statistics.TourSumCharge}";
            toolStripStatusLabelSumOfTours.Text = $"Сумма за все туры: {statistics.TotalPriceAllTours}";
            toolStripStatusLabelToursCount.Text = $"Количество туров: {statistics.TourCount}";
            toolStripStatusLabelToursWithExtraCharge.Text = $"Количество туров с доплатами: {statistics.TourCountCharge}";
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

            ColumnDirection.DataSource = Enum.GetValues(typeof(Direction));
        }

        private async Task LoadData()
        {
            var tours = await tourManager.GetAll(CancellationToken.None);
            bindingSource.DataSource = tours.ToList();
            mainGrid.DataSource = bindingSource;
            await SetStatistics();
        }

        private async Task OnUpdate()
        {
            var tours = await tourManager.GetAll(CancellationToken.None);
            bindingSource.DataSource = tours.ToList();
            bindingSource.ResetBindings(false);
            await SetStatistics();
        }


        private async void DeleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (mainGrid.SelectedRows.Count == 0)
            {
                MessageBox.Show("Выберите тур для удаления!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var tour = (Tour)mainGrid.SelectedRows[0].DataBoundItem;
            if (MessageBox.Show($"Удалить '{tour.Direction}'?", "Подтверждение", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                await tourManager.Delete(tour, CancellationToken.None);
                await OnUpdate();
            }
        }

        private async void AddToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var AddOrEditForm = new EditOrAddForm();

            if (AddOrEditForm.ShowDialog(this) == DialogResult.OK)
            {
                await tourManager.Add(AddOrEditForm.CurrentTour, CancellationToken.None);
                await OnUpdate();
            }
        }

        private async void EditToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (mainGrid.SelectedRows.Count == 0)
            {
                MessageBox.Show("Выберите тур для редактирования.", "Редактирование", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var tour = (Tour)mainGrid.SelectedRows[0].DataBoundItem;
            var editForm = new EditOrAddForm(tour);
            if (editForm.ShowDialog() == DialogResult.OK)
            {
                await tourManager.Update(editForm.CurrentTour, CancellationToken.None);
                await OnUpdate();
            }
        }

        private async void MainForm_Load(object sender, EventArgs e)
        {
            await LoadData();
        }

        private void mainGrid_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (mainGrid.Columns[e.ColumnIndex].Name == "ColumnTotalCost")
            {
                if (mainGrid.Rows[e.RowIndex].DataBoundItem is Tour tour)
                {
                    e.Value = (tour.PricePerPerson * tour.TouristCount) + tour.ExtraCharges;
                }
            }
        }
    }
}
