using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;

namespace WeChipItAvalonia.Views
{
    public partial class MessageBox : Window
    {
        public MessageBox()
        {
            InitializeComponent();
        }

        // Constructor with title and message
        public MessageBox(string title, string message)
        {
            InitializeComponent();
            Title = title;
#pragma warning disable CS8602 // Dereference of a possibly null reference.
            this.FindControl<TextBlock>("MessageText").Text = message;
#pragma warning restore CS8602 // Dereference of a possibly null reference.
        }

        private void OnOkClicked(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}