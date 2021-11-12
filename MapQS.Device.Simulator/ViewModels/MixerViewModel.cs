using MapQS.Device.Simulator.Core.Mvvm;

namespace MapQS.Device.Simulator.ViewModels
{
    public class MixerViewModel : ViewModelBase
    {
        private readonly ArduinoInterface ArduinoInterface = new();
        private double _channel1 = 9.5;
        private bool _channel1Closed;
        private double _channel2 = 8.2;
        private bool _channel2Closed;
        private double _channel3 = 20;
        private bool _channel3Closed;
        private double _channel4 = 7;
        private double _channel5 = 4.5;

        public MixerViewModel()
        {
            ArduinoInterface.UpdateMinMaxValues(0, 20, 0, 20, 0, 20, 0, 20, 0, 20, 0, 0);
        }

        public bool Channel1Closed
        {
            get => _channel1Closed;
            set => SetPropertyValue(ref _channel1Closed, value, Update);
        }

        public bool Channel2Closed
        {
            get => _channel2Closed;
            set => SetPropertyValue(ref _channel2Closed, value, Update);
        }

        public bool Channel3Closed
        {
            get => _channel3Closed;
            set => SetPropertyValue(ref _channel3Closed, value, Update);
        }

        public double Channel1
        {
            get => _channel1Closed ? Channel1Min : _channel1;
            set => SetPropertyValue(ref _channel1, value, Update);
        }

        public double Channel2
        {
            get => _channel2Closed ? Channel2Min : _channel2;
            set => SetPropertyValue(ref _channel2, value, Update);
        }

        public double Channel3
        {
            get => _channel3Closed ? Channel3Min : _channel3;
            set => SetPropertyValue(ref _channel3, value, Update);
        }

        public double Channel4
        {
            get => _channel4;
            set => SetPropertyValue(ref _channel4, value, Update);
        }

        public double Channel5
        {
            get => _channel5;
            set => SetPropertyValue(ref _channel5, value, Update);
        }

        public double Channel1Min => ArduinoInterface.Channel1Min;
        public double Channel1Max => ArduinoInterface.Channel1Max;
        public double Channel2Min => ArduinoInterface.Channel2Min;
        public double Channel2Max => ArduinoInterface.Channel2Max;
        public double Channel3Min => ArduinoInterface.Channel3Min;
        public double Channel3Max => ArduinoInterface.Channel3Max;
        public double Channel4Min => ArduinoInterface.Channel4Min;
        public double Channel4Max => ArduinoInterface.Channel4Max;
        public double Channel5Min => ArduinoInterface.Channel5Min;
        public double Channel5Max => ArduinoInterface.Channel5Max;

        internal override void OnOpened()
        {
            Update();
        }

        private void Update()
        {
            ArduinoInterface.UpdateValues(Channel1, Channel2, Channel3, Channel4, Channel5, 0);
        }

        public void ToggleChannel1Closed()
        {
            Channel1Closed = !Channel1Closed;
        }

        public void ToggleChannel2Closed()
        {
            Channel2Closed = !Channel2Closed;
        }

        public void ToggleChannel3Closed()
        {
            Channel3Closed = !Channel3Closed;
        }
    }
}