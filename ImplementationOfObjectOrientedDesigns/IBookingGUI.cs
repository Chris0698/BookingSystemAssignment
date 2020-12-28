 

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ImplementationOfObjectOrientedDesigns.Utilities;

namespace ImplementationOfObjectOrientedDesigns.Presentation
{
    public interface IBookingGUI
    {
        void SetBookingType(string type);
        void SetClient(string client);
        void SetActivity(string activity);
        void SetVenue(string venue);
        void SetDate(string date);
        void SetCost(string cost);
        void SetTime(string time);
        void SetExtras(List<string> notes);
        void Register(BookingPresenter presenter);
        void ShowMessage(string title, string message);
        void ShowError(string title, string message);
        bool YesNoMessage(string title, string message);
        void DisableButtons();
        void HideDateSelector();
        void HideTimeSelector();
        void SetBookings(List<string> bookings);
        void PopulateClients(List<string> clients);
        void DisableSelectBookingButton();
        void EnableSelectBookingButton();
        void ClearTextBoxes();
        void EnableButtons();
        void ResetExtrasList();
        void SetDefaultDate(Date date);
        void SetDefaultTime(Time time);
    }
}
