using System;
using BS_Utils.Gameplay;
using BS_Utils.Utilities;
using NovasFuckery.Util;
using System.Linq;
using NovasFuckery.Mods;
using UnityEngine;
using Random = UnityEngine.Random;

namespace NovasFuckery
{

    internal static class FuckeryMods {
        

        internal static void SetupMods () {
            bool disableScore = false;

            BS_Utils.Plugin.LevelDidFinishEvent += Plugin_LevelDidFinishEvent;

            MissHell.SetupHell();
            ChallengeMode.SetupMode();

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
            try {
                MissHell.ResetHell();
                ChallengeMode.CleanupMode();
            } catch {

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
