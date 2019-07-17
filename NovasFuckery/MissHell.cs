using BS_Utils.Utilities;
using NovasFuckery.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Random = UnityEngine.Random;

namespace NovasFuckery
{
    internal static class MissHell
    {
        internal static BeatmapObjectSpawnController SpawnController;
        internal static StandardLevelGameplayManager PauseManager;
        internal static PlayerController PlayerController;
        internal static SaberManager SaberManager;

        internal static Vector3 StartPosition;

        internal static void SetupHell() {
            SpawnController = Resources.FindObjectsOfTypeAll<BeatmapObjectSpawnController>().FirstOrDefault();
            PauseManager = Resources.FindObjectsOfTypeAll<StandardLevelGameplayManager>().FirstOrDefault();
            PlayerController = Resources.FindObjectsOfTypeAll<PlayerController>().FirstOrDefault();

            SaberManager = PlayerController.GetField("_saberManager") as SaberManager;

            if (SpawnController) {
                SpawnController.noteWasMissedEvent += MissHell_noteWasMissedEvent;
                SpawnController.noteWasCutEvent += MissHell_noteWasCutEvent;
            }

            StartPosition = PlayerController.transform.position;
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
