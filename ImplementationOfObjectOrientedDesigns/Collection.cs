 

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImplementationOfObjectOrientedDesigns.Utilities
{
    public class Collection<T> : List<T>, ICollection<T>
    {
        public int GetSize()
        {
            return this.Count;
        }

        public List<string> GetStrings()
        {
            int size = this.Count;
            List<string> strings = new List<string>(size);
            
            for(int f = 0; f < size; f++)
            {
                strings.Add(this[f].ToString());
            }

            return strings;
        }
    }
}
