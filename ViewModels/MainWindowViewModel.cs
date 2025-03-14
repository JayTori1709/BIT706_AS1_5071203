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

             AddAnimalCommand.ThrownExceptions.Subscribe(ex =>
    {
        // Log or display the error
        Console.WriteLine($"Error: {ex.Message}");
        });
        }

        private void AddCustomer()
        {
            var addCustomerWindow = new AddCustomerWindow();
            addCustomerWindow.Show();
        }

        private void AddAnimal()
        {
    try
    {
        // Open the AddAnimalWindow
        var window = new AddAnimalWindow();
        window.Show();
    }
    catch (Exception ex)
    {
        // Handle any exceptions
        Console.WriteLine($"Error: {ex.Message}");
    }
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