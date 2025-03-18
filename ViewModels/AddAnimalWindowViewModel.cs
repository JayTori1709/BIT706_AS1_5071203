using ReactiveUI;
using System.Collections.Generic;
using System.Reactive;
using System.Threading.Tasks;
using System;
using WeChipItAvalonia.Models;
using WeChipItAvalonia.Services;

namespace WeChipItAvalonia.ViewModels
{
    public class AddAnimalWindowViewModel : ReactiveObject
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

        private List<string> _animalTypes = new List<string> { "Cat", "Dog" };
        public List<string> AnimalTypes
        {
            get => _animalTypes;
            set => this.RaiseAndSetIfChanged(ref _animalTypes, value);
        }

        private string _selectedAnimalType = string.Empty;
        public string SelectedAnimalType
        {
            get => _selectedAnimalType;
            set => this.RaiseAndSetIfChanged(ref _selectedAnimalType, value);
        }

        private string _age = string.Empty;
        public string Age
        {
            get => _age;
            set => this.RaiseAndSetIfChanged(ref _age, value);
        }

        private List<string> _sexOptions = new List<string> { "Male", "Female" };
        public List<string> SexOptions
        {
            get => _sexOptions;
            set => this.RaiseAndSetIfChanged(ref _sexOptions, value);
        }

        private string _selectedSex = string.Empty;
        public string SelectedSex
        {
            get => _selectedSex;
            set => this.RaiseAndSetIfChanged(ref _selectedSex, value);
        }

        private bool _isMicrochipped;
        public bool IsMicrochipped
        {
            get => _isMicrochipped;
            set => this.RaiseAndSetIfChanged(ref _isMicrochipped, value);
        }

        // Commands
        public ReactiveCommand<Unit, Unit> SaveCommand { get; }
        public ReactiveCommand<Unit, Unit> CancelCommand { get; }

        // Action to close the window
        public Action CloseWindow { get; set; }

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
        public AddAnimalWindowViewModel()
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
        {
            // Initialize commands
            SaveCommand = ReactiveCommand.CreateFromTask(SaveAnimalAsync);
            CancelCommand = ReactiveCommand.Create(Cancel);
        }

        // Save logic
        public Task SaveAnimalAsync()
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

                if (string.IsNullOrWhiteSpace(SelectedAnimalType))
                {
                    ShowError("Type of Animal is required.");
                    return Task.CompletedTask;
                }

                if (string.IsNullOrWhiteSpace(Age) || !int.TryParse(Age, out _))
                {
                    ShowError("Age is required and must be a valid number.");
                    return Task.CompletedTask;
                }

                if (string.IsNullOrWhiteSpace(SelectedSex))
                {
                    ShowError("Sex is required.");
                    return Task.CompletedTask;
                }

                // Find the customer
                var customer = DataStore.Instance.GetCustomerByName(CustomerName);
                if (customer == null)
                {
                    ShowError("Customer not found.");
                    return Task.CompletedTask;
                }

                // Create the animal
                var animal = new Animal
                {
                    Name = AnimalName,
                    Type = SelectedAnimalType,
                    Sex = SelectedSex,
                    Age = int.Parse(Age),
                    MicrochipNumber = string.Empty // Initialize with an empty microchip number
                };

                // Add the animal to the customer
                customer.Animals.Add(animal);

                // Save the data (e.g., to a database or service)
                DataStore.Instance.SaveData();

                // Close the window
                CloseWindow?.Invoke();
            }
            catch (Exception ex)
            {
                ShowError($"Error saving animal data: {ex.Message}");
            }

            return Task.CompletedTask;
        }

        // Cancel logic
        private void Cancel()
        {
            CloseWindow?.Invoke();
        }

        // Helper method to show error messages
        private void ShowError(string message)
        {
            // Use a dialog or logging to display the error
            Console.WriteLine(message);
        }
    }
}