using BS_Utils.Utilities;
using NovasFuckery.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using UnityEngine;
using Random = UnityEngine.Random;

namespace NovasFuckery
{
    internal static class MissHell
    {
        internal static bool TrackingError = false;
        internal static BeatmapObjectSpawnController SpawnController;
        internal static StandardLevelGameplayManager PauseManager;
        internal static PlayerController PlayerController;
        internal static SaberManager SaberManager;

        internal static Saber leftSaber;
        internal static Saber rightSaber;

        internal static Vector3 StartPosition;

        private static Timer timer;

        internal static void SetupHell() {
            TrackingError = false;
            SpawnController = Resources.FindObjectsOfTypeAll<BeatmapObjectSpawnController>().FirstOrDefault();
            PauseManager = Resources.FindObjectsOfTypeAll<StandardLevelGameplayManager>().FirstOrDefault();
            PlayerController = Resources.FindObjectsOfTypeAll<PlayerController>().FirstOrDefault();

            SaberManager = PlayerController.GetField("_saberManager") as SaberManager;
            leftSaber = SaberManager.GetPrivateField<Saber>("_leftSaber") as Saber;
            rightSaber = SaberManager.GetPrivateField<Saber>("_rightSaber") as Saber;


            if (SpawnController) {
                SpawnController.noteWasMissedEvent += MissHell_noteWasMissedEvent;
                SpawnController.noteWasCutEvent += MissHell_noteWasCutEvent;
            }

            StartPosition = PlayerController.transform.position;

            timer = new Timer(3000);
            timer.Elapsed += Timer_Elapsed;
        }

        private static void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            TrackingError = false;
            timer.Stop();
        }

        internal static void ResetHell() {
            SpawnController.noteWasMissedEvent -= MissHell_noteWasMissedEvent;
            SpawnController.noteWasCutEvent -= MissHell_noteWasCutEvent;
            SpawnController = null;

            PauseManager = null;
            SaberManager = null;

            PlayerController.transform.position = StartPosition;
        }

        internal static void NoteMissed() {
            if (FuckeryUI.PauseOnMiss.Enabled) {
                if (PauseManager) {
                    PauseManager.Pause();
                }
            }

            if (FuckeryUI.AYYYYYOnMiss.Enabled) {
                Plugin.MissSounds[Random.Range(0, Plugin.MissSounds.Count - 1)].Play();
            }

            if (FuckeryUI.theButton.Enabled)
            {
                // im sorry - nora
                SpawnController._globalYJumpOffset = (Random.Range(1.4f, 2f) - 1.8f) * 0.5f;
                //nice
                var width = Random.Range(0.1f, 10f);
                // im very sorry
                leftSaber.transform.localScale = new Vector3(width, width, 1);
                rightSaber.transform.localScale = new Vector3(width, width, 1);
            }

            if (FuckeryUI.TrackingErrorOnMiss.Enabled)
            {
                TrackingError = true;
                timer.Start();
            }
        }

        private static void MissHell_noteWasCutEvent(BeatmapObjectSpawnController arg1, NoteController arg2, NoteCutInfo arg3) {
            if (!arg3.allIsOK) {
                NoteMissed();
            }
        }

        private static void MissHell_noteWasMissedEvent(BeatmapObjectSpawnController arg1, NoteController arg2) {
            if (arg2.noteData.noteType != NoteType.Bomb) {
                NoteMissed();
            }
        }
    }
}