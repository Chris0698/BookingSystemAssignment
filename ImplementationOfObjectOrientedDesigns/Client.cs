 

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ImplementationOfObjectOrientedDesigns.Utilities;

namespace ImplementationOfObjectOrientedDesigns.Domain
{
    public class Client : IClient, ICloneable
    {
        [Key]
        public string ID { get; set; }

        public string companyAddress { get; set; }

        public string companyName { get; set; }

        public Client() { }

        public Client(string ID, string companyName, string companyAddress)
        {
            if(String.IsNullOrEmpty(ID))
            {
                throw new ArgumentNullException("Client ID is null");
            }
            if(String.IsNullOrEmpty(companyName))
            {
                throw new ArgumentNullException("Company name is null");
            }
            if(String.IsNullOrEmpty(companyAddress))
            {
                throw new ArgumentNullException("Company address is null");
            }

            this.ID = ID.Trim();
            this.companyAddress = companyAddress.Trim();
            this.companyName = companyName.Trim();
        }

        public override string ToString()
        {
            return companyName;
        }

        public string GetID()
        {
            return ID;
        }

        public string GetCompanyAddress()
        {
            return companyAddress;
        }

        public Client Clone()
        {
            return (Client)this.MemberwiseClone();
        }

        object ICloneable.Clone()
        {
            return this.Clone();
        }
    }
}
