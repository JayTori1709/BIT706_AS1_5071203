using ReactiveUI;
using System.Reactive;
using WeChipItAvalonia.Models;
using WeChipItAvalonia.Services;
using Avalonia.Controls;
using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using System.Collections.Generic;
using System.Linq;
using WeChipItAvalonia.Views;

namespace WeChipItAvalonia.ViewModels
{
    public class AddAnimalWindowViewModel : ViewModelBase
    {
        private string _customerName = string.Empty;
        private string _animalName = string.Empty;
        private string _selectedAnimalType = string.Empty;
        private string _age = string.Empty;
        private string _selectedSex = string.Empty;

        public string CustomerName
        {
            get => _customerName;
            set => this.RaiseAndSetIfChanged(ref _customerName, value);
        }

        public string AnimalName
        {
            get => _animalName;
            set => this.RaiseAndSetIfChanged(ref _animalName, value);
        }

        public List<string> AnimalTypes { get; } = new List<string> { "Cat", "Dog", "Unknown" };

        public string SelectedAnimalType
        {
            get => _selectedAnimalType;
            set => this.RaiseAndSetIfChanged(ref _selectedAnimalType, value);
        }

        public string Age
        {
            get => _age;
            set => this.RaiseAndSetIfChanged(ref _age, value);
        }

        public List<string> SexOptions { get; } = new List<string> { "Male", "Female", "Unknown" };

        public string SelectedSex
        {
            get => _selectedSex;
            set => this.RaiseAndSetIfChanged(ref _selectedSex, value);
        }

        public ReactiveCommand<Unit, Unit> SaveCommand { get; }
        public ReactiveCommand<Unit, Unit> CancelCommand { get; }

        public AddAnimalWindowViewModel()
        {
            SaveCommand = ReactiveCommand.Create(Save);
            CancelCommand = ReactiveCommand.Create(Cancel);
        }

        private void Save()
        {
            // Validate the input
            if (string.IsNullOrWhiteSpace(CustomerName))
            {
                ShowErrorDialog("Customer name is required.");
                return;
            }

            if (string.IsNullOrWhiteSpace(AnimalName))
            {
                ShowErrorDialog("Animal name is required.");
                return;
            }

            if (string.IsNullOrWhiteSpace(SelectedAnimalType))
            {
                ShowErrorDialog("Animal type is required.");
                return;
            }

            if (string.IsNullOrWhiteSpace(SelectedSex))
            {
                ShowErrorDialog("Animal sex is required.");
                return;
            }

            // Find the customer by name
            var customer = DataStore.Instance.GetCustomerByName(CustomerName);
            if (customer == null)
            {
                ShowErrorDialog("Customer not found.");
                return;
            }

            // Create a new animal
            var animal = new Animal
            {
                Name = AnimalName,
                Type = SelectedAnimalType,
                Sex = SelectedSex,
                Age = int.TryParse(Age, out var age) ? age : 0 // Parse age or default to 0
            };

            // Add the animal to the customer
            customer.Animals.Add(animal);

            // Close the window
#pragma warning disable CS8602 // Dereference of a possibly null reference.
            var window = (Application.Current.ApplicationLifetime as IClassicDesktopStyleApplicationLifetime)?.Windows
                .FirstOrDefault(w => w.DataContext == this);
#pragma warning restore CS8602 // Dereference of a possibly null reference.
            window?.Close(); // Safe dereference
        }

        private void Cancel()
        {
            // Close the window without saving
#pragma warning disable CS8602 // Dereference of a possibly null reference.
            var window = (Application.Current.ApplicationLifetime as IClassicDesktopStyleApplicationLifetime)?.Windows
                .FirstOrDefault(w => w.DataContext == this);
#pragma warning restore CS8602 // Dereference of a possibly null reference.
            window?.Close(); // Safe dereference
        }

        private void ShowErrorDialog(string message)
        {
            var dialog = new Window
            {
                Title = "Error",
                Content = new TextBlock { Text = message },
                SizeToContent = SizeToContent.WidthAndHeight,
                WindowStartupLocation = WindowStartupLocation.CenterOwner
            };

#pragma warning disable CS8602 // Dereference of a possibly null reference.
            var mainWindow = (Application.Current.ApplicationLifetime as IClassicDesktopStyleApplicationLifetime)?.MainWindow;
#pragma warning restore CS8602 // Dereference of a possibly null reference.
            if (mainWindow != null)
            {
                dialog.ShowDialog(mainWindow); // Safe to pass
            }
            else
            {
                dialog.Show(); // Fallback if 'mainWindow' is null
            }
        }
    }
}