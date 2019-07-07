using Harmony;
using NovasFuckery.Util;
using System;
using UnityEngine;

namespace NovasFuckery.HarmonyPatches
{
    [HarmonyPatch(typeof(NoteController))]
    [HarmonyPatch("Init", MethodType.Normal)]
    class NoteControllerInit
    {
        static void Prefix (ref NoteData noteData, ref Vector3 moveStartPos, ref Vector3 moveEndPos, Vector3 jumpEndPos, float moveDuration, float jumpDuration, float startTime, float jumpGravity, ref NoteController __instance, ref NoteData ____noteData, ref NoteMovement ____noteMovement, ref Action<NoteController> ___didInitEvent) {
            if (FuckeryUI.MegaJump.Enabled) {
                moveStartPos.x *= FuckeryUI.Mirror.Enabled ? -2 : 2;
                moveStartPos.y *= 100;
                moveStartPos.y += UnityEngine.Random.Range(-4, 4);
                moveEndPos.x *= FuckeryUI.Mirror.Enabled ? -10 : 10;
            }

            if (FuckeryUI.WideNotes.Enabled) {
                __instance.gameObject.transform.localScale = new Vector3(2, 1, 1);
            }
        }
    }
}
