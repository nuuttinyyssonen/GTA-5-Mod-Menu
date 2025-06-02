using System;
using GTA;
using GTA.Native;
using GTA.Math;
using System.Windows.Forms;
using GTA.UI;
using GTAV_Mod_Menu;
using FireVehicles;

namespace ticks
{
    public class HandleTicks
    {
        public static void handleOnTick(object sender, EventArgs e)
        {
            if (Main.menuOpen && Main.currentSubMenu == Main.SubMenu.None)
            {
                string displayText = "";
                for (int i = 0; i < Main.menuOptions.Length; i++)
                {
                    if (i == Main.selectedMenuIndex)
                    {
                        displayText += $"→ {Main.menuOptions[i]}\n";
                    }
                    else
                    {
                        displayText += $"   {Main.menuOptions[i]}\n";
                    }
                }
                GTA.UI.Screen.ShowSubtitle(displayText, 1);
            }
            else if (Main.currentSubMenu == Main.SubMenu.Weather)
            {
                string displayText = "Weather Menu:\n";
                for (int i = 0; i < Main.weatherOptions.Length; i++)
                {
                    if (i == Main.selectedSubMenuIndex)
                    {
                        displayText += $"→ {Main.weatherOptions[i]}\n";
                    }
                    else
                    {
                        displayText += $"   {Main.weatherOptions[i]}\n";
                    }
                }
                GTA.UI.Screen.ShowSubtitle(displayText, 1);
            }
            else if (Main.currentSubMenu == Main.SubMenu.Vehicle)
            {
                string displayText = "Vehicle Menu:\n";
                for (int i = 0; i < Main.vehicleOptions.Length; i++)
                {
                    if (i == Main.selectedSubMenuIndex)
                    {
                        displayText += $"→ {Main.vehicleOptions[i]}\n";
                    }
                    else
                    {
                        displayText += $"   {Main.vehicleOptions[i]}\n";
                    }
                }
                GTA.UI.Screen.ShowSubtitle(displayText, 1);
            }
            else if (Main.currentSubMenu == Main.SubMenu.Player)
            {
                string displayText = "Player Menu:\n";
                for (int i = 0; i < Main.playerOptions.Length; i++)
                {
                    if (i == Main.selectedSubMenuIndex)
                    {
                        displayText += $"→ {Main.playerOptions[i]}\n";
                    }
                    else
                    {
                        displayText += $"   {Main.playerOptions[i]}\n";
                    }
                }
                GTA.UI.Screen.ShowSubtitle(displayText, 1);
            }
            else if (Main.currentSubMenu == Main.SubMenu.World)
            {
                string displayText = "World Menu:\n";
                for (int i = 0; i < Main.worldOptions.Length; i++)
                {
                    if (i == Main.selectedSubMenuIndex)
                    {
                        displayText += $"→ {Main.worldOptions[i]}\n";
                    }
                    else
                    {
                        displayText += $"   {Main.worldOptions[i]}\n";
                    }
                }
                GTA.UI.Screen.ShowSubtitle(displayText, 1);
            }
            else if(Main.currentSubMenu == Main.SubMenu.Teleport)
            {
                string displayText = "Teleport Menu:\n";
                for (int i = 0; i < Main.teleportOptions.Length; i++)
                {
                    if (i == Main.selectedSubMenuIndex)
                    {
                        displayText += $"→ {Main.teleportOptions[i]}\n";
                    }
                    else
                    {
                        displayText += $"   {Main.teleportOptions[i]}\n";
                    }
                }
                GTA.UI.Screen.ShowSubtitle(displayText, 1);
            }
            if (Main.superSpeed)
            {
                Function.Call(Hash.SET_RUN_SPRINT_MULTIPLIER_FOR_PLAYER, Game.Player.Handle, 1.49f);
            }
            if (Main.superJump)
            {
                Function.Call(Hash.SET_SUPER_JUMP_THIS_FRAME, Game.Player.Handle);
            }
            if (Main.vehicleFire)
            {
                Ped player = Game.Player.Character;
                if(Game.IsControlPressed(GTA.Control.Attack) && !player.IsInVehicle())
                {
                    FireVehiclesFromGun.handleFireVehicles(player);
                }
            }
        }
    }
}
