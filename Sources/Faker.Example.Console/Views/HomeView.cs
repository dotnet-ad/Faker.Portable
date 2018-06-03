using Faker.Example.Console.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Faker.Example.Console.Views
{
    public class HomeView : IConsoleView<HomeViewModel>
    {
        public HomeView(HomeViewModel viewModel)
        {
            this.ViewModel = viewModel;
        }

        public HomeViewModel ViewModel { get; private set; }

        public String Execute(string command)
        {
            var splits = command.Split(' ');

            if(splits[0].ToLower() == "update")
            {
                this.ViewModel.UpdateCommand.Execute(null);
                return String.Empty;
            }

            return String.Format("Command \"{0}\" not found", splits[0]); ;
        }

        public string Print()
        {
            throw new NotImplementedException();
        }
    }
}
