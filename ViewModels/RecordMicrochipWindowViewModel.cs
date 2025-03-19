using ReactiveUI;
using System;
using System.Reactive;
using System.Threading.Tasks;
using Avalonia.Controls;
using WeChipItAvalonia.Services;
using WeChipItAvalonia.Views;

namespace WeChipItAvalonia.ViewModels
{
    public class RecordMicrochipWindowViewModel : ViewModelBase
    {
        // Properties
        private string _customerName = string.Empty;
        public string CustomerName
        {
            get => _customerName;
            set => this.RaiseAndSetIfChanged(ref _customerName, value);
        }

        private string _animalName = string.Empty;
        public string AnimalName
        {
            get => _animalName;
            set => this.RaiseAndSetIfChanged(ref _animalName, value);
        }

        private string _microchipNumber = string.Empty;
        public string MicrochipNumber
        {
            get => _microchipNumber;
            set => this.RaiseAndSetIfChanged(ref _microchipNumber, value);
        }

        // Commands
        public ReactiveCommand<Unit, Unit> SaveCommand { get; }
        public ReactiveCommand<Unit, Unit> CancelCommand { get; }

        // Action to close the window
        public Action CloseWindow { get; set; }

        // Window reference
        private readonly Window _window;

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
        public RecordMicrochipWindowViewModel(Window window)
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
        {
            _window = window; // Store the window reference
            SaveCommand = ReactiveCommand.CreateFromTask(SaveMicrochipAsync);
            CancelCommand = ReactiveCommand.Create(Cancel);
        }

        // Save logic
        private Task SaveMicrochipAsync()
        {
            try
            {
                // Validate inputs
                if (string.IsNullOrWhiteSpace(CustomerName))
                {
                    ShowError("Customer Name is required.");
                    return Task.CompletedTask;
                }

                if (string.IsNullOrWhiteSpace(AnimalName))
                {
                    ShowError("Animal Name is required.");
                    return Task.CompletedTask;
                }

                if (string.IsNullOrWhiteSpace(MicrochipNumber) || !long.TryParse(MicrochipNumber, out _))
                {
                    ShowError("Microchip Number is required.");
                    return Task.CompletedTask;
                }

                // Find the customer
                var customer = DataStore.Instance.GetCustomerByName(CustomerName);
                if (customer == null)
                {
                    ShowError("Customer not found.");
                    return Task.CompletedTask;
                }

                // Find the animal
                var animal = customer.Animals.Find(a => a.Name.Equals(AnimalName, StringComparison.OrdinalIgnoreCase));
                if (animal == null)
                {
                    ShowError("Animal not found.");
                    return Task.CompletedTask;
                }

                // Update the animal's microchip number
                animal.MicrochipNumber = MicrochipNumber;

                // Save the data (e.g., to a database or service)
                DataStore.Instance.SaveData();

                // Close the window
                CloseWindow?.Invoke();
            }
            catch (Exception ex)
            {
                ShowError($"Error saving microchip: {ex.Message}");
            }

            return Task.CompletedTask;
        }

        // Cancel logic
        private void Cancel()
        {
            CloseWindow?.Invoke();
        }

        // Helper method to show error messages
        private async void ShowError(string message)
        {
            var messageBox = new MessageBox("Error", message);
            await messageBox.ShowDialog(_window);
        }
    }
}