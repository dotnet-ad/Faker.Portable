namespace Faker.Example.Console.ViewModels
{
    using Example.Console.Models.Services;
    using Example.Console.Mvvm;
    using Example.Console.ViewModels.Items;
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Input;

    public class HomeViewModel : ViewModelBase
    {
        public HomeViewModel(ICompanyService service)
        {
            this.service = service;

            this.Customers = new ObservableCollection<CustomerItemViewModel>();
            this.UpdateCommand = new RelayCommand(ExecuteUpdate);
        }

        private ICompanyService service;

        #region Commands

        public ICommand UpdateCommand { get; private set; }

        #endregion

        public ObservableCollection<CustomerItemViewModel> Customers { get; private set; }

        private async void ExecuteUpdate(object arg)
        {
			try
			{
				await this.ExecuteUpdateAsync(arg);
			}
			catch (Exception ex)
			{
				Console.WriteLine("Failed " + ex);
			}
        }

        public async Task ExecuteUpdateAsync(object arg)
        {
            var result = await this.service.GetCustomers();

            this.Customers.Clear();

            foreach (var item in result)
            {
                this.Customers.Add(new CustomerItemViewModel(item));
            }
        }
    }
}
