namespace ImplementationOfObjectOrientedDesigns.Presentation
{
    partial class BookingGUI
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
            this.calendar = new System.Windows.Forms.MonthCalendar();
            this.changeDateButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.clientText = new System.Windows.Forms.TextBox();
            this.confirmButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.venueText = new System.Windows.Forms.TextBox();
            this.bookingText = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.dateText = new System.Windows.Forms.TextBox();
            this.confirmDateButton = new System.Windows.Forms.Button();
            this.keepDateButton = new System.Windows.Forms.Button();
            this.bookingsList = new System.Windows.Forms.ListBox();
            this.clientsDropDown = new System.Windows.Forms.ComboBox();
            this.ClientSelect = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.selectBookingButton = new System.Windows.Forms.Button();
            this.costText = new System.Windows.Forms.TextBox();
            this.Cost = new System.Windows.Forms.Label();
            this.extrasList = new System.Windows.Forms.ListBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.timeText = new System.Windows.Forms.TextBox();
            this.timePicker = new System.Windows.Forms.DateTimePicker();
            this.changeTimeButton = new System.Windows.Forms.Button();
            this.keepTimeButton = new System.Windows.Forms.Button();
            this.confirmTimeButton = new System.Windows.Forms.Button();
            this.activityText = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // calendar
            // 
            this.calendar.Location = new System.Drawing.Point(480, 170);
            this.calendar.MinDate = new System.DateTime(2019, 11, 16, 0, 0, 0, 0);
            this.calendar.Name = "calendar";
            this.calendar.TabIndex = 3;
            // 
            // changeDateButton
            // 
            this.changeDateButton.Location = new System.Drawing.Point(111, 479);
            this.changeDateButton.Name = "changeDateButton";
            this.changeDateButton.Size = new System.Drawing.Size(130, 23);
            this.changeDateButton.TabIndex = 4;
            this.changeDateButton.Text = "Change Date";
            this.changeDateButton.UseVisualStyleBackColor = true;
            this.changeDateButton.Click += new System.EventHandler(this.changeDateButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(247, 508);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(130, 23);
            this.cancelButton.TabIndex = 5;
            this.cancelButton.Text = "Cancel Booking";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // clientText
            // 
            this.clientText.Location = new System.Drawing.Point(125, 86);
            this.clientText.Name = "clientText";
            this.clientText.ReadOnly = true;
            this.clientText.Size = new System.Drawing.Size(233, 20);
            this.clientText.TabIndex = 7;
            // 
            // confirmButton
            // 
            this.confirmButton.Location = new System.Drawing.Point(111, 508);
            this.confirmButton.Name = "confirmButton";
            this.confirmButton.Size = new System.Drawing.Size(130, 23);
            this.confirmButton.TabIndex = 8;
            this.confirmButton.Text = "Confirm";
            this.confirmButton.UseVisualStyleBackColor = true;
            this.confirmButton.Click += new System.EventHandler(this.confirmButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(71, 89);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Client";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(59, 329);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Activity";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(66, 289);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 13);
            this.label3.TabIndex = 12;
            this.label3.Text = "Venue";
            // 
            // venueText
            // 
            this.venueText.Location = new System.Drawing.Point(125, 286);
            this.venueText.Name = "venueText";
            this.venueText.ReadOnly = true;
            this.venueText.Size = new System.Drawing.Size(233, 20);
            this.venueText.TabIndex = 13;
            // 
            // bookingText
            // 
            this.bookingText.Location = new System.Drawing.Point(125, 124);
            this.bookingText.Name = "bookingText";
            this.bookingText.ReadOnly = true;
            this.bookingText.Size = new System.Drawing.Size(233, 20);
            this.bookingText.TabIndex = 14;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(31, 127);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(73, 13);
            this.label4.TabIndex = 15;
            this.label4.Text = "Booking Type";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(74, 166);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(30, 13);
            this.label5.TabIndex = 17;
            this.label5.Text = "Date";
            // 
            // dateText
            // 
            this.dateText.Location = new System.Drawing.Point(125, 163);
            this.dateText.Name = "dateText";
            this.dateText.ReadOnly = true;
            this.dateText.Size = new System.Drawing.Size(233, 20);
            this.dateText.TabIndex = 18;
            // 
            // confirmDateButton
            // 
            this.confirmDateButton.Location = new System.Drawing.Point(480, 344);
            this.confirmDateButton.Name = "confirmDateButton";
            this.confirmDateButton.Size = new System.Drawing.Size(96, 23);
            this.confirmDateButton.TabIndex = 19;
            this.confirmDateButton.Text = "Confirm Date";
            this.confirmDateButton.UseVisualStyleBackColor = true;
            this.confirmDateButton.Click += new System.EventHandler(this.ConfirmDateButton_Click);
            // 
            // keepDateButton
            // 
            this.keepDateButton.Location = new System.Drawing.Point(591, 344);
            this.keepDateButton.Name = "keepDateButton";
            this.keepDateButton.Size = new System.Drawing.Size(116, 23);
            this.keepDateButton.TabIndex = 20;
            this.keepDateButton.Text = "Keep Date";
            this.keepDateButton.UseVisualStyleBackColor = true;
            this.keepDateButton.Click += new System.EventHandler(this.KeepOriginalDateButton_Click);
            // 
            // bookingsList
            // 
            this.bookingsList.Location = new System.Drawing.Point(480, 33);
            this.bookingsList.Name = "bookingsList";
            this.bookingsList.Size = new System.Drawing.Size(227, 95);
            this.bookingsList.TabIndex = 25;
            this.bookingsList.DoubleClick += new System.EventHandler(this.bookingsList_DoubleClick);
            // 
            // clientsDropDown
            // 
            this.clientsDropDown.FormattingEnabled = true;
            this.clientsDropDown.Location = new System.Drawing.Point(125, 30);
            this.clientsDropDown.MaxDropDownItems = 100;
            this.clientsDropDown.Name = "clientsDropDown";
            this.clientsDropDown.Size = new System.Drawing.Size(233, 21);
            this.clientsDropDown.TabIndex = 22;
            this.clientsDropDown.SelectedIndexChanged += new System.EventHandler(this.clientsDropDown_SelectedIndexChanged);
            // 
            // ClientSelect
            // 
            this.ClientSelect.AutoSize = true;
            this.ClientSelect.Location = new System.Drawing.Point(43, 33);
            this.ClientSelect.Name = "ClientSelect";
            this.ClientSelect.Size = new System.Drawing.Size(66, 13);
            this.ClientSelect.TabIndex = 23;
            this.ClientSelect.Text = "Select Client";
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(0, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(100, 23);
            this.label6.TabIndex = 0;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(477, 17);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(80, 13);
            this.label7.TabIndex = 24;
            this.label7.Text = "Client Bookings";
            // 
            // selectBookingButton
            // 
            this.selectBookingButton.Location = new System.Drawing.Point(479, 134);
            this.selectBookingButton.Name = "selectBookingButton";
            this.selectBookingButton.Size = new System.Drawing.Size(97, 23);
            this.selectBookingButton.TabIndex = 26;
            this.selectBookingButton.Text = "Select Booking";
            this.selectBookingButton.UseVisualStyleBackColor = true;
            this.selectBookingButton.Click += new System.EventHandler(this.selectBookingButton_Click);
            // 
            // costText
            // 
            this.costText.Location = new System.Drawing.Point(125, 244);
            this.costText.Name = "costText";
            this.costText.ReadOnly = true;
            this.costText.Size = new System.Drawing.Size(233, 20);
            this.costText.TabIndex = 27;
            // 
            // Cost
            // 
            this.Cost.AutoSize = true;
            this.Cost.Location = new System.Drawing.Point(76, 247);
            this.Cost.Name = "Cost";
            this.Cost.Size = new System.Drawing.Size(28, 13);
            this.Cost.TabIndex = 28;
            this.Cost.Text = "Cost";
            // 
            // extrasList
            // 
            this.extrasList.FormattingEnabled = true;
            this.extrasList.Location = new System.Drawing.Point(125, 367);
            this.extrasList.Name = "extrasList";
            this.extrasList.Size = new System.Drawing.Size(233, 95);
            this.extrasList.TabIndex = 30;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(66, 367);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(36, 13);
            this.label8.TabIndex = 31;
            this.label8.Text = "Extras";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(70, 207);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(30, 13);
            this.label9.TabIndex = 32;
            this.label9.Text = "Time";
            // 
            // timeText
            // 
            this.timeText.Location = new System.Drawing.Point(125, 204);
            this.timeText.Name = "timeText";
            this.timeText.ReadOnly = true;
            this.timeText.Size = new System.Drawing.Size(233, 20);
            this.timeText.TabIndex = 33;
            // 
            // timePicker
            // 
            this.timePicker.CustomFormat = "HH:mm";
            this.timePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.timePicker.Location = new System.Drawing.Point(480, 388);
            this.timePicker.Name = "timePicker";
            this.timePicker.ShowUpDown = true;
            this.timePicker.Size = new System.Drawing.Size(227, 20);
            this.timePicker.TabIndex = 34;
            // 
            // changeTimeButton
            // 
            this.changeTimeButton.Location = new System.Drawing.Point(247, 479);
            this.changeTimeButton.Name = "changeTimeButton";
            this.changeTimeButton.Size = new System.Drawing.Size(130, 23);
            this.changeTimeButton.TabIndex = 35;
            this.changeTimeButton.Text = "Change Time";
            this.changeTimeButton.UseVisualStyleBackColor = true;
            this.changeTimeButton.Click += new System.EventHandler(this.changeTimeButton_Click);
            // 
            // keepTimeButton
            // 
            this.keepTimeButton.Location = new System.Drawing.Point(591, 425);
            this.keepTimeButton.Name = "keepTimeButton";
            this.keepTimeButton.Size = new System.Drawing.Size(116, 23);
            this.keepTimeButton.TabIndex = 37;
            this.keepTimeButton.Text = "Keep Time";
            this.keepTimeButton.UseVisualStyleBackColor = true;
            this.keepTimeButton.Click += new System.EventHandler(this.keepTimeButton_Click);
            // 
            // confirmTimeButton
            // 
            this.confirmTimeButton.Location = new System.Drawing.Point(480, 425);
            this.confirmTimeButton.Name = "confirmTimeButton";
            this.confirmTimeButton.Size = new System.Drawing.Size(96, 23);
            this.confirmTimeButton.TabIndex = 36;
            this.confirmTimeButton.Text = "Confirm Time";
            this.confirmTimeButton.UseVisualStyleBackColor = true;
            this.confirmTimeButton.Click += new System.EventHandler(this.confirmTimeButton_Click);
            // 
            // activityText
            // 
            this.activityText.Location = new System.Drawing.Point(125, 326);
            this.activityText.Name = "activityText";
            this.activityText.ReadOnly = true;
            this.activityText.Size = new System.Drawing.Size(233, 20);
            this.activityText.TabIndex = 38;
            // 
            // BookingGUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(813, 564);
            this.Controls.Add(this.activityText);
            this.Controls.Add(this.keepTimeButton);
            this.Controls.Add(this.confirmTimeButton);
            this.Controls.Add(this.changeTimeButton);
            this.Controls.Add(this.timePicker);
            this.Controls.Add(this.timeText);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.extrasList);
            this.Controls.Add(this.Cost);
            this.Controls.Add(this.costText);
            this.Controls.Add(this.selectBookingButton);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.ClientSelect);
            this.Controls.Add(this.clientsDropDown);
            this.Controls.Add(this.bookingsList);
            this.Controls.Add(this.keepDateButton);
            this.Controls.Add(this.confirmDateButton);
            this.Controls.Add(this.dateText);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.bookingText);
            this.Controls.Add(this.venueText);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.confirmButton);
            this.Controls.Add(this.clientText);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.changeDateButton);
            this.Controls.Add(this.calendar);
            this.Name = "BookingGUI";
            this.Text = "Booking Confirmation";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MonthCalendar calendar;
        private System.Windows.Forms.Button changeDateButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.TextBox clientText;
        private System.Windows.Forms.Button confirmButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox venueText;
        private System.Windows.Forms.TextBox bookingText;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox dateText;
        private System.Windows.Forms.Button confirmDateButton;
        private System.Windows.Forms.Button keepDateButton;
        private System.Windows.Forms.ListBox bookingsList;
        private System.Windows.Forms.ComboBox clientsDropDown;
        private System.Windows.Forms.Label ClientSelect;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button selectBookingButton;
        private System.Windows.Forms.TextBox costText;
        private System.Windows.Forms.Label Cost;
        private System.Windows.Forms.ListBox extrasList;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox timeText;
        private System.Windows.Forms.DateTimePicker timePicker;
        private System.Windows.Forms.Button changeTimeButton;
        private System.Windows.Forms.Button keepTimeButton;
        private System.Windows.Forms.Button confirmTimeButton;
        private System.Windows.Forms.TextBox activityText;
    }
}

