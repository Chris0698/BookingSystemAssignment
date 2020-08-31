///Chris Aston, Carlton Evans, Sam Noble

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImplementationOfObjectOrientedDesigns.Domain
{
    public interface IVenue
    {
        string venueName { get; set; }

        string venueExtras { get; set; }

        decimal cost { get; set; }

        string venueAddress { get; set; }

        Venue Clone();
    }
}
