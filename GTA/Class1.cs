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
            Vehicle
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
                        ExecuteOption(selectedSubMenuIndex);
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
            }
        }

        private void ExecuteOption(int index)
        {
            switch (index)
            {
                case 0:
                    VehicleHash carHash = VehicleHash.Adder;
                    Vector3 PlayerPositionOffSet = Game.Player.Character.GetOffsetPosition(new Vector3(0, 5, 0));
                    Vehicle car = World.CreateVehicle(carHash, PlayerPositionOffSet);
                    if(car != null)
                    {
                        car.PlaceOnGround();
                        Notification.Show("Adder spawned!");
                    } 
                    else
                    {
                        Notification.Show("Vehicle creation failed!");
                    }
                     break;
                case 1:
                    Game.Player.Character.IsInvincible = true;
                    Notification.Show("God Mode Activated!");
                    break;
                case 2:
                    Weapon weapon1 = Game.Player.Character.Weapons.Give(WeaponHash.AssaultRifle, 200, true, true);
                    Weapon weapon2 = Game.Player.Character.Weapons.Give(WeaponHash.AcidPackage, 200, false, true);
                    Weapon weapon3 = Game.Player.Character.Weapons.Give(WeaponHash.Firework, 10, false, true);
                    Weapon weapon4 = Game.Player.Character.Weapons.Give(WeaponHash.VintagePistol, 200, false, true);
                    Weapon weapon5 = Game.Player.Character.Weapons.Give(WeaponHash.Minigun, 200, false, true);
                    Weapon weapon6 = Game.Player.Character.Weapons.Give(WeaponHash.APPistol, 200, false, true);
                    Notification.Show("Weapons Given!");
                    break;
                case 3:
                    Game.Player.WantedLevel = 0;
                    Notification.Show("Wanted Level Off!");
                    break;
                case 4:
                    Game.Player.Character.Weapons.Current.InfiniteAmmo = true;
                    Notification.Show("Ammo set to infinite!");
                    break;
            }
        }


    }
}
