using Faker.Example.Console.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Faker.Example.Console.ViewModels.Items
{
    public class CustomerItemViewModel
    {
        public CustomerItemViewModel(Customer model)
        {
            this.Model = model;
        }

        public Customer Model { get; private set; }

        public string Name { get { return this.Model == null ? null : this.Model.Name; } }

        public string Description { get { return this.Model == null ? null : this.Model.Description; } }
    }
}
