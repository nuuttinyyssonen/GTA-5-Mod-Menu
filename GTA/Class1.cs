using System;
using GTA;
using GTA.Native;
using GTA.Math;
using System.Windows.Forms;
using GTA.UI;
using MenuActions;
using ExecuteAllMods;
using Key;

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
        public static bool menuOpen = false;

        // Define the selected index for the main menu and sub-menus
        public static int selectedMenuIndex = 0;
        public static int selectedSubMenuIndex = 0;
        public static string[] selectedSubMenuOption;

        // Define the menu options and sub-menu options
        public static readonly string[] menuOptions = { 
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
            KeyDown += HandleKey.handleKeyDown;
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
    }
}
