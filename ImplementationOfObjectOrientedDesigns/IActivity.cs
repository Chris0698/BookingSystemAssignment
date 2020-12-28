 

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImplementationOfObjectOrientedDesigns.Domain
{
    public interface IActivity
    {
        string activityName { get; set; }

        IActivity CreateActivity(string ID, decimal cost);

        string ToString();

        decimal cost { get; set; }

        Activity Clone();
    }
}
