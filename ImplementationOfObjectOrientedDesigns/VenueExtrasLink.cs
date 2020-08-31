///Chris Aston, Carlton Evans, Sam Noble

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImplementationOfObjectOrientedDesigns.DataAccess
{
    /// <summary>
    /// Only exists for the database
    /// </summary>
    public class VenueExtrasLink 
    {
        public string ID { get; set; }

        public string bookingID { get; set; }

        public string extraID { get; set; }

        public VenueExtrasLink()
        {
        }
    }
}
