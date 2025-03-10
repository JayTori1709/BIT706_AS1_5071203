using ReactiveUI;
using Avalonia.Controls;
using System.Collections.Generic;
using System.Reactive;
using WeChipItAvalonia.ViewModels;

namespace WeChipItAvalonia.Views
{
    public partial class AddAnimalWindow : Window
    {
        public string AnimalName { get; set; } = string.Empty;
        public List<string> AnimalTypes { get; } = new List<string> { "Cat", "Dog" };
        public string SelectedAnimalType { get; set; } = string.Empty;
        public List<string> SexOptions { get; } = new List<string> { "Male", "Female" };
        public string SelectedSex { get; set; } = string.Empty;
        public bool IsMicrochipped { get; set; }

        public ReactiveCommand<Unit, Unit> SaveCommand { get; }
        public ReactiveCommand<Unit, Unit> CancelCommand { get; }

        public AddAnimalWindow()
        {
            InitializeComponent();
            SaveCommand = ReactiveCommand.Create(Save);
            CancelCommand = ReactiveCommand.Create(Cancel);
            DataContext = new AddCustomerWindowViewModel();
        }

        private void Save()
        {
            // Logic to save the animal
        }

        private void Cancel()
        {
            // Logic to close the window
        }
    }

    public class ViewModelBase
    {
    }
}