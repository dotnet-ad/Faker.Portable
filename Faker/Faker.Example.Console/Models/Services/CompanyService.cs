using Faker.Example.Console.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Faker.Example.Console.Models.Services
{
    public class CompanyService : ICompanyService
    {
        public Task<List<Customer>> GetCustomers()
        {
            return Faker.Default.Create<Task<List<Customer>>>();
        }
    }
}
