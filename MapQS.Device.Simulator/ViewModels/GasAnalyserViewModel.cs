using System;
using MapQS.Device.Simulator.Core.Mvvm;

namespace MapQS.Device.Simulator.ViewModels
{
    public class GasAnalyserViewModel : ViewModelBase
    {
        private readonly ArduinoInterface ArduinoInterface = new();
        private double _channel1 = 2;
        private double _channel2 = 10;
        private double _channel3 = 88;

        public GasAnalyserViewModel()
        {
            ArduinoInterface.UpdateMinMaxValues(0, 100, 0, 100, 0, 100, 0, 0, 0, 0, 0, 0);
        }

        public double Channel1
        {
            get => _channel1;
            set => SetPropertyValue(ref _channel1, value, Update);
        }

        public double Channel2
        {
            get => _channel2;
            set => SetPropertyValue(ref _channel2, value, Update);
        }

        public double Channel3
        {
            get => _channel3;
            set => SetPropertyValue(ref _channel3, value, Update);
        }

        public double Channel1Min => ArduinoInterface.Channel1Min;
        public double Channel1Max => ArduinoInterface.Channel1Max;
        public double Channel2Min => ArduinoInterface.Channel2Min;
        public double Channel2Max => ArduinoInterface.Channel2Max;
        public double Channel3Min => ArduinoInterface.Channel3Min;
        public double Channel3Max => ArduinoInterface.Channel3Max;

        internal override void OnOpened()
        {
            Update();
        }

        private void Update()
        {
            ArduinoInterface.UpdateValues(Channel1, Channel2, Channel3, 0, 0, 0);
        }

        public void SetValuesFromString(string value)
        {
            string[] data = value.Replace(" ", "").Split("-");
            if (data.Length == 3)
            {
                Channel1 = Convert.ToInt32(data[0]);
                Channel2 = Convert.ToInt32(data[1]);
                Channel3 = Convert.ToInt32(data[2]);
            }
        }
    }
}