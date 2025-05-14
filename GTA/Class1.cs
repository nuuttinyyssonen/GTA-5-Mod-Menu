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
        Vehicle car;
        private bool menuOpen = false;
        private int selectedIndex = 0;
        private readonly string[] menuOptions = { "Spawn adder", "God Mode", "Give Weapons" };
        public Main()
        {
            Tick += onTick;
            KeyDown += onKeyDown;
        }

        private void onTick(object sender, EventArgs e)
        {
            if (menuOpen)
            {
                string displayText = "";
                for(int i = 0; i < menuOptions.Length; i++)
                {
                    if (i == selectedIndex)
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

            if(e.KeyCode == Keys.NumPad8)
            {
                if(selectedIndex == 0)
                {
                    selectedIndex = menuOptions.Length - 1;
                }
                else
                {
                    selectedIndex--;
                }
            }
            if (e.KeyCode == Keys.NumPad2)
            {
                if(selectedIndex == menuOptions.Length)
                {
                    selectedIndex = 0;
                }
                else
                {
                    selectedIndex++;
                }
            }
            if (e.KeyCode == Keys.NumPad5)
            {
                ExecuteOption(selectedIndex);
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
                    Weapon weapon = Game.Player.Character.Weapons.Give(WeaponHash.GolfClub, 0, true, true);
                    Notification.Show("Weapons Given!");
                    break;
            }
        }


    }
}
