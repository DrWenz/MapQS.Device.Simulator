using Avalonia.Controls;
using MapQS.Device.Simulator.Core.Mvvm;

namespace MapQS.Device.Simulator.Core.Controls
{
    /// <summary>
    ///     Base class for a page with all necessary base functions
    /// </summary>
    public abstract class Page : UserControl
    {
        protected override void OnInitialized()
        {
            base.OnInitialized();
            if (DataContext is not ViewModelBase vm) return;
            vm.SetParent(this);
            vm.OnOpened();
        }
    }
}