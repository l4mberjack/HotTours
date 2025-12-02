using Entities;
using Services.Contracts;

namespace HotToursRegister.Forms
{
    public partial class MainForm : Form
    {
        private ITourStorage tourStorage;
        private BindingSource bindingSource = new();

        /// <summary>
        /// Главная форма
        /// </summary>
        public MainForm(ITourStorage tourStorage)
        {
            InitializeComponent();
            this.tourStorage = tourStorage;
            SetupDataGrid();
        }

        /// <summary>
        /// Обновление статистики
        /// </summary>
        private async Task SetStatistics()
        {
            var statistics = await tourStorage.GetStatistics(CancellationToken.None);
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
            var tours = await tourStorage.GetAll(CancellationToken.None);
            bindingSource.DataSource = tours.ToList();
            mainGrid.DataSource = bindingSource;
            await SetStatistics();
        }

        private async Task OnUpdate()
        {
            var tours = await tourStorage.GetAll(CancellationToken.None);
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
                await tourStorage.Delete(tour.Id, CancellationToken.None);
                await OnUpdate();
            }
        }

        private async void AddToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var AddOrEditForm = new EditOrAddForm();

            if (AddOrEditForm.ShowDialog(this) == DialogResult.OK)
            {
                await tourStorage.Add(AddOrEditForm.CurrentTour, CancellationToken.None);
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
                await tourStorage.Update(editForm.CurrentTour, CancellationToken.None);
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
