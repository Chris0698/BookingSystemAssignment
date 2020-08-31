//Chris Aston, Carlton Evans, Sam Noble

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ImplementationOfObjectOrientedDesigns.Utilities;
using ImplementationOfObjectOrientedDesigns.Domain;
using ImplementationOfObjectOrientedDesigns.DataAccess;

namespace ImplementationOfObjectOrientedDesigns.Presentation
{
    public class BookingPresenter
    {
        private IBookingGUI screen;
        private Collection<Client> clients;
        private BookingCollection bookings;
        private int currentClientIndex;
        private IBooking activeBooking;

        public BookingPresenter(IBookingGUI screen)
        {
            if(screen == null)
            {
                throw new ArgumentNullException("Screen reference null");
            }

            currentClientIndex = 0;
            activeBooking = null;
            this.screen = screen;
            screen.Register(this);
            screen.DisableButtons();
            this.clients = DatabaseQueries.GetAllClients();
            this.bookings = DatabaseQueries.GetAllBookings();
            PopulateClientList();
            screen.HideDateSelector();
            screen.HideTimeSelector();
            screen.DisableSelectBookingButton();          
        }

        private void PopulateClientList()
        {
            screen.PopulateClients(clients.GetStrings());
        }

        public void GetAllClientBookings(int clientIndex)
        {
            currentClientIndex = clientIndex;
            screen.SetBookings(bookings.GetClientBookings(clients[clientIndex]).GetStrings());
            screen.EnableSelectBookingButton();
        }

        public void SetBooking(string bookingID)
        {
            if(bookingID == null)
            {
                throw new ArgumentNullException("Booking ID reference null");
            }

            bookingID = bookingID.Substring(5, bookingID.IndexOf('\t') - 5).Trim();
            screen.ResetExtrasList();
            activeBooking = bookings.GetByID(bookingID);

            if (activeBooking != null)
            {
                if (activeBooking.GetBookingType() == BookingType.SIMPLE)
                {
                    screen.SetBookingType("Simple");
                }
                else
                {
                    screen.SetBookingType("Facilitated");
                }

                screen.SetClient(activeBooking.GetClient().ToString());
                screen.SetActivity(activeBooking.GetActivity().ToString());
                screen.SetExtras(activeBooking.GetExtras());
                screen.SetVenue(activeBooking.GetVenue().venueName + ", " + activeBooking.GetVenue().venueAddress);
                screen.SetDate(activeBooking.GetDate().GetFormatted());
                screen.SetTime(activeBooking.GetTime().GetFormatted());
                screen.SetCost(FormatPrice(activeBooking.GetCost()));
                screen.SetDefaultDate(activeBooking.GetDate());
                screen.SetDefaultTime(activeBooking.GetTime());
                screen.EnableButtons();
                screen.HideDateSelector();
                screen.HideTimeSelector();
            }
        }

        private string FormatPrice(decimal price)
        {
            if(price < 0.0M)
            {
                throw new ArgumentException("Price should not be negative");
            }

            decimal roundedPrice = Math.Round(price, 2);

            string priceString = roundedPrice.ToString();
            int decimalPlaces = 0;
            bool decimalPointFound = false;

            int size = priceString.Length;
            for (int c = 0; c < size; c++)
            {
                if(priceString[c] == '.')
                {
                    decimalPointFound = true;
                    continue;
                }

                if(decimalPointFound)
                {
                    decimalPlaces++;
                }
            }

            if (decimalPlaces == 1)
            {
                priceString = priceString + '0';
            }
            else if(decimalPlaces == 0)
            {
                priceString = priceString + ".00";
            }

            return '£' + priceString;
        }

        public void ChangeDate(int day, int month, int year)
        {
            if (activeBooking != null)
            {
                activeBooking.UpdateDate(day, month, year);
                screen.SetDate(activeBooking.GetDate().GetFormatted());
                activeBooking.UpdateCosts();
                screen.ShowMessage("Confirmed", "Costs have been updated");
                screen.SetCost(FormatPrice(activeBooking.GetCost()));
                screen.HideDateSelector();
            }
        }

        public void ChangeTime(int hour, int minute)
        {
            if (activeBooking != null)
            {
                activeBooking.UpdateTime(hour, minute);
                screen.SetTime(activeBooking.GetTime().GetFormatted());
                screen.ShowMessage("Confirmed", "Costs have been updated");
                screen.SetCost(FormatPrice(activeBooking.GetCost()));
                screen.HideTimeSelector();
            }
        }

        public void SaveBooking()
        {
            if (activeBooking != null)
            {
                if (activeBooking.CheckThirdPartyCompanies())
                {
                    DatabaseQueries.ConfirmBooking(activeBooking);
                    ResetUserInterface();
                    GetAllClientBookings(currentClientIndex);
                    screen.HideDateSelector();
                    screen.HideTimeSelector();
                }
                else
                {
                    activeBooking.UpdateCosts();
                    screen.ShowError("Error", "Original third party companies no longer available.\nNew companies have been found and costs have been updated");
                    screen.SetCost(FormatPrice(activeBooking.GetCost()));
                }
            }
        }

        public void DeleteBooking()
        {
            if (activeBooking != null)
            {
                DatabaseQueries.CancelBooking(activeBooking);
                ResetUserInterface();
                GetAllClientBookings(currentClientIndex);
                screen.HideDateSelector();
                screen.HideTimeSelector();
            }
        }

        private void ResetUserInterface()
        {
            if (activeBooking != null)
            {
                bookings.DeleteID(activeBooking.GetID());
                activeBooking = null;
                screen.ClearTextBoxes();
                screen.DisableButtons();
            }
        }

        public void ConfirmBooking()
        {
            if (screen.YesNoMessage("Are you sure you want to confirm the booking?", "Are you sure?"))
            {
                SaveBooking();
            }
        }

        public void CancelBooking()
        {
            if (screen.YesNoMessage("Are you sure you want to cancel the booking?", "Are you sure?"))
            {
                DeleteBooking();
            }
        }
    }
}
