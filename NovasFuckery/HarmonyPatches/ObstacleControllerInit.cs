using Harmony;
using NovasFuckery.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace NovasFuckery.HarmonyPatches
{
    [HarmonyPatch(typeof(ObstacleController))]
    [HarmonyPatch("Init", MethodType.Normal)]
    class ObstacleControllerInit
    {
        static void Prefix (
            ObstacleData obstacleData,
            ref Vector3 startPos,
            ref Vector3 midPos,
            Vector3 endPos,
            float move1Duration,
            float move2Duration,
            float startTimeOffset,
            float singleLineWidth
            ) {

            if (!FuckeryUI.MegaJump.Enabled) return;
            if (obstacleData.width > 2) return;

            startPos.x *= FuckeryUI.Mirror.Enabled ? -2 : 2;
            startPos.y *= 100;
            midPos.x *= FuckeryUI.Mirror.Enabled ? -10 : 10;
        }
    }
}
