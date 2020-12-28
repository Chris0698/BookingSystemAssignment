 

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ImplementationOfObjectOrientedDesigns.DataAccess;

namespace ImplementationOfObjectOrientedDesigns.Domain
{
    public class ThirdPartyCompany
    {
        public ThirdPartyCompany()
        {

        }

        public bool CheckAvailable()
        {
            Random random = new Random();
            int number = random.Next(0 ,9);

            if(number < 7)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
