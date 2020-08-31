///Chris Aston, Carlton Evans, Sam Noble

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImplementationOfObjectOrientedDesigns.Domain
{
    public class VenueDecorator : VenueComponent
    {
        public string ID { get; set; }

        public string name { get; set; }

        public decimal cost { get; set; }

        private VenueComponent venueComponent;

        protected VenueDecorator()
        {
            name = "";
            cost = 0.0M;
        }

        public override decimal GetCost()
        {
            return cost + venueComponent.GetCost();
        }

        public override string GetName()
        {
            return name + "\n" + venueComponent.GetName();
        }

        //Used to avoid an issue where venue would have to be passed in the 
        //constructor instead, whichy would not be possible in the way this 
        //was coded.
        public void SetBaseComponent(VenueComponent venueComponent)
        {
            this.venueComponent = venueComponent;
        }
    }
}
