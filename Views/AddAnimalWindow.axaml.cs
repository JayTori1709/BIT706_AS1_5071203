using ReactiveUI;
using Avalonia.Controls;
using System.Collections.Generic;
using System.Reactive;
using WeChipItAvalonia.ViewModels;
using Avalonia.Markup.Xaml;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia;
using System.Linq;
using System.Threading.Tasks;

namespace WeChipItAvalonia.Views
{
    public partial class AddAnimalWindow : Window
    {
        // Properties
        public string AnimalName { get; set; } = string.Empty;
        public List<string> AnimalTypes { get; } = new List<string> { "Cat", "Dog" };
        public string SelectedAnimalType { get; set; } = string.Empty;
        public List<string> SexOptions { get; } = new List<string> { "Male", "Female" };
        public string SelectedSex { get; set; } = string.Empty;
        public bool IsMicrochipped { get; set; }

        public ReactiveCommand<Unit, Unit> SaveCommand { get; }
        public ReactiveCommand<Unit, Unit> CancelCommand { get; }

        public AddAnimalWindow(AddAnimalWindowViewModel viewModel)
        {
            InitializeComponent();
            DataContext = viewModel;

            // Initialize commands
            SaveCommand = ReactiveCommand.CreateFromTask(async () =>
            {
                await viewModel.SaveAnimalAsync(); // Use the passed viewModel instance
                Close();
            });

            CancelCommand = ReactiveCommand.Create(() =>
            {
                Close();
            });
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }

    public class ViewModelBase : ReactiveObject
    {
    }
}