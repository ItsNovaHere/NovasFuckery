using Harmony;
using NovasFuckery.Util;

namespace NovasFuckery.HarmonyPatches
{
    [HarmonyPatch(typeof(BeatmapObjectSpawnController))]
    [HarmonyPatch("Init", MethodType.Normal)]
    class BeatmapObjectSpawnControllerInit
    {
        static void Prefix (BeatmapObjectSpawnController __instance, float beatsPerMinute, int noteLinesCount, ref float noteJumpMovementSpeed, float noteJumpStartBeatOffset, bool disappearingArrows, bool ghostNotes) {
            if (FuckeryUI.NJSFix.Enabled) noteJumpMovementSpeed *= .8f;
        }
    }
}
