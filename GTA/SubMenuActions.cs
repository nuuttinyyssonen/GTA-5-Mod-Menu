using System;
using GTA;
using GTA.Native;
using GTA.Math;
using System.Windows.Forms;
using GTA.UI;
using teleport;
using GTAV_Mod_Menu;

namespace MenuActions
{
	public static class SubMenuActions
	{
        public static void ExecuteWorldOption(int index)
		{
			switch (index)
			{
				case 0: // Set time of day: Morning
                    World.CurrentTimeOfDay = new TimeSpan(6, 0, 0); // 6 AM
                    Notification.PostTicker("Time set to Morning!", false);
					break;
				case 1: // Set time of day: Noon
					World.CurrentTimeOfDay = new TimeSpan(12, 0, 0); // 12 PM
					Notification.PostTicker("Time set to Noon!", false);
					break;
				case 2: // Set time of day: Night
					World.CurrentTimeOfDay = new TimeSpan(20, 0, 0); // 8 PM
					Notification.PostTicker("Time set to Night!", false);
					break;
				case 3: // Remove vehicles
					foreach (Vehicle vehicle in World.GetAllVehicles())
					{
						vehicle.Delete();
					}
					Notification.PostTicker("All vehicles removed!", false);
					break;
				case 4: // Low gravity mode
					Function.Call(Hash.SET_GRAVITY_LEVEL, 1); // Set low gravity level
					Notification.PostTicker("Low gravity mode activated!", false);
					break;
				case 5: // Remove pedestrians
					foreach (Ped ped in World.GetAllPeds())
					{
						ped.Delete();
					}
					Notification.PostTicker("All pedestrians removed!", false);
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
				Notification.PostTicker($"{car.DisplayName} spawned!", false);
			}
			else
			{
				Notification.PostTicker("Vehicle creation failed!", false);
			}
		}

		public static void ExecutePlayerOption(int index)
		{
			switch (index)
			{
				case 0: // God Mode
					Game.Player.Character.IsInvincible = true;
					Notification.PostTicker("God Mode Activated!", false);
					break;
				case 1: // Give Weapons
					Game.Player.Character.Weapons.Give(WeaponHash.AssaultRifle, 200, true, true);
					Game.Player.Character.Weapons.Give(WeaponHash.AcidPackage, 200, false, true);
					Game.Player.Character.Weapons.Give(WeaponHash.Firework, 10, false, true);
					Game.Player.Character.Weapons.Give(WeaponHash.VintagePistol, 200, false, true);
					Game.Player.Character.Weapons.Give(WeaponHash.Minigun, 200, false, true);
					Game.Player.Character.Weapons.Give(WeaponHash.APPistol, 200, false, true);
					Notification.PostTicker("Weapons Given!", false);
					break;
				case 2: // Wanted Level Off
					Game.Player.Wanted.SetWantedLevel(0, false);
					Game.Player.Wanted.ApplyWantedLevelChangeNow(false);
                    Notification.PostTicker("Wanted Level Off!", false);
					break;
				case 3: // Super Speed
                    Main.superSpeed = !Main.superSpeed;
                    Notification.PostTicker("Super Speed!", false);
                    break;
				case 4: // Infinite Ammo
					Game.Player.Character.Weapons.Current.InfiniteAmmo = true;
					Notification.PostTicker("Ammo set to infinite!", false);
					break;
				case 5: // Super Jump
                    Main.superJump = !Main.superJump;
                    Notification.PostTicker("Super Jump!", false);
                    break;
				case 6: // Vehicle Fire
                    Main.vehicleFire = !Main.vehicleFire;
                    if (Main.vehicleFire)
                    {
                        Notification.PostTicker("Vehicle Fire Enabled!", false);
                    }
                    else
                    {
                        Notification.PostTicker("Vehicle Fire Disabled!", false);
                    }
					break;
            }
		}

		public static void ExecuteWeatherOption(int index)
		{
			switch (index)
			{
				case 0:
					World.Weather = Weather.Clouds;
					Notification.PostTicker("Weather set to Cloudy!", false);
					break;
				case 1:
					World.Weather = Weather.Clear;
					Notification.PostTicker("Weather set to Sunny!", false);
					break;
				case 2:
					World.Weather = Weather.Raining;
					Notification.PostTicker("Weather set to Rainy!", false);
					break;
				case 3:
					World.Weather = Weather.Snowing;
					Notification.PostTicker("Weather set to Snowy!", false);
					break;
			}
		}

		public static void ExecuteTeleportOption(int index)
		{
			switch (index)
			{
				case 0:
					Vector3 mountChilliadCoords = new Vector3(450.718f, 5566.614f, 806.183f);
					TeleportToCoords.teleportTo(mountChilliadCoords[0], mountChilliadCoords[1], mountChilliadCoords[2]);
					break;
				case 1:
					Vector3 lsAirportCoords = new Vector3(-1034.0f, -2730.0f, 20.0f);
					TeleportToCoords.teleportTo(lsAirportCoords[0], lsAirportCoords[1], lsAirportCoords[2]);
					break;
				case 2:
					Vector3 mazeBankRoofCoords = new Vector3(-75.0f, -819.0f, 326.0f);
					TeleportToCoords.teleportTo(mazeBankRoofCoords[0], mazeBankRoofCoords[1], mazeBankRoofCoords[2]);
					break;
				case 3:
					Vector3 fortZancudoCoords = new Vector3(-2072.8f, 3081.5f, 32.8f);
					TeleportToCoords.teleportTo(fortZancudoCoords[0], fortZancudoCoords[1], fortZancudoCoords[2]);
                    break;
            }
        }
	}
}