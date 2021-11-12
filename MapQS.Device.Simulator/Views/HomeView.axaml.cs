using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using MapQS.Device.Simulator.Core.Controls;

namespace MapQS.Device.Simulator.Views
{
    public class HomeView : Page
    {
        public HomeView()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}