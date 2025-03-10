using ReactiveUI;
using System.Reactive;
using WeChipItAvalonia.Views;

namespace WeChipItAvalonia.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        public ReactiveCommand<Unit, Unit> AddCustomerCommand { get; }
        public ReactiveCommand<Unit, Unit> AddAnimalCommand { get; }
        public ReactiveCommand<Unit, Unit> RecordMicrochipCommand { get; }
        public ReactiveCommand<Unit, Unit> ExitCommand { get; }

        public MainWindowViewModel()
        {
            AddCustomerCommand = ReactiveCommand.Create(AddCustomer);
            AddAnimalCommand = ReactiveCommand.Create(AddAnimal);
            RecordMicrochipCommand = ReactiveCommand.Create(RecordMicrochip);
            ExitCommand = ReactiveCommand.Create(Exit);
        }

        private void AddCustomer()
        {
            var addCustomerWindow = new AddCustomerWindow();
            addCustomerWindow.Show();
        }

        private void AddAnimal()
        {
            var addAnimalWindow = new AddAnimalWindow();
            addAnimalWindow.Show();
        }

        private void RecordMicrochip()
        {
            var recordMicrochipWindow = new RecordMicrochipWindow();
            recordMicrochipWindow.Show();
        }

        private void Exit()
        {
            // Logic to exit the application
        }
    }
}