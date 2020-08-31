//Chris Aston, Carlton Evans, Sam Noble

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImplementationOfObjectOrientedDesigns.Domain
{
    public class Venue : VenueComponent, IVenue, ICloneable
    {
        [Key]
        public string ID
        {
            get
            {
                return _ID;
            }
            set
            {
                _ID = value;
            }
        }

        public string venueName 
        {
            get
            {
                return _venueName;
            }
            set
            {
                _venueName = value;
            }
        }

        public string venueAddress 
        {
            get
            {
                return _venueAddress;
            }
            set
            {
                _venueAddress = value;
            }
        }

        public decimal cost 
        {
            get
            {
                return _cost;
            }
            set
            {
                if (value < 0.0M)
                {
                    throw new ArgumentException("Cost cannot be negative");
                }
                
                _cost = value;
            }
        }

        [NotMapped]
        public string venueExtras
        {
            get
            {
                return _venueExtras;
            }
            set
            {
                _venueExtras = value;
            }
        }
        


        private string _ID;
        private string _venueName;
        private string _venueAddress;
        private decimal _cost;
        private string _venueExtras;

        public Venue()
        {
        }

        public Venue(string name, string address)
        {
            if(String.IsNullOrEmpty(name))
            {
                throw new ArgumentNullException("Name cannot be null or empty");
            }

            if(String.IsNullOrEmpty(address))
            {
                throw new ArgumentNullException("Address cannot be null or empty");
            }

            venueName = name.Trim();
            venueAddress = address.Trim();
            venueExtras = "";
        }

        public Venue(string name, string address, decimal cost) : this(name, address)
        {
            if(cost < 0.0M)
            {
                throw new ArgumentException("Cost cannot be negative");
            }

            this.cost = cost;
        }


        public override string GetName()
        {
            return venueName;
        }

        public override decimal GetCost()
        {
            return cost;
        }

        public Venue Clone()
        {
            return (Venue)this.MemberwiseClone();
        }

        object ICloneable.Clone()
        {
            return this.Clone();
        }
    }
}
