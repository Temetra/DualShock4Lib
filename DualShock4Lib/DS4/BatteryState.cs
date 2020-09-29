using System;

namespace DualShock4Lib
{
	// Possible charging states
	public enum ChargingState
	{
		Discharging,
		Charging,
		FullyCharged
	}

	public class BatteryState
	{
		// Charge level as a percentage
		public double Level { get; set; }

		// Charging state
		public ChargingState ChargingState { get; set; }

		// Returns battery state for input report data
		internal static BatteryState GetBatteryState(byte[] data, bool viaUSB)
		{
			BatteryState result = null;

			// Check report
			if (data != null)
			{
				// Battery state is @ byte 30 for USB, byte 32 for bluetooth
				int offset = (viaUSB ? 30 : 32);

				// Lower half is battery level
				int level = data[offset] & 0x0f;

				// Upper half is charging state
				int charging = data[offset] & 0x10;

				// Bluetooth power level is between 0 to 9
				// DS4Windows says the max BT level is 8
				// Cabled power level is between 0 to 10
				// Cabled power level > 10 means fully charged
				const double maxBatteryBT = 8.0;
				const double maxBatteryUSB = 10.0;
				double batteryLevel = -1;
				var batteryCharging = ChargingState.Discharging;

				// Get values
				if (charging != 0)
				{
					batteryLevel = Math.Min(level, maxBatteryUSB) * 10.0;
					batteryCharging = level > 10 ? ChargingState.FullyCharged : ChargingState.Charging;
				}
				else
				{
					batteryLevel = (Math.Min(level, maxBatteryBT) / maxBatteryBT) * 100;
					batteryCharging = ChargingState.Discharging;
				}

				// Create object
				result = new BatteryState
				{ 
					Level = batteryLevel, 
					ChargingState = batteryCharging
				};
			}

			return result;
		}
	}
}