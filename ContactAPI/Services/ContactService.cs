using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ContactAPI.Models;
using LiteDB;

namespace ContactAPI.Services
{
    public static class ContactService
    {
        //static List<Contact> Contacts { get; }
        //static int NextId = 1;
        static ContactService()
        {
            using (var db = new LiteDatabase("Contacts.db"))
            {
                var col = db.GetCollection<Contact>("contacts");
            }
        }

        public static void Create(Contact c)
        {
            using (var db = new LiteDatabase("Contacts.db"))
            {
                var col = db.GetCollection<Contact>("contacts");

                col.Insert(c);
            }
        }

        public static List<Contact> GetAll()
        {
            using (var db = new LiteDatabase("Contacts.db"))
            {
                var col = db.GetCollection<Contact>("contacts");

                return col.Query().ToList();
            }
        }

        public static Contact Get(int id)
        {
            using (var db = new LiteDatabase("Contacts.db"))
            {
                var col = db.GetCollection<Contact>("contacts");

                return col.Query()
                    .Where(x => x.Id == id).SingleOrDefault();
            }
        }

        public static void Delete(int id)
        {
            using (var db = new LiteDatabase("Contacts.db"))
            {
                var col = db.GetCollection<Contact>("contacts");

                col.Delete(id);
            }
        }

        public static void Update(int id, Contact c)
        {
            using (var db = new LiteDatabase("Contacts.db"))
            {
                var col = db.GetCollection<Contact>("contacts");

                col.Update(id, c);
            }
        }

        public static Object GetCallList()
        {
            using (var db = new LiteDatabase("Contacts.db"))
            {
                var col = db.GetCollection<Contact>("contacts");

                List<Contact> hasHomePhone = col.Query().Where(c => c.Phone.Where(p => p.Type.Contains("Home")).Any()).ToList();

                var callList = hasHomePhone.Select(x => new
                {
                    x.Name,
                    Phone = x.Phone.FindLast(p => p.Type.Contains("home")).Number
                }).OrderBy(c => c.Name.Last).ThenBy(c => c.Name.First);

                return callList;
            }
        }
    }
}
