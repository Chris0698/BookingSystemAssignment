 

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImplementationOfObjectOrientedDesigns.Domain
{
    public class VenueFactory
    {
        private static VenueFactory instance;
        private Hashtable venueFeatures;

        private VenueFactory()
        {
            venueFeatures = new Hashtable();
        }


        public void Register(VenueAddOns venueAddOn, VenueComponent venueDecorator)
        {
            //venue add on will never be null since its an enum
            if(venueDecorator == null)
            {
                throw new ArgumentNullException("Venue Decorator is null");
            }

            if(!venueFeatures.ContainsKey(venueAddOn))
            {
                venueFeatures[venueAddOn] = venueDecorator;
            }
        }

        public static VenueFactory GetInstance
        {
            get
            {
                if(instance == null)
                {
                    instance = new VenueFactory();
                }
               
                return instance;
            }
        }

        /*
        public IVenue CreateVenue(string name, string address, List<VenueAddOns> venueAddOns = null)
        {
            if(String.IsNullOrEmpty(name))
            {
                throw new ArgumentNullException("Name is null when creating a venue");
            }

            if(String.IsNullOrEmpty(address))
            {
                throw new ArgumentNullException("Venue address is null when creating a venue");
            }

            //this.venueAddOns = venueAddOns;
            Venue venue = new Venue(name, address);
            if (venueAddOns != null)
            {
                if (venueAddOns.Count > 0)
                {
                    //AddFeatures(venue);
                }
            }

            return venue;
        }
        */
    
        public void AddFeatures(Venue venue, List<VenueDecorator> venueAddOnList)
        {
            for(int i = 0; i < venueAddOnList.Count; i++)
            {
                int index = 0;
                if(Int32.TryParse(venueAddOnList[i].ID, out index))
                {
                    VenueAddOns venueAddOn = (VenueAddOns)index;

                    if (venueFeatures.ContainsKey(venueAddOn))
                    {
                        if (i == 0)
                        {
                            venueAddOnList[i].SetBaseComponent(venue);
                        }
                        else
                        {
                            venueAddOnList[i].SetBaseComponent(venueAddOnList[i - 1]);
                        }
                    }
                    else
                    {
                        throw new ArgumentException("Venue add on does not exists. Has it been registered?");
                    }
                }
                else
                {
                    throw new Exception("Error parsing ID");
                }
             
            }

            venue.venueExtras = venueAddOnList[venueAddOnList.Count - 1].GetName();
            venue.cost = venueAddOnList[venueAddOnList.Count - 1].GetCost();
        }
    }
}
