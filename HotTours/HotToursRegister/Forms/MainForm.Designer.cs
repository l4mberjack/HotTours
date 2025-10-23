namespace HotToursRegister
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
            statusStrip.SuspendLayout();
            menuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)mainGrid).BeginInit();
            SuspendLayout();
            // 
            // statusStrip
            // 
            statusStrip.ImageScalingSize = new Size(20, 20);
            statusStrip.Items.AddRange(new ToolStripItem[] { toolStripStatusLabelToursCount, toolStripStatusLabelSumOfTours, toolStripStatusLabelToursWithExtraCharge, toolStripStatusLabelSumOfExtraCharge });
            statusStrip.Location = new Point(0, 424);
            statusStrip.Name = "statusStrip";
            statusStrip.Size = new Size(1043, 26);
            statusStrip.TabIndex = 0;
            statusStrip.Text = "statusStrip1";
            // 
            // toolStripStatusLabelToursCount
            // 
            toolStripStatusLabelToursCount.Name = "toolStripStatusLabelToursCount";
            toolStripStatusLabelToursCount.Size = new Size(151, 20);
            toolStripStatusLabelToursCount.Text = "toolStripStatusLabel1";
            // 
            // toolStripStatusLabelSumOfTours
            // 
            toolStripStatusLabelSumOfTours.Name = "toolStripStatusLabelSumOfTours";
            toolStripStatusLabelSumOfTours.Size = new Size(151, 20);
            toolStripStatusLabelSumOfTours.Text = "toolStripStatusLabel1";
            // 
            // toolStripStatusLabelToursWithExtraCharge
            // 
            toolStripStatusLabelToursWithExtraCharge.Name = "toolStripStatusLabelToursWithExtraCharge";
            toolStripStatusLabelToursWithExtraCharge.Size = new Size(151, 20);
            toolStripStatusLabelToursWithExtraCharge.Text = "toolStripStatusLabel1";
            // 
            // toolStripStatusLabelSumOfExtraCharge
            // 
            toolStripStatusLabelSumOfExtraCharge.Name = "toolStripStatusLabelSumOfExtraCharge";
            toolStripStatusLabelSumOfExtraCharge.Size = new Size(151, 20);
            toolStripStatusLabelSumOfExtraCharge.Text = "toolStripStatusLabel1";
            // 
            // menuStrip
            // 
            menuStrip.ImageScalingSize = new Size(20, 20);
            menuStrip.Items.AddRange(new ToolStripItem[] { AddToolStripMenuItem, DeleteToolStripMenuItem, EditToolStripMenuItem });
            menuStrip.Location = new Point(0, 0);
            menuStrip.Name = "menuStrip";
            menuStrip.Size = new Size(1043, 28);
            menuStrip.TabIndex = 1;
            menuStrip.Text = "menuStrip1";
            // 
            // AddToolStripMenuItem
            // 
            AddToolStripMenuItem.Name = "AddToolStripMenuItem";
            AddToolStripMenuItem.Size = new Size(90, 24);
            AddToolStripMenuItem.Text = "Добавить";
            AddToolStripMenuItem.Click += AddToolStripMenuItem_Click;
            // 
            // DeleteToolStripMenuItem
            // 
            DeleteToolStripMenuItem.Name = "DeleteToolStripMenuItem";
            DeleteToolStripMenuItem.Size = new Size(79, 24);
            DeleteToolStripMenuItem.Text = "Удалить";
            DeleteToolStripMenuItem.Click += DeleteToolStripMenuItem_Click;
            // 
            // EditToolStripMenuItem
            // 
            EditToolStripMenuItem.Name = "EditToolStripMenuItem";
            EditToolStripMenuItem.Size = new Size(125, 24);
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
            mainGrid.Dock = DockStyle.Fill;
            mainGrid.Location = new Point(0, 28);
            mainGrid.Name = "mainGrid";
            mainGrid.ReadOnly = true;
            mainGrid.RowHeadersWidth = 51;
            mainGrid.Size = new Size(1043, 396);
            mainGrid.TabIndex = 2;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1043, 450);
            Controls.Add(mainGrid);
            Controls.Add(statusStrip);
            Controls.Add(menuStrip);
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Главная форма";
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
    }
}
