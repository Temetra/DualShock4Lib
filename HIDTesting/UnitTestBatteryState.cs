using System;
using DualShock4Lib;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HIDTesting
{
	[TestClass]
	public partial class UnitTestBatteryState
	{
		[TestMethod]
		public void TestGetBatteryState()
		{
			// Using previously captured data
			byte[] data = Convert.FromBase64String("EcAAhHmEfQgAYAAAOhf9/v8DAAkAuQAIIBwGAAAAAAAIAAAAAIAAAACAAAAAAIAAAACAAAAAAIAAAACAAAAAAIAAAACAAAAAAADAZYpYAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA==");
			bool viaUSB = false;

			// Get battery state
			BatteryState battery = BatteryState.GetBatteryState(data, viaUSB);

			// Test
			Assert.IsNotNull(battery);
			Assert.AreEqual(88.88888888888889, battery.Level);
			Assert.AreEqual(ChargingState.Discharging, battery.ChargingState);
		}
	}
}
