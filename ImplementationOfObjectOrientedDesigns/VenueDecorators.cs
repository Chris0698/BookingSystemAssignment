 

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImplementationOfObjectOrientedDesigns.Domain
{
    [NotMapped]
    public class VenueAfternoonRefreshments : VenueDecorator
    {
        public VenueAfternoonRefreshments()
        {

        }
    }

    [NotMapped]
    public class VenueMorningRefreshments : VenueDecorator
    {
        public VenueMorningRefreshments()
        {

        }
    }

    [NotMapped]
    public class VenueEveningMeal : VenueDecorator
    {
        public VenueEveningMeal()
        {
 
        }
    }

    [NotMapped]
    public class VenueBusTransport : VenueDecorator
    {
        public VenueBusTransport()
        {

        }
    }

    [NotMapped]
    public class VenueMiddayLunch : VenueDecorator
    {
        public VenueMiddayLunch()
        {

        }
    }
}
