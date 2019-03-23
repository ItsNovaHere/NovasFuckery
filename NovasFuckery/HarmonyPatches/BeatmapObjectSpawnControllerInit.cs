using Harmony;
using NovasFuckery.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NovasFuckery.HarmonyPatches
{
    [HarmonyPatch(typeof(BeatmapObjectSpawnController))]
    [HarmonyPatch("Init", MethodType.Normal)]
    class BeatmapObjectSpawnControllerInit
    {
        static void Prefix (BeatmapObjectSpawnController __instance, float beatsPerMinute, int noteLinesCount, ref float noteJumpMovementSpeed, int noteJumpStartBeatOffset, bool disappearingArrows, bool ghostNotes) {
            if (FuckeryUI.NJSFix.Enabled) noteJumpMovementSpeed *= .8f;
        }
    }
}
