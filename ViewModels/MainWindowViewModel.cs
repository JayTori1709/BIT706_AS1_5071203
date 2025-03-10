using ReactiveUI;
using System;
using System.Reactive;
using WeChipItAvalonia.Views;

namespace WeChipItAvalonia.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        public ReactiveCommand<Unit, Unit> AddCustomerCommand { get; }
        public ReactiveCommand<Unit, Unit> AddAnimalCommand { get; }
        public ReactiveCommand<Unit, Unit> RecordMicrochipCommand { get; }
        public ReactiveCommand<Unit, Unit> QuitCommand { get; }

        public MainWindowViewModel()
        {
            AddCustomerCommand = ReactiveCommand.Create(AddCustomer);
            AddAnimalCommand = ReactiveCommand.Create(AddAnimal);
            RecordMicrochipCommand = ReactiveCommand.Create(RecordMicrochip);
            QuitCommand = ReactiveCommand.Create(Quit);
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

        private void Quit()
        {
            // Logic to exit the application
            Environment.Exit(0);
        }
    }
}