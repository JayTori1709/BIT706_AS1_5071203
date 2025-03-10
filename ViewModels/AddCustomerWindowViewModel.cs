using ReactiveUI;
using System.Reactive;
using WeChipItAvalonia.Models;
using WeChipItAvalonia.Services;
using Avalonia.Controls;
using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using WeChipItAvalonia.Views;
using System.Linq;

namespace WeChipItAvalonia.ViewModels
{
    public class AddCustomerWindowViewModel : ViewModelBase
    {
        public string Name { get; set; } = string.Empty;
        public string Contact { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;

        public ReactiveCommand<Unit, Unit> SaveCommand { get; }
        public ReactiveCommand<Unit, Unit> CancelCommand { get; }

        public AddCustomerWindowViewModel()
        {
            SaveCommand = ReactiveCommand.Create(Save);
            CancelCommand = ReactiveCommand.Create(Cancel);
        }

        private void Save()
        {
            // Validate the input
            if (string.IsNullOrWhiteSpace(Name))
            {
                ShowErrorDialog("Name is required.");
                return;
            }

            if (string.IsNullOrWhiteSpace(Contact))
            {
                ShowErrorDialog("Phone number is required.");
                return;
            }

            // Check if a customer with the same phone number already exists
            var existingCustomer = DataStore.Instance.GetCustomerByPhone(Contact);
            if (existingCustomer != null)
            {
                ShowErrorDialog("A customer with this phone number already exists.");
                return;
            }

            // Create a new customer
            var customer = new Customer
            {
                Name = Name,
                Contact = Contact,
                Email = Email,
                Address = Address
            };

            // Add the customer to the data store
            DataStore.Instance.AddCustomer(customer);

            // Close the window
            var window = (Application.Current.ApplicationLifetime as IClassicDesktopStyleApplicationLifetime)?.Windows
                .FirstOrDefault(w => w.DataContext == this);
            window?.Close(); // Safe dereference
        }

        private void Cancel()
        {
            // Close the window without saving
            var window = (Application.Current.ApplicationLifetime as IClassicDesktopStyleApplicationLifetime)?.Windows
                .FirstOrDefault(w => w.DataContext == this);
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

            var mainWindow = (Application.Current.ApplicationLifetime as IClassicDesktopStyleApplicationLifetime)?.MainWindow;
            if (mainWindow != null)
            {
                dialog.ShowDialog(mainWindow); // Safe to pass
            }
            else
            {
                // Handle the case where 'mainWindow' is null
                dialog.Show();
            }
        }
    }
}