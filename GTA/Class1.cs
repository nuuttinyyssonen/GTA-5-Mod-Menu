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
        private bool menuOpen = false;
        private int selectedIndex = 0;
        private readonly string[] menuOptions = { "Spawn adder", "God Mode", "Give Weapons", "Wanted level off", "Super Speed", "Infinite Ammo"};
        private bool superSpeed = false;
        public Main()
        {
            Tick += onTick;
            KeyDown += onKeyDown;
            Interval = 0;
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
            if (superSpeed)
            {
                if (Game.Player.Character.IsRunning || Game.Player.Character.IsSprinting)
                {
                    Vector3 forward = Game.Player.Character.ForwardVector;
                    Game.Player.Character.Velocity += forward * 10.5f;
                }

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
                    if(!superSpeed)
                    {
                        superSpeed = true;
                        Notification.Show("Super Speed On!");
                    }
                    else
                    {
                        superSpeed = false;
                        Notification.Show("Super Speed off!");
                    }
                    break;
                case 5:
                    Game.Player.Character.Weapons.Current.InfiniteAmmo = true;
                    Notification.Show("Ammo set to infinite!");
                    break;
            }
        }


    }
}
