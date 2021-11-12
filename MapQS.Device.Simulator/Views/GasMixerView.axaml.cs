using Avalonia.Markup.Xaml;
using MapQS.Device.Simulator.Core.Controls;

namespace MapQS.Device.Simulator.Views
{
    public class GasMixerView : Page
    {
        public GasMixerView()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}