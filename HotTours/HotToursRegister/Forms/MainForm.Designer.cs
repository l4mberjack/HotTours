namespace HotToursRegister.Forms
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            statusStrip = new StatusStrip();
            toolStripStatusLabelToursCount = new ToolStripStatusLabel();
            toolStripStatusLabelSumOfTours = new ToolStripStatusLabel();
            toolStripStatusLabelToursWithExtraCharge = new ToolStripStatusLabel();
            toolStripStatusLabelSumOfExtraCharge = new ToolStripStatusLabel();
            menuStrip = new MenuStrip();
            AddToolStripMenuItem = new ToolStripMenuItem();
            DeleteToolStripMenuItem = new ToolStripMenuItem();
            EditToolStripMenuItem = new ToolStripMenuItem();
            mainGrid = new DataGridView();
            ColumnDirection = new DataGridViewComboBoxColumn();
            ColumnDepartureDate = new DataGridViewTextBoxColumn();
            ColumnCountNights = new DataGridViewTextBoxColumn();
            ColumnTouristsCount = new DataGridViewTextBoxColumn();
            ColumnPricePerPerson = new DataGridViewTextBoxColumn();
            ColumnExtraCharges = new DataGridViewTextBoxColumn();
            ColumnWiFi = new DataGridViewCheckBoxColumn();
            ColumnTotalCost = new DataGridViewTextBoxColumn();
            statusStrip.SuspendLayout();
            menuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)mainGrid).BeginInit();
            SuspendLayout();
            // 
            // statusStrip
            // 
            statusStrip.ImageScalingSize = new Size(20, 20);
            statusStrip.Items.AddRange(new ToolStripItem[] { toolStripStatusLabelToursCount, toolStripStatusLabelSumOfTours, toolStripStatusLabelToursWithExtraCharge, toolStripStatusLabelSumOfExtraCharge });
            statusStrip.Location = new Point(0, 316);
            statusStrip.Name = "statusStrip";
            statusStrip.Padding = new Padding(1, 0, 12, 0);
            statusStrip.Size = new Size(913, 22);
            statusStrip.TabIndex = 0;
            statusStrip.Text = "statusStrip1";
            // 
            // toolStripStatusLabelToursCount
            // 
            toolStripStatusLabelToursCount.Name = "toolStripStatusLabelToursCount";
            toolStripStatusLabelToursCount.Size = new Size(118, 17);
            toolStripStatusLabelToursCount.Text = "toolStripStatusLabel1";
            // 
            // toolStripStatusLabelSumOfTours
            // 
            toolStripStatusLabelSumOfTours.Name = "toolStripStatusLabelSumOfTours";
            toolStripStatusLabelSumOfTours.Size = new Size(118, 17);
            toolStripStatusLabelSumOfTours.Text = "toolStripStatusLabel1";
            // 
            // toolStripStatusLabelToursWithExtraCharge
            // 
            toolStripStatusLabelToursWithExtraCharge.Name = "toolStripStatusLabelToursWithExtraCharge";
            toolStripStatusLabelToursWithExtraCharge.Size = new Size(118, 17);
            toolStripStatusLabelToursWithExtraCharge.Text = "toolStripStatusLabel1";
            // 
            // toolStripStatusLabelSumOfExtraCharge
            // 
            toolStripStatusLabelSumOfExtraCharge.Name = "toolStripStatusLabelSumOfExtraCharge";
            toolStripStatusLabelSumOfExtraCharge.Size = new Size(118, 17);
            toolStripStatusLabelSumOfExtraCharge.Text = "toolStripStatusLabel1";
            // 
            // menuStrip
            // 
            menuStrip.ImageScalingSize = new Size(20, 20);
            menuStrip.Items.AddRange(new ToolStripItem[] { AddToolStripMenuItem, DeleteToolStripMenuItem, EditToolStripMenuItem });
            menuStrip.Location = new Point(0, 0);
            menuStrip.Name = "menuStrip";
            menuStrip.Padding = new Padding(5, 2, 0, 2);
            menuStrip.Size = new Size(913, 24);
            menuStrip.TabIndex = 1;
            menuStrip.Text = "menuStrip1";
            // 
            // AddToolStripMenuItem
            // 
            AddToolStripMenuItem.Name = "AddToolStripMenuItem";
            AddToolStripMenuItem.Size = new Size(71, 20);
            AddToolStripMenuItem.Text = "Добавить";
            AddToolStripMenuItem.Click += AddToolStripMenuItem_Click;
            // 
            // DeleteToolStripMenuItem
            // 
            DeleteToolStripMenuItem.Name = "DeleteToolStripMenuItem";
            DeleteToolStripMenuItem.Size = new Size(63, 20);
            DeleteToolStripMenuItem.Text = "Удалить";
            DeleteToolStripMenuItem.Click += DeleteToolStripMenuItem_Click;
            // 
            // EditToolStripMenuItem
            // 
            EditToolStripMenuItem.Name = "EditToolStripMenuItem";
            EditToolStripMenuItem.Size = new Size(99, 20);
            EditToolStripMenuItem.Text = "Редактировать";
            EditToolStripMenuItem.Click += EditToolStripMenuItem_Click;
            // 
            // mainGrid
            // 
            mainGrid.AllowUserToAddRows = false;
            mainGrid.AllowUserToDeleteRows = false;
            mainGrid.AllowUserToResizeColumns = false;
            mainGrid.AllowUserToResizeRows = false;
            mainGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            mainGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            mainGrid.Columns.AddRange(new DataGridViewColumn[] { ColumnDirection, ColumnDepartureDate, ColumnCountNights, ColumnTouristsCount, ColumnPricePerPerson, ColumnExtraCharges, ColumnWiFi, ColumnTotalCost });
            mainGrid.Dock = DockStyle.Fill;
            mainGrid.Location = new Point(0, 24);
            mainGrid.Margin = new Padding(3, 2, 3, 2);
            mainGrid.Name = "mainGrid";
            mainGrid.ReadOnly = true;
            mainGrid.RowHeadersWidth = 51;
            mainGrid.Size = new Size(913, 292);
            mainGrid.TabIndex = 2;
            mainGrid.CellFormatting += mainGrid_CellFormatting;
            // 
            // ColumnDirection
            // 
            ColumnDirection.HeaderText = "Направление";
            ColumnDirection.MinimumWidth = 6;
            ColumnDirection.Name = "ColumnDirection";
            ColumnDirection.ReadOnly = true;
            // 
            // ColumnDepartureDate
            // 
            ColumnDepartureDate.HeaderText = "Дата";
            ColumnDepartureDate.MinimumWidth = 6;
            ColumnDepartureDate.Name = "ColumnDepartureDate";
            ColumnDepartureDate.ReadOnly = true;
            // 
            // ColumnCountNights
            // 
            ColumnCountNights.HeaderText = "Количество ночей";
            ColumnCountNights.MinimumWidth = 6;
            ColumnCountNights.Name = "ColumnCountNights";
            ColumnCountNights.ReadOnly = true;
            // 
            // ColumnTouristsCount
            // 
            ColumnTouristsCount.HeaderText = "Количество туристов";
            ColumnTouristsCount.MinimumWidth = 6;
            ColumnTouristsCount.Name = "ColumnTouristsCount";
            ColumnTouristsCount.ReadOnly = true;
            // 
            // ColumnPricePerPerson
            // 
            ColumnPricePerPerson.HeaderText = "Цена за отдыхающего";
            ColumnPricePerPerson.MinimumWidth = 6;
            ColumnPricePerPerson.Name = "ColumnPricePerPerson";
            ColumnPricePerPerson.ReadOnly = true;
            ColumnPricePerPerson.Resizable = DataGridViewTriState.True;
            ColumnPricePerPerson.SortMode = DataGridViewColumnSortMode.NotSortable;
            // 
            // ColumnExtraCharges
            // 
            ColumnExtraCharges.HeaderText = "Доплата";
            ColumnExtraCharges.MinimumWidth = 6;
            ColumnExtraCharges.Name = "ColumnExtraCharges";
            ColumnExtraCharges.ReadOnly = true;
            // 
            // ColumnWiFi
            // 
            ColumnWiFi.HeaderText = "Наличие Wi-Fi";
            ColumnWiFi.MinimumWidth = 6;
            ColumnWiFi.Name = "ColumnWiFi";
            ColumnWiFi.ReadOnly = true;
            // 
            // ColumnTotalCost
            // 
            ColumnTotalCost.HeaderText = "Общая стоимость тура";
            ColumnTotalCost.MinimumWidth = 6;
            ColumnTotalCost.Name = "ColumnTotalCost";
            ColumnTotalCost.ReadOnly = true;
            ColumnTotalCost.Resizable = DataGridViewTriState.True;
            ColumnTotalCost.SortMode = DataGridViewColumnSortMode.NotSortable;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(913, 338);
            Controls.Add(mainGrid);
            Controls.Add(statusStrip);
            Controls.Add(menuStrip);
            Margin = new Padding(3, 2, 3, 2);
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Главная форма";
            Load += MainForm_Load;
            statusStrip.ResumeLayout(false);
            statusStrip.PerformLayout();
            menuStrip.ResumeLayout(false);
            menuStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)mainGrid).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private StatusStrip statusStrip;
        private ToolStripStatusLabel toolStripStatusLabelToursCount;
        private ToolStripStatusLabel toolStripStatusLabelSumOfTours;
        private MenuStrip menuStrip;
        private ToolStripMenuItem AddToolStripMenuItem;
        private ToolStripMenuItem DeleteToolStripMenuItem;
        private ToolStripMenuItem EditToolStripMenuItem;
        private ToolStripStatusLabel toolStripStatusLabelToursWithExtraCharge;
        private ToolStripStatusLabel toolStripStatusLabelSumOfExtraCharge;
        private DataGridView mainGrid;
        private DataGridViewComboBoxColumn ColumnDirection;
        private DataGridViewTextBoxColumn ColumnDepartureDate;
        private DataGridViewTextBoxColumn ColumnCountNights;
        private DataGridViewTextBoxColumn ColumnTouristsCount;
        private DataGridViewTextBoxColumn ColumnPricePerPerson;
        private DataGridViewTextBoxColumn ColumnExtraCharges;
        private DataGridViewCheckBoxColumn ColumnWiFi;
        private DataGridViewTextBoxColumn ColumnTotalCost;
    }
}
