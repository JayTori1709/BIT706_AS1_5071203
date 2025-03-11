using Avalonia.Controls;
using ReactiveUI;
using System;
using System.Reactive;

namespace WeChipItAvalonia.Views
{
    public partial class AddCustomerWindow : Window // Fix the class name here
    {
        public new string Name { get; set; } = string.Empty;
        public string Contact { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;

        public ReactiveCommand<Unit, Unit> SaveCommand { get; }
        public ReactiveCommand<Unit, Unit> CancelCommand { get; }

        public AddCustomerWindow() // Fix the constructor name here
        {
            InitializeComponent();
            SaveCommand = ReactiveCommand.Create(Save);
            CancelCommand = ReactiveCommand.Create(Cancel);
        }

        private void Save()
        {
            // Logic to save the customer
        }

        private void Cancel()
        {
            // Logic to close the window
        }
    }
}