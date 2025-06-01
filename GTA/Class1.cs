using System;
using GTA;
using GTA.Native;
using GTA.Math;
using System.Windows.Forms;
using GTA.UI;
using MenuActions;
using ExecuteAllMods;

namespace GTAV_Mod_Menu
{
    public class Main : Script
    {
        // Define the sub-menu states
        public enum SubMenu
        {
            None,
            Weather,
            Vehicle,
            Player,
            World
        }
        public static SubMenu currentSubMenu = SubMenu.None;
        private bool menuOpen = false;

        // Define the selected index for the main menu and sub-menus
        private int selectedMenuIndex = 0;
        public static int selectedSubMenuIndex = 0;
        public static string[] selectedSubMenuOption;

        // Define the menu options and sub-menu options
        private readonly string[] menuOptions = { 
            "Weather Menu", 
            "Vehicle Menu", 
            "Player Menu", 
            "World Menu"
        };
        public static readonly string[] weatherOptions = { 
            "Cloudy", 
            "Sunny", 
            "Rainy", 
            "Snowy" 
        };
        public static readonly string[] vehicleOptions = { 
            "Adder", 
            "Zentorno", 
            "Bullet", 
            "Cheetah", 
            "Infernus", 
            "T20" 
        };
        public static readonly string[] playerOptions = { 
            "God Mode", 
            "Give Weapons", 
            "Wanted Level Off", 
            "Super Speed", 
            "Infinite Ammo" 
        };
        public static readonly string[] worldOptions = { 
            "Set time of day: Morning", 
            "Set time of day: Noon", 
            "Set time of day: night", 
            "Remove vehicles", 
            "Low gravity mode", 
            "Remove pedestrians" 
        };

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
            else if (currentSubMenu == SubMenu.Player)
            {
                string displayText = "Player Menu:\n";
                for (int i = 0; i < playerOptions.Length; i++)
                {
                    if (i == selectedSubMenuIndex)
                    {
                        displayText += $"→ {playerOptions[i]}\n";
                    }
                    else
                    {
                        displayText += $"   {playerOptions[i]}\n";
                    }
                }
                GTA.UI.Screen.ShowSubtitle(displayText, 1);
            }
            else if (currentSubMenu == SubMenu.World)
            {
                string displayText = "World Menu:\n";
                for (int i = 0; i < worldOptions.Length; i++)
                {
                    if (i == selectedSubMenuIndex)
                    {
                        displayText += $"→ {worldOptions[i]}\n";
                    }
                    else
                    {
                        displayText += $"   {worldOptions[i]}\n";
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
                    currentSubMenu = SubMenu.None; // Reset sub-menu when closing the menu
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
                        ExecuteMods.ExecuteSubMenuOption(selectedMenuIndex);
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
                            selectedSubMenuIndex = selectedSubMenuOption.Length - 1;
                        }
                        else
                        {
                            selectedSubMenuIndex--;
                        }
                        break;
                    case Keys.NumPad2: // Down
                        if (selectedSubMenuIndex == selectedSubMenuOption.Length - 1)
                        {
                            selectedSubMenuIndex = 0;
                        }
                        else
                        {
                            selectedSubMenuIndex++;
                        }
                        break;
                    case Keys.NumPad5: // Select
                        ExecuteMods.ExecuteOptions(selectedSubMenuIndex);
                        break;
                    case Keys.NumPad0: // Back to main menu
                        currentSubMenu = SubMenu.None;
                        selectedSubMenuIndex = 0;
                        break;
                }
            }
        }
    }
}
