using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using MapQS.Device.Simulator.Core.Mvvm;

namespace MapQS.Device.Simulator.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        public void Close()
        {
            if (Application.Current.ApplicationLifetime is ClassicDesktopStyleApplicationLifetime x)
                x.Shutdown();
        }
    }
}