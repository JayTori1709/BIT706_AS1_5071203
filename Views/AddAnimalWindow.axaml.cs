using ReactiveUI;
using Avalonia.Controls;
using System.Collections.Generic;
using System.Reactive;
using WeChipItAvalonia.ViewModels;
using Avalonia.Markup.Xaml;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia;
using System.Linq;

namespace WeChipItAvalonia.Views
{
    public partial class AddAnimalWindow : Window
    {
         public AddAnimalWindow()
        {
            InitializeComponent();
            SaveCommand = ReactiveCommand.Create(Save);
            CancelCommand = ReactiveCommand.Create(Cancel);
            DataContext = new AddCustomerWindowViewModel();
            DataContext = new AddAnimalWindowViewModel();
        }
       // Properties
        public string AnimalName { get; set; } = string.Empty;
        public List<string> AnimalTypes { get; } = new List<string> { "Cat", "Dog" };
        public string SelectedAnimalType { get; set; } = string.Empty;
        public List<string> SexOptions { get; } = new List<string> { "Male", "Female" };
        public string SelectedSex { get; set; } = string.Empty;
        public bool IsMicrochipped { get; set; }

        public ReactiveCommand<Unit, Unit> SaveCommand { get; }
        public ReactiveCommand<Unit, Unit> CancelCommand { get; }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }

        public AddAnimalWindow(AddAnimalWindowViewModel viewModel)
        {
            InitializeComponent();
            DataContext = viewModel;

            //Initialize commands
            SaveCommand = ReactiveCommand.CreateFromTask(async () =>
            {

                await AddAnimalWindowViewModel.SaveAnimalAsync();
                Close();
            });
            
            CancelCommand = ReactiveCommand.Create(() =>
            {
                Close();
            });

        }

        private void Save()
        {
            // Logic to save the animal
        }

        private void Cancel()
        {
            // Logic to close the window
#pragma warning disable CS8602 // Dereference of a possibly null reference.
            var window = (Application.Current.ApplicationLifetime as IClassicDesktopStyleApplicationLifetime)?.Windows
                .FirstOrDefault(w => w.DataContext == this);
#pragma warning restore CS8602 // Dereference of a possibly null reference.
            window?.Close(); // Safe dereference
        }
    }

    public class ViewModelBase : ReactiveObject
    {
    }
}