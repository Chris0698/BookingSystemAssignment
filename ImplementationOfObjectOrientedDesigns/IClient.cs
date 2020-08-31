using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImplementationOfObjectOrientedDesigns.Domain
{
    public interface IClient
    {
        string GetID();
        string GetCompanyAddress();
        Client Clone();
    }
}
