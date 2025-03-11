using ReactiveUI;
using System.Reactive;
using WeChipItAvalonia.Models;
using WeChipItAvalonia.Services;
using Avalonia.Controls;
using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using System.Linq;

namespace WeChipItAvalonia.ViewModels
{
    public class AddCustomerWindowViewModel : Views.ViewModelBase
    {
        private string _name = string.Empty;
        private string _contact = string.Empty;
        private string _email = string.Empty;
        private string _address = string.Empty;

        public string Name
        {
            get => _name;
            set => this.RaiseAndSetIfChanged(ref _name, value);
        }

        public string Contact
        {
            get => _contact;
            set => this.RaiseAndSetIfChanged(ref _contact, value);
        }

        public string Email
        {
            get => _email;
            set => this.RaiseAndSetIfChanged(ref _email, value);
        }

        public string Address
        {
            get => _address;
            set => this.RaiseAndSetIfChanged(ref _address, value);
        }

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

            if (string.IsNullOrWhiteSpace(Email))
            {
                ShowErrorDialog("Email is required!");
                return;
            }

            if (string.IsNullOrWhiteSpace(Address))
            {
                ShowErrorDialog("Address is required!");
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