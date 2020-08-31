using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ImplementationOfObjectOrientedDesigns.Utilities;

namespace ImplementationOfObjectOrientedDesigns.Presentation
{
    public partial class BookingGUI : Form, IBookingGUI
    {
        private BookingPresenter presenter;
        public BookingGUI()
        {
            InitializeComponent();
            calendar.MinDate = DateTime.Now;
        }

        private void changeDateButton_Click(object sender, EventArgs e)
        {
            ShowDateSelector();
        }

        private void changeTimeButton_Click(object sender, EventArgs e)
        {
            ShowTimeSelector();
        }

        private void ConfirmDateButton_Click(object sender, EventArgs e)
        {
            presenter.ChangeDate(calendar.SelectionRange.Start.Day, calendar.SelectionRange.Start.Month, calendar.SelectionRange.Start.Year);
        }

        private void KeepOriginalDateButton_Click(object sender, EventArgs e)
        {
            HideDateSelector();
        }

        private void confirmTimeButton_Click(object sender, EventArgs e)
        {
            presenter.ChangeTime(timePicker.Value.Hour, timePicker.Value.Minute);
        }

        private void keepTimeButton_Click(object sender, EventArgs e)
        {
            HideTimeSelector();
        }

        public void DisableButtons()
        {
            confirmButton.Enabled = false;
            cancelButton.Enabled = false;
            changeDateButton.Enabled = false;
            confirmDateButton.Enabled = false;
            keepDateButton.Enabled = false;
            changeTimeButton.Enabled = false;
        }

        public void EnableButtons()
        {
            confirmButton.Enabled = true;
            cancelButton.Enabled = true;
            changeDateButton.Enabled = true;
            confirmDateButton.Enabled = true;
            keepDateButton.Enabled = true;
            changeTimeButton.Enabled = true;
        }

        public void SetBookingType(string type) 
        {
            bookingText.Text = type;
        }

        public void SetClient(string client)
        {
            clientText.Text = client;
        }

        public void SetActivity(string activity)
        {
            activityText.Text = activity;
        }

        public void SetVenue(string venue)
        {
            venueText.Text = venue;
        }

        public void SetDate(string date)
        {
            dateText.Text = date;
        }

        public void SetCost(string cost)
        {
            costText.Text = cost;
        }

        public void SetTime(string time)
        {
            timeText.Text = time;
        }

        public void Register(BookingPresenter presenter)
        {
            this.presenter = presenter;
        }

        public void ShowMessage(string title, string message)
        {
            MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public void ShowError(string title, string message)
        {
            MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public void PopulateClients(List<string> clients)
        {
            int size = clients.Count;
            for(int i = 0; i < size; i++)
            {
                clientsDropDown.Items.Add(clients[i]);
            }
        }

        public void SetBookings(List<string> bookings)
        {
            ResetBookingsList();
            int size = bookings.Count;
            for (int i = 0; i < size; i++)
            {
                bookingsList.Items.Add(bookings[i]);
            }
        }

        public void HideTimeSelector()
        {
            confirmTimeButton.Visible = false;
            keepTimeButton.Visible = false;
            timePicker.Visible = false;
        }

        public void ShowTimeSelector()
        {
            confirmTimeButton.Visible = true;
            keepTimeButton.Visible = true;
            timePicker.Visible = true;
        }

        public void HideDateSelector()
        {
            calendar.Visible = false;
            confirmDateButton.Visible = false;
            keepDateButton.Visible = false;
        }

        public void ShowDateSelector()
        {
            calendar.Visible = true;
            confirmDateButton.Visible = true;
            keepDateButton.Visible = true;
        }

        public void EnableSelectBookingButton()
        {
            selectBookingButton.Enabled = true;
        }

        public void DisableSelectBookingButton()
        {
            selectBookingButton.Enabled = false;
        }

        private void clientsDropDown_SelectedIndexChanged(object sender, EventArgs e)
        {
            presenter.GetAllClientBookings(clientsDropDown.SelectedIndex);
        }

        private void selectBookingButton_Click(object sender, EventArgs e)
        {
            SelectBooking();
        }

        private void bookingsList_DoubleClick(object sender, EventArgs e)
        {
            SelectBooking();
        }

        private void confirmButton_Click(object sender, EventArgs e)
        {
            presenter.ConfirmBooking();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            presenter.CancelBooking();
        }

        public void ClearTextBoxes()
        {
            ResetExtrasList();
            SetBookingType("");
            SetCost("");
            SetVenue("");
            SetClient("");
            SetDate("");
            SetTime("");
            SetActivity("");
            ResetBookingsList();
        }

        public void ResetBookingsList()
        {
            bookingsList.Items.Clear();
        }

        public void ResetExtrasList()
        {
            extrasList.Items.Clear();
        }

        private void SelectBooking()
        {
            if (bookingsList.SelectedIndex > -1)
            {
                presenter.SetBooking(bookingsList.SelectedItem.ToString());
            }
        }

        public void SetExtras(List<string> notes)
        {
            //extrasList.Items.Clear();
            foreach (string item in notes)
            {
                extrasList.Items.Add(item);
            }
        }

        public bool YesNoMessage(string title, string message)
        {
            DialogResult result = MessageBox.Show(title, message, MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if(result == DialogResult.Yes)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void SetDefaultDate(Date date)
        {
            calendar.SetDate(new DateTime(date.GetYear(), date.GetMonth(), date.GetDay()));
        }

        public void SetDefaultTime(Time time)
        {
            timePicker.Value = new DateTime(2000, 1, 1, time.GetHour(), time.GetMinute(), 0);
        }
    }
}
