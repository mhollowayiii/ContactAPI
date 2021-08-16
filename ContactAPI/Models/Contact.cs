using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LiteDB;

namespace ContactAPI.Models
{
    public class Contact
    {
        public class CName
        {
            public string First { get; set; }
            public string Middle { get; set; }
            public string Last { get; set; }
        }

        public class CAddress
        {
            public string Street { get; set; }
            public string City { get; set; }
            public string State { get; set; }
            public string Zip { get; set; }
        }

        public class CPhone
        {
            public string Number { get; set; }
            public string Type { get; set; }
        }

        public int Id { get; set; }
        public CName Name { get; set; }
        public CAddress Address { get; set; }
        public List<CPhone> Phone { get; set; }
        public string Email { get; set;}

        // I'll consider contacts equal if they're identical except for the id since LiteDB is managing the ids
        public bool Equals(Contact c)
        {
            if(c.Name.First == this.Name.First &&
                c.Name.Middle == this.Name.Middle &&
                c.Name.Last == this.Name.Last &&
                c.Address.City == this.Address.City &&
                c.Address.State == this.Address.State &&
                c.Address.Street == this.Address.Street &&
                c.Address.Zip == this.Address.Zip &&
                c.Email == this.Email)
            {
                foreach (CPhone p in c.Phone)
                    if (!this.Phone.FindAll(x => x.Number == p.Number && x.Type == p.Type).Any())
                        return false;
                return true;
            }

            return false;
        }

    }

}
