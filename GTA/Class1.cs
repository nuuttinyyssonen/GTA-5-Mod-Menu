using System;
using GTA;
using GTA.Native;
using GTA.Math;
using System.Windows.Forms;
using GTA.UI;

namespace GTAV_Mod_Menu
{
    public class Main : Script
    {
        // Define the sub-menu states
        private enum SubMenu
        {
            None,
            Weather,
            Vehicle,
            Player,
            World
        }
        private SubMenu currentSubMenu = SubMenu.None;
        private bool menuOpen = false;

        // Define the selected index for the main menu and sub-menus
        private int selectedMenuIndex = 0;
        private int selectedSubMenuIndex = 0;

        // Define the menu options and sub-menu options
        private readonly string[] menuOptions = { 
            "Weather Menu", 
            "Vehicle Menu", 
            "Player Menu", 
            "World Menu"
        };
        private readonly string[] weatherOptions = { 
            "Cloudy", 
            "Sunny", 
            "Rainy", 
            "Snowy" 
        };
        private readonly string[] vehicleOptions = { 
            "Adder", 
            "Zentorno", 
            "Bullet", 
            "Cheetah", 
            "Infernus", 
            "T20" 
        };
        private readonly string[] playerOptions = { 
            "God Mode", 
            "Give Weapons", 
            "Wanted Level Off", 
            "Super Speed", 
            "Infinite Ammo" 
        };
        private readonly string[] worldOptions = { 
            "Set time of day: Morning", 
            "Set time of day: Noon", 
            "Set time of day: night", 
            "Remove vehicles", 
            "Low gravity mode", 
            "Remove pedestrians" 
        };

        private bool superSpeed = false;
        public Main()
        {
            Tick += onTick;
            KeyDown += onKeyDown;
            Interval = 0;
        }

        private void onTick(object sender, EventArgs e)
        {
            if (menuOpen && currentSubMenu == SubMenu.None)
            {
                string displayText = "";
                for (int i = 0; i < menuOptions.Length; i++)
                {
                    if (i == selectedMenuIndex)
                    {
                        displayText += $"→ {menuOptions[i]}\n";
                    }
                    else
                    {
                        displayText += $"   {menuOptions[i]}\n";
                    }
                }
                GTA.UI.Screen.ShowSubtitle(displayText, 1);
            }
            else if (currentSubMenu == SubMenu.Weather)
            {
                string displayText = "Weather Menu:\n";
                for (int i = 0; i < weatherOptions.Length; i++)
                {
                    if (i == selectedSubMenuIndex)
                    {
                        displayText += $"→ {weatherOptions[i]}\n";
                    }
                    else
                    {
                        displayText += $"   {weatherOptions[i]}\n";
                    }
                }
                GTA.UI.Screen.ShowSubtitle(displayText, 1);
            }
            else if (currentSubMenu == SubMenu.Vehicle)
            {
                string displayText = "Vehicle Menu:\n";
                for (int i = 0; i < vehicleOptions.Length; i++)
                {
                    if (i == selectedSubMenuIndex)
                    {
                        displayText += $"→ {vehicleOptions[i]}\n";
                    }
                    else
                    {
                        displayText += $"   {vehicleOptions[i]}\n";
                    }
                }
                GTA.UI.Screen.ShowSubtitle(displayText, 1);
            }
        }

        private void onKeyDown(object semder, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5)
            {
                menuOpen = !menuOpen;
                if(menuOpen)
                {
                    Notification.Show("Mod menu opened!");
                } else
                {
                    Notification.Show("Mod Menu Closed!");
                }
            }

            if(!menuOpen)
            {
                return;
            }

            if(menuOpen && currentSubMenu == SubMenu.None)
            {
                switch(e.KeyCode)
                {
                    case Keys.NumPad8: // Up
                        if (selectedMenuIndex == 0)
                        {
                            selectedMenuIndex = menuOptions.Length - 1;
                        }
                        else
                        {
                            selectedMenuIndex--;
                        }
                        break;
                    case Keys.NumPad2: // Down
                        if (selectedMenuIndex == menuOptions.Length - 1)
                        {
                            selectedMenuIndex = 0;
                        }
                        else
                        {
                            selectedMenuIndex++;
                        }
                        break;
                    case Keys.NumPad5: // Select
                        ExecuteSubMenuOption(selectedMenuIndex);
                        break;
                }
            }
            else if(menuOpen)
            {
                switch (e.KeyCode)
                {
                    case Keys.NumPad8: // Up
                        if (selectedSubMenuIndex == 0)
                        {
                            selectedSubMenuIndex = menuOptions.Length - 1;
                        }
                        else
                        {
                            selectedSubMenuIndex--;
                        }
                        break;
                    case Keys.NumPad2: // Down
                        if (selectedSubMenuIndex == menuOptions.Length - 1)
                        {
                            selectedSubMenuIndex = 0;
                        }
                        else
                        {
                            selectedSubMenuIndex++;
                        }
                        break;
                    case Keys.NumPad5: // Select
                        ExecuteOptions(selectedSubMenuIndex);
                        break;
                    case Keys.NumPad0: // Back to main menu
                        currentSubMenu = SubMenu.None;
                        selectedSubMenuIndex = 0;
                        break;
                }
            }
        }

        private void ExecuteSubMenuOption(int index)
        {
            switch(index)
            {
                case 0: // Weather menu
                    currentSubMenu = SubMenu.Weather;
                    break;
                case 1: // Vehicle menu
                    currentSubMenu = SubMenu.Vehicle;
                    break;
                case 2: // Player menu
                    currentSubMenu = SubMenu.Player;
                    break;
                case 3: // World menu  
                    currentSubMenu = SubMenu.World;
                    break;
            }
        }

        private void ExecuteOptions(int index)
        {
            switch (currentSubMenu)
            {
                case SubMenu.Weather:
                    ExecuteWeatherOption(index);
                    break;
                case SubMenu.Vehicle:
                    //ExecuteVehicleOption(index);
                    break;
                case SubMenu.Player:
                    //ExecutePlayerOption(index);
                    break;
                case SubMenu.World:
                    //ExecuteWorldOption(index);
                    break;
            }
        }

        private void ExecuteWeatherOption(int index)
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

        private void ExecuteVehicleOption(int index)
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

        private void ExecutePlayerOptions(int index)
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

        private void ExecuteWorldOptions(int index)
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
    }
}
