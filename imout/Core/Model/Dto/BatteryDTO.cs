using System;
namespace imout.Core.Model.Dto
{
    public class BatteryDTO
    {
        public double Level { get; set; }
        public bool IsCharging { get; set; }

        public BatteryDTO(double level, bool isCharging)
        {
            Level = Level;
            IsCharging = isCharging;
        }
    }
}
