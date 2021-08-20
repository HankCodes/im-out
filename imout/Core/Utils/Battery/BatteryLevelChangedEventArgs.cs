using System;
namespace imout.Core.Utils.Battery
{
    public class BatteryLevelChangedEventArgs : EventArgs
    {
        public double Level { get; set; }
        public bool IsCharging { get; set; }
    }
}
