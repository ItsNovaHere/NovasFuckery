using BS_Utils.Utilities;
using Harmony;
using NovasFuckery.Util;
using UnityEngine;

namespace NovasFuckery.HarmonyPatches
{
    [HarmonyPatch(typeof(VRController))]
    [HarmonyPatch("UpdatePositionAndRotation", MethodType.Normal)]
    class VRControllerUpdatePositionAndRotation
    {
        static bool Prefix()
        {
            if (FuckeryUI.Setup == false) return true;
            if (FuckeryUI.SadTracking.Enabled)
            {
                if(Time.frameCount % 3 != 0)
                {
                    return false;
                }
            }

            if(MissHell.TrackingError)
            {
                return false;
            }

            return true;
        }
    }
}
