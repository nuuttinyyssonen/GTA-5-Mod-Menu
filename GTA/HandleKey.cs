using System;
using GTA;
using GTA.Native;
using GTA.Math;
using System.Windows.Forms;
using GTA.UI;
using GTAV_Mod_Menu;
using ExecuteAllMods;

namespace Key
{
    public class HandleKey
    {
        public static void handleKeyDown(object semder, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5)
            {
                Main.menuOpen = !Main.menuOpen;
                if (Main.menuOpen)
                {
                    Notification.PostTicker("Mod menu opened!", false);
                }
                else
                {
                    Main.currentSubMenu = Main.SubMenu.None; // Reset sub-menu when closing the menu
                    Notification.PostTicker("Mod Menu Closed!", false);
                }
            }

            if (!Main.menuOpen)
            {
                return;
            }

            if (Main.menuOpen && Main.currentSubMenu == Main.SubMenu.None)
            {
                switch (e.KeyCode)
                {
                    case Keys.NumPad8: // Up
                        if (Main.selectedMenuIndex == 0)
                        {
                            Main.selectedMenuIndex = Main.menuOptions.Length - 1;
                        }
                        else
                        {
                            Main.selectedMenuIndex--;
                        }
                        break;
                    case Keys.NumPad2: // Down
                        if (Main.selectedMenuIndex == Main.menuOptions.Length - 1)
                        {
                            Main.selectedMenuIndex = 0;
                        }
                        else
                        {
                            Main.selectedMenuIndex++;
                        }
                        break;
                    case Keys.NumPad5: // Select
                        ExecuteMods.ExecuteSubMenuOption(Main.selectedMenuIndex);
                        break;
                }
            }
            else if (Main.menuOpen)
            {
                switch (e.KeyCode)
                {
                    case Keys.NumPad8: // Up
                        if (Main.selectedSubMenuIndex == 0)
                        {
                            Main.selectedSubMenuIndex = Main.selectedSubMenuOption.Length - 1;
                        }
                        else
                        {
                            Main.selectedSubMenuIndex--;
                        }
                        break;
                    case Keys.NumPad2: // Down
                        if (Main.selectedSubMenuIndex == Main.selectedSubMenuOption.Length - 1)
                        {
                            Main.selectedSubMenuIndex = 0;
                        }
                        else
                        {
                            Main.selectedSubMenuIndex++;
                        }
                        break;
                    case Keys.NumPad5: // Select
                        ExecuteMods.ExecuteOptions(Main.selectedSubMenuIndex);
                        break;
                    case Keys.NumPad0: // Back to main menu
                        Main.currentSubMenu = Main.SubMenu.None;
                        Main.selectedSubMenuIndex = 0;
                        break;
                }

            }
        }
   }
}
