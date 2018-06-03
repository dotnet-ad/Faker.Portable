using Faker.Example.Console.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Faker.Example.Console.Models.Services
{
    public interface ICompanyService
    {
        Task<List<Customer>> GetCustomers();
    }
}
