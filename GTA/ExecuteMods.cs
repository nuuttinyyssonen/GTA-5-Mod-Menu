using System;
using GTA;
using GTA.Native;
using GTA.Math;
using System.Windows.Forms;
using GTA.UI;
using MenuActions;
using GTAV_Mod_Menu;


namespace ExecuteAllMods
{
    public class ExecuteMods
    {
        public static void ExecuteSubMenuOption(int index)
        {
            switch (index)
            {
                case 0: // Weather menu
                    Main.currentSubMenu = Main.SubMenu.Weather;
                    Main.selectedSubMenuOption = Main.weatherOptions;
                    break;
                case 1: // Vehicle menu
                    Main.currentSubMenu = Main.SubMenu.Vehicle;
                    Main.selectedSubMenuOption = Main.vehicleOptions;
                    break;
                case 2: // Player menu
                    Main.currentSubMenu = Main.SubMenu.Player;
                    Main.selectedSubMenuOption = Main.playerOptions;
                    break;
                case 3: // World menu  
                    Main.currentSubMenu = Main.SubMenu.World;
                    Main.selectedSubMenuOption = Main.worldOptions;
                    break;
                case 4: // Teleport menu
                    Main.currentSubMenu = Main.SubMenu.Teleport;
                    Main.selectedSubMenuOption = Main.teleportOptions;
                    break;
            }
            Main.selectedSubMenuIndex = 0; // Reset sub-menu index when entering a new sub-menu
        }

        public static void ExecuteOptions(int index)
        {
            switch (Main.currentSubMenu)
            {
                case Main.SubMenu.Weather:
                    SubMenuActions.ExecuteWeatherOption(index);
                    break;
                case Main.SubMenu.Vehicle:
                    SubMenuActions.ExecuteVehicleOption(index);
                    break;
                case Main.SubMenu.Player:
                    SubMenuActions.ExecutePlayerOption(index);
                    break;
                case Main.SubMenu.World:
                    SubMenuActions.ExecuteWorldOption(index);
                    break;
                case Main.SubMenu.Teleport:
                    SubMenuActions.ExecuteTeleportOption(index);
                    break;
            }
        }
    }
}