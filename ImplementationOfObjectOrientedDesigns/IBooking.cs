using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ImplementationOfObjectOrientedDesigns.Utilities;

namespace ImplementationOfObjectOrientedDesigns.Domain
{
    public interface IBooking
    {
        string bookingID { get; set; }
        string GetID();
        IVenue GetVenue();
        IClient GetClient();
        IActivity GetActivity();
        BookingType GetBookingType();
        Date GetDate();
        Time GetTime();
        List<string> GetExtras();
        decimal GetCost();
        void UpdateDate(int day, int month, int year);
        void UpdateTime(int hour, int minute);
        void UpdateCosts();
        bool CheckThirdPartyCompanies();

    }
}
