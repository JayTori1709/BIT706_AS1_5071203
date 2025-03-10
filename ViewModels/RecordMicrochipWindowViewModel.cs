using ReactiveUI;
using System;
using System.Reactive;
using WeChipItAvalonia.Views;

namespace WeChipItAvalonia.ViewModels
{
    public class RecordMicrochipWindowViewModel : ViewModelBase
    {
        public string CustomerName { get; set; } = string.Empty;
        public string AnimalName { get; set; } = string.Empty;
        public string MicrochipNumber { get; set; } = string.Empty;
        public DateTime DateIssued { get; set; } = DateTime.Now;

        public ReactiveCommand<Unit, Unit> SaveCommand { get; }
        public ReactiveCommand<Unit, Unit> CancelCommand { get; }

        public RecordMicrochipWindowViewModel()
        {
            SaveCommand = ReactiveCommand.Create(Save);
            CancelCommand = ReactiveCommand.Create(Cancel);
        }

        private void Save()
        {
            // Logic to save the microchip record
        }

        private void Cancel()
        {
            // Logic to close the window
        }
    }
}