using BS_Utils.Gameplay;
using NovasFuckery.MonoBehaviours;
using NovasFuckery.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using BS_Utils.Utilities;
using System.Collections;
using Harmony;
using System.Reflection;

namespace NovasFuckery
{
    class FuckeryMods
    {
        static PropertyInfo noteTime = AccessTools.Property(typeof(BeatmapObjectData), "time");

        internal static void SetupMods () {
            bool disableScore = false;

            if (FuckeryUI.OneAtATime.Enabled) {
                OAAT();
                disableScore = true;
            }

            if (FuckeryUI.InvisibleSabers.Enabled) {
                InvisbleSabers();
                disableScore = true;
            }

            if (FuckeryUI.MegaJump.Enabled ||
                FuckeryUI.RandomPositionX.Enabled ||
                FuckeryUI.RandomPositionY.Enabled ||
                FuckeryUI.RandomDirection.Enabled ||
                FuckeryUI.RandomColors.Enabled ||
                FuckeryUI.RandomBombs.Enabled) {

                disableScore = true;
            }

            if (disableScore) {
                ScoreSubmission.DisableSubmission("Nova's Fuckery");
            }
        }

        private static void InvisbleSabers () {
            Resources.FindObjectsOfTypeAll<PlayerController>().First().gameObject.AddComponent<InvisibleSabers>();
        }

        //One At A Time
        internal static void OAAT () {
            Resources.FindObjectsOfTypeAll<PlayerController>().First().gameObject.AddComponent<OneAtATime>();
        }

        internal static IEnumerator MildAnnoyRoutine () {
            yield return new WaitForSeconds(1f);

            GameplayCoreSceneSetup gameplayCoreSceneSetup = Resources.FindObjectsOfTypeAll<GameplayCoreSceneSetup>().First();

            BeatmapDataModel dataModel = gameplayCoreSceneSetup.GetField<BeatmapDataModel>("_beatmapDataModel");
            BeatmapData beatmapData = dataModel.beatmapData;
            BeatmapObjectData[] objects;
            NoteData note;

            foreach (BeatmapLineData line in beatmapData.beatmapLinesData) {
                objects = line.beatmapObjectsData;
                
                foreach (BeatmapObjectData beatmapObject in objects) {
                    if (beatmapObject.beatmapObjectType == BeatmapObjectType.Note) {
                        note = beatmapObject as NoteData;

                        Console.WriteLine(note.time);
                        noteTime.SetValue(beatmapObject, beatmapObject.time + UnityEngine.Random.Range(-.04f, .04f));
                        Console.WriteLine(note.time);
                    }
                }
            }
        }
    }
}
