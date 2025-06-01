using System;
using GTA;
using GTA.Native;
using GTA.Math;
using System.Windows.Forms;
using GTA.UI;

namespace MenuActions
{
	public static class SubMenuActions
	{
		public static bool superSpeed = false;
		public static void ExecuteWorldOption(int index)
		{
			switch (index)
			{
				case 0: // Set time of day: Morning
					World.CurrentTimeOfDay = new TimeSpan(6, 0, 0); // 6 AM
					Notification.Show("Time set to Morning!");
					break;
				case 1: // Set time of day: Noon
					World.CurrentTimeOfDay = new TimeSpan(12, 0, 0); // 12 PM
					Notification.Show("Time set to Noon!");
					break;
				case 2: // Set time of day: Night
					World.CurrentTimeOfDay = new TimeSpan(20, 0, 0); // 8 PM
					Notification.Show("Time set to Night!");
					break;
				case 3: // Remove vehicles
					foreach (Vehicle vehicle in World.GetAllVehicles())
					{
						vehicle.Delete();
					}
					Notification.Show("All vehicles removed!");
					break;
				case 4: // Low gravity mode
					Function.Call(Hash.SET_GRAVITY_LEVEL, 1); // Set low gravity level
					Notification.Show("Low gravity mode activated!");
					break;
				case 5: // Remove pedestrians
					foreach (Ped ped in World.GetAllPeds())
					{
						ped.Delete();
					}
					Notification.Show("All pedestrians removed!");
					break;
			}
		}

		public static void ExecuteVehicleOption(int index)
		{
			VehicleHash carHash = VehicleHash.Adder; // Default vehicle
			switch (index)
			{
				case 0:
					carHash = VehicleHash.Adder;
					break;
				case 1:
					carHash = VehicleHash.Zentorno;
					break;
				case 2:
					carHash = VehicleHash.Bullet;
					break;
				case 3:
					carHash = VehicleHash.Cheetah;
					break;
				case 4:
					carHash = VehicleHash.Infernus;
					break;
				case 5:
					carHash = VehicleHash.T20;
					break;
			}
			Vector3 playerPositionOffset = Game.Player.Character.GetOffsetPosition(new Vector3(0, 5, 0));
			Vehicle car = World.CreateVehicle(carHash, playerPositionOffset);
			if (car != null)
			{
				car.PlaceOnGround();
				Notification.Show($"{car.DisplayName} spawned!");
			}
			else
			{
				Notification.Show("Vehicle creation failed!");
			}
		}

		public static void ExecutePlayerOption(int index)
		{
			switch (index)
			{
				case 0: // God Mode
					Game.Player.Character.IsInvincible = true;
					Notification.Show("God Mode Activated!");
					break;
				case 1: // Give Weapons
					Game.Player.Character.Weapons.Give(WeaponHash.AssaultRifle, 200, true, true);
					Game.Player.Character.Weapons.Give(WeaponHash.AcidPackage, 200, false, true);
					Game.Player.Character.Weapons.Give(WeaponHash.Firework, 10, false, true);
					Game.Player.Character.Weapons.Give(WeaponHash.VintagePistol, 200, false, true);
					Game.Player.Character.Weapons.Give(WeaponHash.Minigun, 200, false, true);
					Game.Player.Character.Weapons.Give(WeaponHash.APPistol, 200, false, true);
					Notification.Show("Weapons Given!");
					break;
				case 2: // Wanted Level Off
					Game.Player.WantedLevel = 0;
					Notification.Show("Wanted Level Off!");
					break;
				case 3: // Super Speed
					superSpeed = !superSpeed;
					if (superSpeed)
					{
						Game.Player.Character.Speed = 10f; // Set speed to a high value
						Notification.Show("Super Speed Activated!");
					}
					else
					{
						Game.Player.Character.Speed = 1f; // Reset speed to normal
						Notification.Show("Super Speed Deactivated!");
					}
					break;
				case 4: // Infinite Ammo
					Game.Player.Character.Weapons.Current.InfiniteAmmo = true;
					Notification.Show("Ammo set to infinite!");
					break;
			}
		}

		public static void ExecuteWeatherOption(int index)
		{
			switch (index)
			{
				case 0:
					World.Weather = Weather.Clouds;
					Notification.Show("Weather set to Cloudy!");
					break;
				case 1:
					World.Weather = Weather.Clear;
					Notification.Show("Weather set to Sunny!");
					break;
				case 2:
					World.Weather = Weather.Raining;
					Notification.Show("Weather set to Rainy!");
					break;
				case 3:
					World.Weather = Weather.Snowing;
					Notification.Show("Weather set to Snowy!");
					break;
			}
		}
	}
}