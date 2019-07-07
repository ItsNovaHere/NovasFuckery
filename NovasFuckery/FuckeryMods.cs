using System;
using BS_Utils.Gameplay;
using BS_Utils.Utilities;
using NovasFuckery.Util;
using System.Linq;
using NovasFuckery.Mods;
using UnityEngine;
using Object = UnityEngine.Object;
using UnityEngine.XR;

namespace NovasFuckery
{

    internal static class FuckeryMods {
        internal static BeatmapObjectSpawnController SpawnController;
        internal static StandardLevelGameplayManager PauseManager;
        internal static SaberManager SaberManager;

        internal static void SetupMods () {
            bool disableScore = false;

            BS_Utils.Plugin.LevelDidFinishEvent += Plugin_LevelDidFinishEvent;

            SpawnController = Resources.FindObjectsOfTypeAll<BeatmapObjectSpawnController>().First();
            SpawnController.noteWasMissedEvent += FuckeryMods_noteWasMissedEvent;

            PauseManager = Resources.FindObjectsOfTypeAll<StandardLevelGameplayManager>().First();
            SaberManager = Resources.FindObjectsOfTypeAll<SaberManager>().First();

            if (FuckeryUI.OneAtATime.Enabled) 
                OAAT();

            if (FuckeryUI.InvisibleSabers.Enabled)
                InvisbleSabers();

            if (FuckeryUI.ModsEnabled()) {
                disableScore = true;
            }
            
            if (disableScore) {
                ScoreSubmission.DisableSubmission("Nova's Fuckery");
            }
        }

        private static void Plugin_LevelDidFinishEvent(StandardLevelScenesTransitionSetupDataSO levelScenesTransitionSetupDataSO, LevelCompletionResults levelCompletionResults) {
            SpawnController.noteWasMissedEvent -= FuckeryMods_noteWasMissedEvent;
            SpawnController = null;

            PauseManager = null;
            SaberManager = null;

            BS_Utils.Plugin.LevelDidFinishEvent -= Plugin_LevelDidFinishEvent;
        }

        private static void FuckeryMods_noteWasMissedEvent(BeatmapObjectSpawnController arg1, NoteController arg2) {
            if (FuckeryUI.PauseOnMiss.Enabled) {
                if (PauseManager) {
                    PauseManager.Pause();
                }
            }

            if (FuckeryUI.AYYYYYOnMiss.Enabled) {
                Plugin.MissSounds[UnityEngine.Random.Range(0, Plugin.MissSounds.Count - 1)].Play();
            }
        }

        private static void InvisbleSabers () {
            Resources.FindObjectsOfTypeAll<PlayerController>().First().gameObject.AddComponent<InvisibleSabers>();
        }

        internal static void OAAT () {
            Resources.FindObjectsOfTypeAll<PlayerController>().First().gameObject.AddComponent<OneAtATime>();
        }
    }
}
