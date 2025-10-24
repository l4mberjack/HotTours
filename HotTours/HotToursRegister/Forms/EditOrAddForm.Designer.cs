namespace HotToursRegister.Forms
{
    partial class EditOrAddForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            comboBoxDirections = new ComboBox();
            labelDirections = new Label();
            labelDate = new Label();
            dateTimePicker = new DateTimePicker();
            labelNightsCount = new Label();
            numericUpDownNights = new NumericUpDown();
            numericUpDownTourists = new NumericUpDown();
            labelTouristsCount = new Label();
            checkBoxWiFi = new CheckBox();
            buttonAddOrEdit = new Button();
            buttonCancel = new Button();
            labelPricePerPerson = new Label();
            numericUpDownPrice = new NumericUpDown();
            labelExtraCharge = new Label();
            numericUpDownExtraCharge = new NumericUpDown();
            pictureBox2 = new PictureBox();
            errorProvider = new ErrorProvider(components);
            ((System.ComponentModel.ISupportInitialize)numericUpDownNights).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownTourists).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownPrice).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownExtraCharge).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)errorProvider).BeginInit();
            SuspendLayout();
            // 
            // comboBoxDirections
            // 
            comboBoxDirections.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            comboBoxDirections.FormattingEnabled = true;
            comboBoxDirections.Location = new Point(164, 242);
            comboBoxDirections.Name = "comboBoxDirections";
            comboBoxDirections.Size = new Size(269, 28);
            comboBoxDirections.TabIndex = 0;
            // 
            // labelDirections
            // 
            labelDirections.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            labelDirections.AutoSize = true;
            labelDirections.Location = new Point(44, 245);
            labelDirections.Name = "labelDirections";
            labelDirections.Size = new Size(104, 20);
            labelDirections.TabIndex = 1;
            labelDirections.Text = "Направление";
            // 
            // labelDate
            // 
            labelDate.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            labelDate.AutoSize = true;
            labelDate.Location = new Point(54, 294);
            labelDate.Name = "labelDate";
            labelDate.Size = new Size(94, 20);
            labelDate.TabIndex = 3;
            labelDate.Text = "Дата вылета";
            // 
            // dateTimePicker
            // 
            dateTimePicker.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dateTimePicker.Location = new Point(164, 289);
            dateTimePicker.Name = "dateTimePicker";
            dateTimePicker.Size = new Size(269, 27);
            dateTimePicker.TabIndex = 4;
            // 
            // labelNightsCount
            // 
            labelNightsCount.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            labelNightsCount.AutoSize = true;
            labelNightsCount.Location = new Point(21, 340);
            labelNightsCount.Name = "labelNightsCount";
            labelNightsCount.Size = new Size(137, 20);
            labelNightsCount.TabIndex = 5;
            labelNightsCount.Text = "Количество ночей";
            // 
            // numericUpDownNights
            // 
            numericUpDownNights.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            numericUpDownNights.Location = new Point(164, 338);
            numericUpDownNights.Name = "numericUpDownNights";
            numericUpDownNights.Size = new Size(269, 27);
            numericUpDownNights.TabIndex = 6;
            // 
            // numericUpDownTourists
            // 
            numericUpDownTourists.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            numericUpDownTourists.Location = new Point(210, 381);
            numericUpDownTourists.Name = "numericUpDownTourists";
            numericUpDownTourists.Size = new Size(223, 27);
            numericUpDownTourists.TabIndex = 9;
            // 
            // labelTouristsCount
            // 
            labelTouristsCount.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            labelTouristsCount.AutoSize = true;
            labelTouristsCount.Location = new Point(21, 383);
            labelTouristsCount.Name = "labelTouristsCount";
            labelTouristsCount.Size = new Size(183, 20);
            labelTouristsCount.TabIndex = 8;
            labelTouristsCount.Text = "Количество отдыхающих";
            // 
            // checkBoxWiFi
            // 
            checkBoxWiFi.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            checkBoxWiFi.AutoSize = true;
            checkBoxWiFi.Location = new Point(210, 508);
            checkBoxWiFi.Name = "checkBoxWiFi";
            checkBoxWiFi.Size = new Size(131, 24);
            checkBoxWiFi.TabIndex = 10;
            checkBoxWiFi.Text = "Наличие Wi-Fi";
            checkBoxWiFi.UseVisualStyleBackColor = true;
            // 
            // buttonAddOrEdit
            // 
            buttonAddOrEdit.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            buttonAddOrEdit.Location = new Point(65, 599);
            buttonAddOrEdit.Name = "buttonAddOrEdit";
            buttonAddOrEdit.Size = new Size(157, 46);
            buttonAddOrEdit.TabIndex = 11;
            buttonAddOrEdit.Text = "buttonAddOrEdit";
            buttonAddOrEdit.UseVisualStyleBackColor = true;
            buttonAddOrEdit.Click += buttonAddOrEdit_Click;
            // 
            // buttonCancel
            // 
            buttonCancel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            buttonCancel.Location = new Point(276, 599);
            buttonCancel.Name = "buttonCancel";
            buttonCancel.Size = new Size(157, 46);
            buttonCancel.TabIndex = 12;
            buttonCancel.Text = "Отмена";
            buttonCancel.UseVisualStyleBackColor = true;
            buttonCancel.Click += buttonCancel_Click;
            // 
            // labelPricePerPerson
            // 
            labelPricePerPerson.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            labelPricePerPerson.AutoSize = true;
            labelPricePerPerson.Location = new Point(28, 425);
            labelPricePerPerson.Name = "labelPricePerPerson";
            labelPricePerPerson.Size = new Size(176, 20);
            labelPricePerPerson.TabIndex = 13;
            labelPricePerPerson.Text = "Цена за 1 отдыхающего";
            // 
            // numericUpDownPrice
            // 
            numericUpDownPrice.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            numericUpDownPrice.Location = new Point(210, 423);
            numericUpDownPrice.Name = "numericUpDownPrice";
            numericUpDownPrice.Size = new Size(223, 27);
            numericUpDownPrice.TabIndex = 14;
            // 
            // labelExtraCharge
            // 
            labelExtraCharge.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            labelExtraCharge.AutoSize = true;
            labelExtraCharge.Location = new Point(137, 465);
            labelExtraCharge.Name = "labelExtraCharge";
            labelExtraCharge.Size = new Size(67, 20);
            labelExtraCharge.TabIndex = 15;
            labelExtraCharge.Text = "Доплата";
            // 
            // numericUpDownExtraCharge
            // 
            numericUpDownExtraCharge.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            numericUpDownExtraCharge.Location = new Point(210, 463);
            numericUpDownExtraCharge.Name = "numericUpDownExtraCharge";
            numericUpDownExtraCharge.Size = new Size(223, 27);
            numericUpDownExtraCharge.TabIndex = 16;
            // 
            // pictureBox2
            // 
            pictureBox2.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            pictureBox2.Image = Properties.Resources.banner1;
            pictureBox2.Location = new Point(0, -2);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(484, 214);
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.TabIndex = 17;
            pictureBox2.TabStop = false;
            // 
            // errorProvider
            // 
            errorProvider.BlinkStyle = ErrorBlinkStyle.NeverBlink;
            errorProvider.ContainerControl = this;
            // 
            // EditOrAddForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(486, 686);
            Controls.Add(pictureBox2);
            Controls.Add(numericUpDownExtraCharge);
            Controls.Add(labelExtraCharge);
            Controls.Add(numericUpDownPrice);
            Controls.Add(labelPricePerPerson);
            Controls.Add(buttonCancel);
            Controls.Add(buttonAddOrEdit);
            Controls.Add(checkBoxWiFi);
            Controls.Add(numericUpDownTourists);
            Controls.Add(labelTouristsCount);
            Controls.Add(numericUpDownNights);
            Controls.Add(labelNightsCount);
            Controls.Add(dateTimePicker);
            Controls.Add(labelDate);
            Controls.Add(labelDirections);
            Controls.Add(comboBoxDirections);
            MaximumSize = new Size(504, 733);
            MinimumSize = new Size(504, 733);
            Name = "EditOrAddForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "EditOrAddForm";
            ((System.ComponentModel.ISupportInitialize)numericUpDownNights).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownTourists).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownPrice).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownExtraCharge).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)errorProvider).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox comboBoxDirections;
        private Label labelDirections;
        private Label labelDate;
        private DateTimePicker dateTimePicker;
        private Label labelNightsCount;
        private NumericUpDown numericUpDownNights;
        private NumericUpDown numericUpDownTourists;
        private Label labelTouristsCount;
        private CheckBox checkBoxWiFi;
        private Button buttonAddOrEdit;
        private Button buttonCancel;
        private Label labelPricePerPerson;
        private NumericUpDown numericUpDownPrice;
        private Label labelExtraCharge;
        private NumericUpDown numericUpDownExtraCharge;
        private PictureBox pictureBox2;
        private ErrorProvider errorProvider;
    }
}
