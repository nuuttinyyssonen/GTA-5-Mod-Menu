using System;
using GTA;
using GTA.Native;
using GTA.Math;
using System.Windows.Forms;
using GTA.UI;

namespace FireVehicles
{
    public class FireVehiclesFromGun
    {
        public static void handleFireVehicles(Ped player)
        {
            Vector3 start = player.Position + player.ForwardVector * 1.5f + new Vector3(0, 0, 1f);
            Vector3 direction = GameplayCamera.Direction;

            Model model = new Model("Adder");
            if(!model.IsLoaded) model.Request(500);

            if(model.IsInCdImage && model.IsValid)
            {
                Vehicle v = World.CreateVehicle(model, start);
                if(v != null)
                {
                    v.ApplyForceRelative(direction * 200);
                    v.MarkAsNoLongerNeeded();
                }
            }
            model.MarkAsNoLongerNeeded();
        }
    }
}