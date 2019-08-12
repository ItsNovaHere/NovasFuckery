using NovasFuckery.Util;
using System;
using System.Collections.Generic;
using System.Timers;
using Random = UnityEngine.Random;

namespace NovasFuckery.Mods
{
    internal static class ChallengeMode
    {
        static Timer timer;


        internal static void SetupMode() {
            if (!FuckeryUI.ChallengeMode.Enabled) return;

            timer = new Timer();
            timer.Interval = 13000;
            timer.Elapsed += Timer_Elapsed;
            timer.Start();
        }

        private static void Timer_Elapsed(object sender, ElapsedEventArgs e) {
            FuckeryUI.DisableAllMods(true);
            ActivateRandomMod();
        }

        internal static void CleanupMode() {
            if (!FuckeryUI.ChallengeMode.Enabled) return;

            FuckeryUI.DisableAllMods(true);
            timer.Stop();
            timer.Elapsed -= Timer_Elapsed;
            timer = null;
        }

        /// <summary>
        /// Activates a random mod inside Nova's Fuckery.
        /// </summary>
        /// <param name="doubleChance">The chance of activating 2 mods. Between 0 and 1</param>
        internal static void ActivateRandomMod(float doubleChance = 0.1f) {
            var activateDouble = Random.Range(0f, 1f) <= doubleChance;
            if (activateDouble) ActivateMod(GetNewRandomMod());
            ActivateMod(GetNewRandomMod());
        }

        private static UIOption GetNewRandomMod() {
            var newMod = FuckeryUI.Options[Random.Range(0, FuckeryUI.Options.Count - 1)];
            Plugin.Logger.Log(IPA.Logging.Logger.Level.Info, $"Getting new random mod: {newMod.Name}");

            return newMod.AllowedInChallengeMode ? newMod : GetNewRandomMod();
        }

        private static void ActivateMod(UIOption mod) {
            mod.Enabled = true;
        }
    }
}
