using ReactiveUI;
using System.Collections.Generic;
using System.Reactive;
using System.Threading.Tasks;
using System;
using Avalonia.Controls;

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
        private async Task SaveAnimalAsync()
        {
            try
            {
                // Validate inputs
                if (string.IsNullOrWhiteSpace(CustomerName))
                {
                    // Show error message (you can use a dialog or logging)
                    Console.WriteLine("Customer Name is required.");
                    return;
                }

                if (string.IsNullOrWhiteSpace(AnimalName))
                {
                    Console.WriteLine("Animal Name is required.");
                    return;
                }

                if (string.IsNullOrWhiteSpace(SelectedAnimalType))
                {
                    Console.WriteLine("Type of Animal is required.");
                    return;
                }

                if (string.IsNullOrWhiteSpace(Age))
                {
                    Console.WriteLine("Age is required.");
                    return;
                }

                if (string.IsNullOrWhiteSpace(SelectedSex))
                {
                    Console.WriteLine("Sex is required.");
                    return;
                }

                // Save the data (e.g., to a database or service)
                Console.WriteLine("Saving animal data...");
                Console.WriteLine($"Customer Name: {CustomerName}");
                Console.WriteLine($"Animal Name: {AnimalName}");
                Console.WriteLine($"Type: {SelectedAnimalType}");
                Console.WriteLine($"Age: {Age}");
                Console.WriteLine($"Sex: {SelectedSex}");
                Console.WriteLine($"Microchipped: {IsMicrochipped}");

                // TODO: Replace with actual save logic (e.g., database or API call)

                // Close the window after saving
                CloseWindow?.Invoke();
            }
            catch (Exception ex)
            {
                // Handle exceptions (e.g., log or show an error message)
                Console.WriteLine($"Error saving animal data: {ex.Message}");
            }
        }

        // Cancel logic
        private void Cancel()
        {
            // Close the window without saving
            CloseWindow?.Invoke();
        }
    }
}