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
            // Initialize commands
            AddCustomerCommand = ReactiveCommand.Create(AddCustomer);
            AddAnimalCommand = ReactiveCommand.Create(AddAnimal);
            RecordMicrochipCommand = ReactiveCommand.Create(RecordMicrochip);
            QuitCommand = ReactiveCommand.Create(Quit);

            // Handle exceptions for AddAnimalCommand
            AddAnimalCommand.ThrownExceptions.Subscribe(ex =>
            {
                // Log or display the error
                Console.WriteLine($"Error: {ex.Message}");
            });
        }

        private void AddCustomer()
        {
            // Open the AddCustomerWindow
            var addCustomerWindow = new AddCustomerWindow();
            addCustomerWindow.Show();
        }

        private void AddAnimal()
        {
            try
            {
                // Create an instance of AddAnimalWindowViewModel
                var viewModel = new AddAnimalWindowViewModel();

                // Pass the viewModel to the AddAnimalWindow constructor
                var addAnimalWindow = new AddAnimalWindow(viewModel);

                // Show the window
                addAnimalWindow.Show();
            }
            catch (Exception ex)
            {
                // Handle any exceptions
                Console.WriteLine($"Error opening AddAnimalWindow: {ex.Message}");
            }
        }

        private void RecordMicrochip()
        {
            // Open the RecordMicrochipWindow
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