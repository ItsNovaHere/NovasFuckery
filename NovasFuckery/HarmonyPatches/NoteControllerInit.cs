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
    [HarmonyPatch(typeof(NoteController))]
    [HarmonyPatch("Init", MethodType.Normal)]
    class NoteControllerInit
    {
        static void Prefix (NoteData noteData, ref Vector3 moveStartPos, ref Vector3 moveEndPos, Vector3 jumpEndPos, float moveDuration, float jumpDuration, float startTime, float jumpGravity, ref NoteController __instance, ref NoteData ____noteData, ref NoteMovement ____noteMovement, ref Action<NoteController> ___didInitEvent) {
            if (!FuckeryUI.MegaJump.Enabled) return;

            moveStartPos.x *= FuckeryUI.Mirror.Enabled ? -2 : 2;
            moveStartPos.y *= 100;
            moveStartPos.y += UnityEngine.Random.Range(-4, 4);
            moveEndPos.x *= FuckeryUI.Mirror.Enabled ? -10 : 10;
        }
    }
}
