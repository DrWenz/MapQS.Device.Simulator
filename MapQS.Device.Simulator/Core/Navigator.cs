using MapQS.Device.Simulator.Core.Controls;
using MapQS.Device.Simulator.Core.Mvvm;
using MapQS.Device.Simulator.Views;

namespace MapQS.Device.Simulator.Core
{
    public static class Navigation
    {
        public static Navigator Navigator { get; } = new();
    }

    public class Navigator : NotifyPropertyChangedObject
    {
        public void GoToHome()
        {
            IsHome = true;
            Header = "Auswahl Geräte-Simulator";
            Page = new HomeView();
        }
        
        public void GoToGasMixer()
        {
            IsHome = false;
            Header = "Gasmischersimulation";
            Page = new GasMixerView();
        }
        
        public void GoToGasAnalyser()
        {
            IsHome = false;
            Header = "Gasanalysesimulation";
            Page = new GasAnalyserView();
        }

        #region Private Deklaration

        private bool _isHome = true;
        private string _header = "";
        private Page _page;

        #endregion

        #region Public Deklaration

        public Page Page
        {
            get => _page;
            set => SetPropertyValue(ref _page, value);
        }

        public bool IsHome
        {
            get => _isHome;
            private set => SetPropertyValue(ref _isHome, value);
        }

        public string Header
        {
            get => _header;
            private set => SetPropertyValue(ref _header, value);
        }

        #endregion
    }
}