using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Faker.Example.Console.Models.Entities
{
    public class Customer
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public List<Contact> Contacts { get; set; }
    }
}
