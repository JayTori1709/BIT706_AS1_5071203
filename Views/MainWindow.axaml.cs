using Avalonia.Controls;
using ReactiveUI;
using System;
using System.Reactive;

namespace WeChipItAvalonia.Views
{
    public partial class MainWindow : Window
    {
        public ReactiveCommand<Unit, Unit> AddCustomerCommand { get; }
        public ReactiveCommand<Unit, Unit> AddAnimalCommand { get; }
        public ReactiveCommand<Unit, Unit> RecordMicrochipCommand { get; }
        public ReactiveCommand<Unit, Unit> ExitCommand { get; }

        public MainWindow()
        {
            InitializeComponent();
            AddCustomerCommand = ReactiveCommand.Create(AddCustomer);
            AddAnimalCommand = ReactiveCommand.Create(AddAnimal);
            RecordMicrochipCommand = ReactiveCommand.Create(RecordMicrochip);
            ExitCommand = ReactiveCommand.Create(Exit);
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

        private void Exit()
        {
            // Logic to exit the application
        }

        private class AddCustomerWindow
        {
            public AddCustomerWindow()
            {
            }

            internal void Show()
            {
                throw new NotImplementedException();
            }
        }

        private class AddAnimalWindow
        {
            public AddAnimalWindow()
            {
            }

            internal void Show()
            {
                throw new NotImplementedException();
            }
        }

        private class RecordMicrochipWindow
        {
            public RecordMicrochipWindow()
            {
            }

            internal void Show()
            {
                throw new NotImplementedException();
            }
        }
    }
}