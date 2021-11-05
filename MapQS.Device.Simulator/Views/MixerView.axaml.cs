using Avalonia.Markup.Xaml;
using MapQS.Device.Simulator.Core.Controls;

namespace MapQS.Device.Simulator.Views
{
    public class MixerView : Page
    {
        public MixerView()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}