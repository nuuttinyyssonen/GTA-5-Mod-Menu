using System;
using GTA;
using GTA.Native;
using GTA.Math;
using System.Windows.Forms;
using GTA.UI;
using MenuActions;
using ExecuteAllMods;
using Key;
using ticks;

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
            World,
            Teleport
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
            "World Menu",
            "Teleport Menu"
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
        public static readonly string[] teleportOptions = {
            "Mount Chiliad",
            "Los Santos International Airport",
            "Maze Bank Roof",
            "Fort Zancudo"
        };

        public Main()
        {
            Tick += HandleTicks.handleOnTick;
            KeyDown += HandleKey.handleKeyDown;
            Interval = 0;
        }
    }
}
