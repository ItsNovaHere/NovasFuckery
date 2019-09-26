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
            if (FuckeryUI.SadTracking.Enabled)
            {
                if((int)Time.frameCount % 5 == 0)
                {
                    return false;
                }
            }

            return !MissHell.TrackingError;
        }
    }
}
