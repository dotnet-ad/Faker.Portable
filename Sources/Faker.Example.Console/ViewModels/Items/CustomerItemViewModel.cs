namespace Faking.Example.Console.ViewModels.Items
{
	using Models.Entities;

    public class CustomerItemViewModel
    {
        public CustomerItemViewModel(Customer model)
        {
            this.Model = model;
        }

        public Customer Model { get; }

        public string Name => this.Model == null ? null : this.Model.Name;

        public string Description => this.Model == null ? null : this.Model.Description;
    }
}
