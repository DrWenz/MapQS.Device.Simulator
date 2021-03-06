using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using MapQS.Device.Simulator.Core;
using MapQS.Device.Simulator.ViewModels;

namespace MapQS.Device.Simulator
{
    public class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Navigation.Navigator.GoToHome();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}