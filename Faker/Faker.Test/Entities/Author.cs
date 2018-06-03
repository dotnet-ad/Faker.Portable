using Faker.Test.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mocker.Entities
{
    public class Author
    {
        public Author(int age)
        {
            this.Age = age;
        }

        public String FirstName { get; set; }

        public String LastName { get; set; }

        public List<String> Emails { get; set; }

        public int Age { get; private set; }

        public DateTime BirthDay { get; set; }

        public Gender Gender { get; set; }
    }
}
