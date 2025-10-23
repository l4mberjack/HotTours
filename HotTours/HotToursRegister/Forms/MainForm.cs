using System.ComponentModel;
using HotToursRegister.Forms;
using HotToursRegister.Models;

namespace HotToursRegister
{
    public partial class MainForm : Form
    {
        /// <summary>
        /// Список туров
        /// </summary>
        public BindingList<Tour> tourList = new();

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
            toursBinding.DataSource = tourList;
            mainGrid.DataSource = toursBinding;

            // Настройка заголовков
            mainGrid.Columns[nameof(Tour.Id)].Visible = false;

            mainGrid.Columns[nameof(Tour.Direction)].HeaderText = "Направление";
            mainGrid.Columns[nameof(Tour.DepartureDate)].HeaderText = "Дата вылета";
            mainGrid.Columns[nameof(Tour.NightsCount)].HeaderText = "Ночей";
            mainGrid.Columns[nameof(Tour.PricePerPerson)].HeaderText = "Цена за отдыхающего (₽уб)";
            mainGrid.Columns[nameof(Tour.TouristCount)].HeaderText = "Количество отдыхающих";
            mainGrid.Columns[nameof(Tour.HasWifi)].HeaderText = "Wi-Fi";
            mainGrid.Columns[nameof(Tour.ExtraCharges)].HeaderText = "Доплаты (₽уб)";
            mainGrid.Columns[nameof(Tour.TotalCost)].HeaderText = "Общая стоимость (₽уб)";
        }

        /// <summary>
        /// Загрузка туров/записей
        /// </summary>
        private void LoadTours()
        {
            tourList.Add(new Tour(Direction.Turkey, new DateTime(2025, 6, 10), 7, 55000m, 2, true, 5000m));
            tourList.Add(new Tour(Direction.Spain, new DateTime(2025, 7, 5), 10, 72000m, 3, true, 8000m));
            tourList.Add(new Tour(Direction.Italy, new DateTime(2025, 8, 12), 5, 48000m, 1, false, 2000m));
            tourList.Add(new Tour(Direction.France, new DateTime(2025, 9, 3), 12, 95000m, 4, true, 10000m));
            tourList.Add(new Tour(Direction.Sushari, new DateTime(2025, 10, 1), 3, 999m, 5, false, 0m));
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
