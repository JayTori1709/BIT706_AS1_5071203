using Avalonia.Controls;
using ReactiveUI;
using System;
using System.Reactive;

namespace WeChipItAvalonia.Views
{
    public partial class RecordMicrochipWindow : Window

    {
        public string CustomerName { get; set; }
        public string AnimalName { get; set; }
        public string MicrochipNumber { get; set; }
        public DateTime DateIssued { get; set; } = DateTime.Now;

        public ReactiveCommand<Unit, Unit> SaveCommand { get; }
        public ReactiveCommand<Unit, Unit> CancelCommand { get; }

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
        public RecordMicrochipWindow()
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
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