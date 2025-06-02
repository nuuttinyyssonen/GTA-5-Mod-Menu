using System;
using GTA;
using GTA.Native;
using GTA.Math;
using System.Windows.Forms;
using GTA.UI;

namespace teleport
{
    public class TeleportToCoords
    {
        public static void teleportTo(float x, float y, float z)
        {
            Vector3 target = new Vector3(x, y, z);
            if (Game.Player.Character.IsInVehicle())
            {
                Vehicle vehicle = Game.Player.Character.CurrentVehicle;
                vehicle.Position = target;
            }
            else
            {
                Game.Player.Character.Position = target;
            }
        }
    }
}