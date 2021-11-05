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
            _init = true;
#endif
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
                if (!_dataChanged)
                {
                    await Task.Delay(125);
                    continue;
                }
#if DEBUG
                Console.WriteLine(
                    $"C1:{Channel1} C2: {Channel2} C3: {Channel3} C4: {Channel4} C5: {Channel5} C6: {Channel6}");
                _dataChanged = false;
#else
                _device.Write(new[]
                {
                    (byte)0x01,
                    (byte)Channel1,
                    (byte)Channel2,
                    (byte)Channel3,
                    (byte)Channel4,
                    (byte)Channel5,
                    (byte)Channel6,
                    (byte)0x04
                });
                _dataChanged = false;
#endif
                await Task.Delay(125);
            }
        }

        public void UpdateValues(int c1, int c2, int c3, int c4, int c5, int c6)
        {
            if (!_running)
                Start();

            SetChannelValue(ref _channel1, c1);
            SetChannelValue(ref _channel2, c2);
            SetChannelValue(ref _channel3, c3);
            SetChannelValue(ref _channel4, c4);
            SetChannelValue(ref _channel5, c5);
            SetChannelValue(ref _channel6, c6);
        }

        private void SetChannelValue(ref int channel, int c1)
        {
            var newValue = c1 switch
            {
                < AnalogMinValue => AnalogMinValue,
                > AnalogMaxValue => AnalogMaxValue,
                _ => c1
            };
            if (newValue != channel)
            {
                channel = newValue;
                _dataChanged = true;
            }
        }

        #region Public Deklaration

        public int Channel1 => _channel1;
        public int Channel2 => _channel2;
        public int Channel3 => _channel3;
        public int Channel4 => _channel4;
        public int Channel5 => _channel5;
        public int Channel6 => _channel6;

        #endregion

        #region Private Deklaration

        private I2cBus _bus;
        private I2cDevice _device;
        private bool _init = true;
        private bool _running;
        private bool _dataChanged;
        private const int AnalogMinValue = 50;
        private const int AnalogMaxValue = 225;
        private int _channel1;
        private int _channel2;
        private int _channel3;
        private int _channel4;
        private int _channel5;
        private int _channel6;
        private int _channel7 = 0;
        private int _channel8 = 0;
        private int _channel9 = 0;
        private int _channel10 = 0;
        private int _channel11 = 0;
        private int _channel12 = 0;

        #endregion
    }
}