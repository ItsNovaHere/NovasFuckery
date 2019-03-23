using Harmony;
using NovasFuckery.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using BS_Utils.Utilities;

namespace NovasFuckery.HarmonyPatches
{
    [HarmonyPatch(typeof(NoteData))]
    [HarmonyPatch(".ctor", MethodType.Constructor)]
    [HarmonyPatch(new Type[] { typeof(int), typeof(float), typeof(int), typeof(NoteLineLayer), typeof(NoteLineLayer), typeof(NoteType), typeof(NoteCutDirection), typeof(float), typeof(float) })]
    class NoteDataConstructor
    {
        static void Prefix(int id, ref float time, ref int lineIndex, ref NoteLineLayer noteLineLayer, ref NoteLineLayer startNoteLineLayer, NoteType noteType, ref NoteCutDirection cutDirection, float timeToNextBasicNote, float timeToPrevBasicNote) {
            if (FuckeryUI.RandomPosition.Enabled) {
                noteLineLayer = (NoteLineLayer) UnityEngine.Random.Range(0, 3);
                startNoteLineLayer = noteLineLayer;
                lineIndex = UnityEngine.Random.Range(0, 4);
            }

            if (FuckeryUI.RandomDirection.Enabled) {
                cutDirection = (NoteCutDirection) UnityEngine.Random.Range(1, 7);
            }

            if (FuckeryUI.MildAnnoyance.Enabled) {
                time += UnityEngine.Random.Range(-.04f, .04f);
            }
        }
    }
}
