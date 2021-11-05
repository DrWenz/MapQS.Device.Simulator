using MapQS.Device.Simulator.Core.Mvvm;

namespace MapQS.Device.Simulator.ViewModels
{
    public class MixerViewModel : ViewModelBase
    {
        private readonly ArduinoInterface ArduinoInterface = new();
        private int _channel1 = 100;

        public int Channel1
        {
            get => _channel1;
            set => SetPropertyValue(ref _channel1, value, Update);
        }

        internal override void OnOpened()
        {
            Update();
        }

        private void Update()
        {
            ArduinoInterface.UpdateValues(Channel1, 0, 0, 0, 0, 0);
        }
    }
}