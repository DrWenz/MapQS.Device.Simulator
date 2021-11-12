using System;
using System.Device.I2c;
using System.Threading.Tasks;

namespace MapQS.Device.Simulator
{
    public class ArduinoInterface
    {
        private void Init()
        {
            if (_init)
                return;
#if DEBUG
#else
            _bus = I2cBus.Create(10);
            _device = I2cDevice.Create(new I2cConnectionSettings(10, 4));
#endif
            _init = true;
        }

        public void Start()
        {
            Init();
            _running = true;
            Task.Factory.StartNew(Worker);
        }

        public void Stop()
        {
            _running = false;
        }

        private async void Worker()
        {
            while (_running)
            {
                try
                {
                    if (!_dataChanged)
                    {
                        await Task.Delay(125);
                        continue;
                    }

                    var c1 = ConvertToAnalogValue(_channel1, Channel1Min, Channel1Max);
                    var c2 = ConvertToAnalogValue(_channel2, Channel2Min, Channel2Max);
                    var c3 = ConvertToAnalogValue(_channel3, Channel3Min, Channel3Max);
                    var c4 = ConvertToAnalogValue(_channel4, Channel4Min, Channel5Max);
                    var c5 = ConvertToAnalogValue(_channel5, Channel4Min, Channel5Max);
                    var c6 = ConvertToAnalogValue(_channel6, _channel6Min, _channel6Max);
#if DEBUG
                    Console.WriteLine(
                        $"C1:{c2} C2: {c2} C3: {c3} C4: {c4} C5: {c5} C6: {c6}");
                    _dataChanged = false;
#else
                _device.Write(new[]
                {
                    (byte)0x01,
                    (byte)c1,
                    (byte)c2,
                    (byte)c3,
                    (byte)c4,
                    (byte)c5,
                    (byte)c6,
                    (byte)0x04
                });
                _dataChanged = false;
#endif
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
                await Task.Delay(125);
            }
        }

        private int ConvertToAnalogValue(double value, double min, double max)
        {
            var res = (value - min) * (AnalogMaxValue - AnalogMinValue) / (max - min) + AnalogMinValue;
            return (int)Math.Round(res, 0);
        }

        public void UpdateValues(double c1, double c2, double c3, double c4, double c5, double c6)
        {
            if (!_running)
                Start();

            SetChannelValue(ref _channel1, Channel1Min, Channel1Max, c1);
            SetChannelValue(ref _channel2, Channel2Min, Channel2Max, c2);
            SetChannelValue(ref _channel3, Channel3Min, Channel3Max, c3);
            SetChannelValue(ref _channel4, Channel4Min, Channel4Max, c4);
            SetChannelValue(ref _channel5, Channel5Min, Channel5Max, c5);
            SetChannelValue(ref _channel6, _channel6Min, _channel6Max, c6);
        }

        public void UpdateMinMaxValues(double c1Min, double c1Max, double c2Min, double c2Max, double c3Min,
            double c3Max, double c4Min, double c4Max, double c5Min, double c5Max, double c6Min, double c6Max)
        {
            Channel1Min = c1Min;
            Channel1Max = c1Max;
            Channel2Min = c2Min;
            Channel2Max = c2Max;
            Channel3Min = c3Min;
            Channel3Max = c3Max;
            Channel4Min = c4Min;
            Channel4Max = c4Max;
            Channel5Min = c5Min;
            Channel5Max = c5Max;
            _channel6Min = c6Min;
            _channel6Max = c6Max;
        }

        private void SetChannelValue(ref double channel, double min, double max, double value)
        {
            var newValue = value;
            if (value < min)
                newValue = min;
            if (value > max)
                newValue = max;
            if (newValue == channel) return;
            channel = newValue;
            _dataChanged = true;
        }

        #region Public Deklaration

        public double Channel1 => _channel1;
        public double Channel1Min { get; private set; }

        public double Channel1Max { get; private set; }

        public double Channel2 => _channel2;
        public double Channel2Min { get; private set; }

        public double Channel2Max { get; private set; }

        public double Channel3 => _channel3;
        public double Channel3Min { get; private set; }

        public double Channel3Max { get; private set; }

        public double Channel4 => _channel2;
        public double Channel4Min { get; private set; }

        public double Channel4Max { get; private set; }

        public double Channel5 => _channel3;
        public double Channel5Min { get; private set; }

        public double Channel5Max { get; private set; }

        #endregion

        #region Private Deklaration

        private I2cBus _bus;
        private I2cDevice _device;
        private bool _init;
        private bool _running;
        private bool _dataChanged;
        private const int AnalogMinValue = 50;
        private const int AnalogMaxValue = 218;
        private double _channel1;
        private double _channel2;
        private double _channel3;
        private double _channel4;
        private double _channel5;
        private double _channel6;
        private double _channel6Min;
        private double _channel6Max;

        #endregion
    }
}