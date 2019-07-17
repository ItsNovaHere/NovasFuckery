using NovasFuckery.Util;
using System;
using Random = UnityEngine.Random;

namespace NovasFuckery.Mods
{
    internal static class ChallengeMode
    {
        internal static void SetupMode() {

        }

        /// <summary>
        /// Activates a random mod inside Nova's Fuckery.
        /// </summary>
        /// <param name="doubleChance">The chance of activating 2 mods. Between 0 and 1</param>
        internal static void ActivateRandomMod(float doubleChance = 0.1f) {
            var activateDouble = Random.Range(0, 1) <= doubleChance;
            if (activateDouble) ActivateMod(GetNewRandomMod());
            ActivateMod(GetNewRandomMod());
        }

        private static UIOption GetNewRandomMod() {
            var newMod = FuckeryUI.Options[Random.Range(0, FuckeryUI.Options.Count - 1)];

            return newMod == FuckeryUI.ChallengeMode ? GetNewRandomMod() : newMod;
        }

        private static void ActivateMod(UIOption mod) {
            mod.Enabled = true;
        }
    }
}
