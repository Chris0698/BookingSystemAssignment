//Chris Aston, Carlton Evans, Sam Noble

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImplementationOfObjectOrientedDesigns.Domain
{
    public class Activity : IActivity, ICloneable
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
                //no checks for null because when the system first runs the activities
                //are registered as empty
                _ID = value;
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
                if(value < 0.0M)
                {
                    throw new ArgumentException("Cost cann't be negative");
                }

                _cost = value;
            }
        }

        public string activityName
        {
            get
            {
                return _activityName;
            }
            set
            {
                _activityName = value;
            }
        } 

        public virtual IActivity CreateActivity(string ID, decimal cost)
        {
            return new Activity();
        }

        private string _ID;
        private decimal _cost;
        private string _activityName;

        public Activity() 
        {
        }

        public override string ToString()
        {
            return activityName;
        }

        public Activity Clone()
        {
            return (Activity)this.MemberwiseClone();
        }

        object ICloneable.Clone()
        {
            return Clone();
        }
    }
}