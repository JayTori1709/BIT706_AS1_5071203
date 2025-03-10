using ReactiveUI;
using System.Reactive;
using WeChipItAvalonia.Views;

namespace WeChipItAvalonia.ViewModels
{
    public class AddCustomerWindowViewModel : ViewModelBase
    {
        public string Name { get; set; } = string.Empty;
        public string Contact { get; set; }  = string.Empty;
        public string Email { get; set; }  = string.Empty;
        public string Address { get; set; }  = string.Empty;

        public ReactiveCommand<Unit, Unit> SaveCommand { get; }
        public ReactiveCommand<Unit, Unit> CancelCommand { get; }

        public AddCustomerWindowViewModel()
        {
            SaveCommand = ReactiveCommand.Create(Save);
            CancelCommand = ReactiveCommand.Create(Cancel);
        }

        private void Save()
        {
            // Logic to save the customer
        }

        private void Cancel()
        {
            // Logic to close the window
        }
    }
}