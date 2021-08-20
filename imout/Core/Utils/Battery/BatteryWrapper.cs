using System;
using Xamarin.Essentials;
using XamarinBattery = Xamarin.Essentials.Battery;

namespace imout.Core.Utils.Battery
{
    public class BatteryWrapper
    {
        public event EventHandler OnBatteryChanged;

        public BatteryWrapper()
        {
            XamarinBattery.BatteryInfoChanged += OnChanged;
        }

        private void OnChanged(object sender, BatteryInfoChangedEventArgs e)
        {
            BatteryLevelChangedEventArgs evArgs = new BatteryLevelChangedEventArgs()
            {
                Level = e.ChargeLevel,
                IsCharging = e.State == BatteryState.Charging
            };
            
            OnChange(evArgs);
        }

        protected virtual void OnChange(BatteryLevelChangedEventArgs e)
        {
            EventHandler handler = OnBatteryChanged;
            handler?.Invoke(this, e);
        }
    }
}
