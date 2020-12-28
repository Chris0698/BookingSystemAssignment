 

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ImplementationOfObjectOrientedDesigns.Domain;

namespace ImplementationOfObjectOrientedDesigns.Utilities
{
    public class BookingCollection : Collection<Booking>
    {
        public BookingCollection GetClientBookings(Client client)
        {
            if(client == null)
            {
                throw new ArgumentNullException("Client cant be null");
            }

            BookingCollection clientBookings = new BookingCollection();

            int size = GetSize();
            for(int c = 0; c < size; c++)
            {
                if (client.GetID() == this[c].client.GetID())
                {
                    clientBookings.Add(this[c]);
                }
            }

            return clientBookings;
        }

        public void DeleteID(string ID)
        {
            if(String.IsNullOrEmpty(ID))
            {
                throw new ArgumentNullException("ID cant be null");
            }

            int size = GetSize();
            for(int c = 0; c < size; c++)
            {
                if(this[c].GetID().Equals(ID))
                {
                    RemoveAt(c);
                    break;
                }
            }
        }

        public Booking GetByID(string ID)
        {
            if(String.IsNullOrEmpty(ID))
            {
                throw new ArgumentNullException("ID cant be null");
            }

            int size = GetSize();
            for (int c = 0; c < size; c++)
            {
                if (this[c].GetID().Equals(ID))
                {
                    return this[c];
                }
            }
            return null;
        }
    }
}
